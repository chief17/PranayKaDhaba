using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PranayKaDhaba
{
    class ClassCustomer
    {
        public String customerName;
        public String customerPhone;
        public String customerAddress;

        private String sqlQuery;
        private MySqlDataReader resultSet;
        private DbConn conn;
        private DbConn conn1; //used for parallel reading + update

        public ClassCustomer()
        {
            conn = new DbConn();
            conn1 = new DbConn();
        }
        public bool dbConnect()
        {
            if (conn.connect())
                return true;
            else
                return false;
        }
        public bool dbDisConnect()
        {
            if (conn.disconnects())
                return true;
            else
                return false;
        }
        public AutoCompleteStringCollection getOnlyCustomerNames()
        {
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            sqlQuery = "SELECT customerName from PKD_CUSTOMER";
            resultSet = conn.execSQL(sqlQuery);
            while (resultSet.Read())
                coll.Add(resultSet[0].ToString());
            coll.Add("s1xxxxxxxxxxxxx");
            resultSet.Close();
            return coll;
        }
    }
}
