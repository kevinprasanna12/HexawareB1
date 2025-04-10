using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Finance_Management.Util
{
    public class DBConnection
    {
        public static readonly string ConnectionString = "data source = LAPTOP-N8Q7GD6I ;initial catalog = FMDB ;Integrated Security=True;TrustServerCertificate=True;";
        public static SqlConnection GetConnection(string ConnectionString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating database connection: " + ex.Message);
            }
        }
    }
}
