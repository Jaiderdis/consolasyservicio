using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification
{
    public class Connection
    {
        private string url { get; set; }


        public Connection()
        {
           
            this.url = ConfigurationSettings.AppSettings["DB"].ToString();
        }

        public DataTable Consulta()
        {

            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.url))
                {
                    connection.Open();

                    SqlCommand comando = new SqlCommand("TransacionesPendientes", connection);
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = comando.ExecuteReader();
                    data.Load(reader);

                    connection.Close();


                }
                return data;

            }
            catch (Exception ex)
            {

                return new DataTable();
            }


        }
    }

}
