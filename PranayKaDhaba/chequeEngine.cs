using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PranayKaDhaba
{
    class chequeEngine
    {
        DbConn conn;
        private String sqlQuery;
        private MySqlDataReader resultSet;
        public chequeEngine()
        {
            conn = new DbConn();
            conn.connect();
        }
        ~chequeEngine()
        {
            conn.disconnects();
        }
        public double fetchtotal(String date)
        {
            sqlQuery = "Select cheque_amount from pkd_cheques where cheque_cashdate = '" + date + "'";
            resultSet = conn.execSQL(sqlQuery);
            double total = 0;
            try
            {

                while (resultSet.Read())
                {
                    total += Convert.ToDouble(resultSet["cheque_amount"].ToString());
                }
                if (total == 0)
                {
                    return 0;
                }
                else
                    return total;
            }
            catch(Exception e)
            {
                return -1;
            }

        }
        public bool addcheque(String cno, String name,String cdate,String idate,String am)
        {
            sqlQuery = "Insert into pkd_cheques (cheque_number,cheque_amount,cheque_toperson,cheque_issue_date,cheque_cashdate) values(" + cno + "," + am + ",'" + name + "'," + idate + "," + cdate +")";
            Console.Write(sqlQuery);
            if(conn.updateSQL(sqlQuery) >= 0)
            {
                return true;
            }
            else
            return false;
        }
        public bool delcheque(String cno)
        {
            sqlQuery = "DELETE from pkd_cheques where cheque_number = " + cno;
            if (conn.updateSQL(sqlQuery) >= 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
