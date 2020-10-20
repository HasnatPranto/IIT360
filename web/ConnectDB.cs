using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IIT360_Web
{
 
        public class ConnectDB : IDisposable
        {
            public MySqlConnection connection;

            public ConnectDB(string connectionString)
            {
                connection = new MySqlConnection(connectionString);
                this.connection.Open();
            }

            public void Dispose()
            {
                connection.Close();
            }
        }

}
