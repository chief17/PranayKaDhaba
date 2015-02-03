using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace PranayKaDhaba
{
    class User
    {
        private DbConn conn;
        private string sqlQuery;
        private int responseCode;
        private MySqlDataReader resultSet;

        public string userName;
        public string userPass;
        
        public User()
        {
            conn = new DbConn();
        }
        ~User()
        {
            
        }
        public int validateUser()
        {
            responseCode=0;
            if (!conn.connect())
            {
                responseCode = 1;
                return responseCode;
            }

            sqlQuery = "Select * from PKD_USER where userName='" + userName + "' and userPass='" + userPass + "'";
            resultSet= conn.execSQL(sqlQuery);
            if (!resultSet.Read())
                responseCode = 2;

            conn.disconnects();
            return responseCode;
            
        }
    }
}
