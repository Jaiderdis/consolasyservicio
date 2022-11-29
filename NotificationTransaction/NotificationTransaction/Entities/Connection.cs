using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NotificationTransaction.Entities
{
    public class Connection
    {
        public string connetionString { get; set; }
        public Connection()
        {
            this.connetionString = ConfigurationManager.ConnectionStrings["local"].ToString();
            
        }

        public Respuesta select(string Query) {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connetionString))
                {
                    connection.Open();
                    string query = $"{Query}";
                    SqlCommand comando = new SqlCommand(query, connection);
                    SqlDataReader reader = comando.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    respuesta.Data = dataTable;
                    respuesta.Message = "Se leyeron correctamente";

                    connection.Close();
                }

            }
            catch (System.Exception ex)
            {

                 respuesta.Message = ex.Message;

            }

            return respuesta;
        }

        

    }
}
