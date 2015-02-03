using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PranayKaDhaba
{
    class DbConn
    {
        private MySqlConnection connection;
        private MySqlCommand cmd;

        public DbConn()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.UserID = "root";
            conn_string.Password = "toor";
            conn_string.Database = "test";
            connection = new MySqlConnection(conn_string.ToString());
        }
        
        public bool connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool disconnects()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public MySqlDataReader execSQL(String sql)
        {
            try
            {
                cmd = new MySqlCommand(sql, connection);
                MySqlDataReader oReader = cmd.ExecuteReader();
                return (oReader == null) ? null : oReader;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e.Message);
                return null;
            }
        }
        public int updateSQL(String sql)
        {
            try
            {
                cmd = new MySqlCommand(sql, connection);
                int i = cmd.ExecuteNonQuery();
                return (i == 0) ? 0 : i;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public MySqlCommand getCommand()
        {
            return cmd;
        }
    }

}
