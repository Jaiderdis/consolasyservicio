using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification
{
    partial class ServicePrueba : ServiceBase
    {
        bool band = false;
        public ServicePrueba()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Pendientes.Start();
        }

        protected override void OnStop()
        {
            Pendientes.Stop();    
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DataTable data = new DataTable();
            Connection con = new Connection();
            lisTransacciones lista = new lisTransacciones();
            

            EventLog Log = new EventLog();
            Log.Source = "Transacciones Pendientes";
            if (band) return;
            try
            {
                Log.WriteEntry("Se inicio", EventLogEntryType.Information);
                band = true;
                data = con.Consulta();
                lista = listTrans(data);



                RestClient client = new RestClient("http://192.168.20.173:81");
                RestRequest request = new RestRequest("PruebaServicio/ApiPSE/NotificarPendientes");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(JsonConvert.SerializeObject(lista));
                var DatosResi = client.ExecutePost(request).Content;
                Log.WriteEntry(DatosResi.ToString(), EventLogEntryType.Information);



                Log.WriteEntry("Se finalizo", EventLogEntryType.Information);

            }
            catch (Exception ex)
            {
                    Log.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            band = false;

        }


        public lisTransacciones listTrans(DataTable tabla)
        {

            lisTransacciones lista = new lisTransacciones();
            List<Transaccion> transacciones = new List<Transaccion>();
            foreach (DataRow row in tabla.Rows)
            {
                Estado es = new Estado();
                es.estado=row["str_EstadoTransaccion"].ToString();
                es.municipio = row["str_CodigoMunicipio"].ToString();
                es.cusPSE= row["str_NumeroTransacionPSE"].ToString();
                Transaccion transaccion = new Transaccion();
                transaccion.estado = es;
                transaccion.idTransaccion=row["IDTransaccion"].ToString();
                transaccion.medioPago= row["IDMedioPago"].ToString();

                transacciones.Add(transaccion);
            }
            lista.transacciones = transacciones;
            return lista;
        }
    }
}
