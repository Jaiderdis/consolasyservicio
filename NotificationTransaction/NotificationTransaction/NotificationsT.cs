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
using NotificationTransaction.Entities;

namespace NotificationTransaction
{
    partial class NotificationsT : ServiceBase
    {
        bool band = false;
        public NotificationsT()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Notificar.Start();
        }

        protected override void OnStop()
        {
            Notificar.Stop();
        }

        private void Notificar_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EventLog myLog = new EventLog();
            myLog.Source = "MySource";
            Respuesta respuesta=new Respuesta();
            if (band) return;
            try
            {
                band = true;    
                Connection connection = new Connection();
                respuesta = connection.select("SELECT IDTransaccion,str_Cedula FROM tbl_Transaccion");
                myLog.WriteEntry(respuesta.Message, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                myLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            band = false;


        }
    }
}
