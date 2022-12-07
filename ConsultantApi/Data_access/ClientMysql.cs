using MySql.Data.MySqlClient;
using dotenv.net;
using System;
using ConsultantApi.Properties;

namespace ConsultantApi.Data_access
{
    public class ClientMysql
    {
        private MySqlConnection clientMysql;

        public ClientMysql()
        {
            string host = Properties.Settings.Default.MYSQL_HOST;
            string database = Properties.Settings.Default.MYSQL_DATABASE;
            string user = Properties.Settings.Default.MYSQL_USER;
            string password = Properties.Settings.Default.MYSQL_PASSWORD;

            string connectionString = $"server={host};database={database};uid={user};pwd={password}";
            this.clientMysql = new MySqlConnection(connectionString);
        }

        public MySqlConnection Run()
        { 
            return this.clientMysql;
        }
    }
}