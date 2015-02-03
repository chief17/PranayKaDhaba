using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PranayKaDhaba
{
    class StockEngine
    {

        public UInt32 itemCode;
        public UInt16 itemSubCode;
        public String itemName;
        public Double quantity;
        public Double initQuantity;
        public Double currQuantity;
        public Double buffer;
        public Double costPrice;
        public Double sellingPrice;
        public Double wholeSalePrice;
        public Double taxPercentage;
        public UInt16 measuringUnit;
        public String vendorDetails;
        public UInt16 deleteFlag;
        public UInt16 itemType;


        private UInt16 responseCode;
        private String sqlQuery;
        private MySqlDataReader resultSet;

        private DbConn conn;

        public StockEngine()
        {
            conn = new DbConn();
            conn.connect();
        }
        ~StockEngine()
        {
            conn.disconnects();
        }

        public int getItemDetails()
        {
            //function to provide all item detail when provided with itemCode
            //return code 0 unsucessfull execution
            //return code 1 successfull execution

            sqlQuery = "SELECT * from PKD_MAIN_INVENTORY where itemCode=" + itemCode;
            resultSet = conn.execSQL(sqlQuery);
            if (resultSet.Read())
            {
                itemName = resultSet["itemName"].ToString();
                quantity = Convert.ToDouble(resultSet["totalQuantity"].ToString());
                sellingPrice = Convert.ToDouble(resultSet["sellingPrice"].ToString());
                wholeSalePrice = Convert.ToDouble(resultSet["wholesalePrice"].ToString());
                taxPercentage = Convert.ToDouble(resultSet["taxPercentage"].ToString());
                buffer = Convert.ToDouble(resultSet["bufferCount"].ToString());
                measuringUnit=Convert.ToUInt16(resultSet["measuringUnit"].ToString());
                vendorDetails=resultSet["vendorDetails"].ToString();
                itemType = Convert.ToUInt16(resultSet["productType"].ToString());

                responseCode = 1;
            }
            else
                responseCode = 0;

            resultSet.Close();
            return responseCode;
        }
        public int addItem()
        {
            //Add a item in DB, Updates Main Inventory, Investment and Cost price. 
            // return code - 0 Sucessfull Updation
            // return code - 1 Already Item Name Exist
            // return code - 2 DB faliure Main Inv
            // return code - 3 DB faliure Cost Price
            // return code - 4 DB faliure Investment
            responseCode = 0;

            sqlQuery = "SELECT * from PKD_MAIN_INVENTORY where itemName ='" + itemName + "'";
            resultSet = conn.execSQL(sqlQuery);

            if (resultSet.Read())
            {
                responseCode = 1;
                resultSet.Close();
            }
            else
            {
                resultSet.Close();
                sqlQuery = "INSERT into PKD_MAIN_INVENTORY (itemName,totalQuantity,sellingPrice,wholesalePrice,taxPercentage,bufferCount,";
                sqlQuery = sqlQuery + "measuringUnit,vendorDetails,deleteFlag,productType) values(";
                sqlQuery = sqlQuery + "UPPER('" + itemName + "'), ";
                sqlQuery = sqlQuery + quantity + " , ";
                sqlQuery = sqlQuery + sellingPrice + " , ";
                sqlQuery = sqlQuery + wholeSalePrice + " , ";
                sqlQuery = sqlQuery + taxPercentage + " , ";
                sqlQuery = sqlQuery + buffer + " , ";
                sqlQuery = sqlQuery + measuringUnit + " , ";
                sqlQuery = sqlQuery + "'" + vendorDetails + "', ";
                sqlQuery = sqlQuery + " 0 ,";
                sqlQuery = sqlQuery + itemType + " )";

                if (conn.updateSQL(sqlQuery) < 0)
                {
                    responseCode = 2;
                    return responseCode;
                }

                if (quantity > 0)
                {
                    sqlQuery = "SELECT MAX(itemCode) from PKD_MAIN_INVENTORY";
                    resultSet=conn.execSQL(sqlQuery);
                    resultSet.Read();
                    UInt32 _itemCode = Convert.ToUInt32(resultSet[0].ToString());
                    itemCode = _itemCode; /////////////////////////May not be needed
                    resultSet.Close();

                    sqlQuery = "INSERT into PKD_COST_PRICE (itemCode,costPrice,initQuantity,currQuantity) values (";
                    sqlQuery = sqlQuery + _itemCode + " , ";
                    sqlQuery = sqlQuery + costPrice + " , ";
                    sqlQuery = sqlQuery + quantity + " , ";
                    sqlQuery = sqlQuery + quantity + ") ";

                    if (conn.updateSQL(sqlQuery) < 0)
                    {
                        responseCode = 3;
                        return responseCode;
                    }

                    sqlQuery = "SELECT MAX(itemSubCode) from PKD_COST_PRICE where itemCode = " + _itemCode;
                    resultSet = conn.execSQL(sqlQuery);
                    resultSet.Read();
                    UInt16 _itemSubCode = Convert.ToUInt16(resultSet[0].ToString());
                    resultSet.Close();

                    sqlQuery = "INSERT into PKD_INVESTMENTS (itemCode,itemSubCode,quantity,amount,notes)values(";
                    sqlQuery = sqlQuery + _itemCode + " , ";
                    sqlQuery = sqlQuery + _itemSubCode + " , ";
                    sqlQuery = sqlQuery + quantity + " , ";
                    sqlQuery = sqlQuery + quantity * costPrice + " , ";
                    sqlQuery = sqlQuery + "'Initial Entry')";

                    if (conn.updateSQL(sqlQuery) < 0)
                    {
                        responseCode = 4;
                        return responseCode;
                    }

                }
            }
            
            return responseCode;
        }

        public int modifyItem()
        {
            //Modifies A Item  Details except  CP and quantity
            // response code = 0 Sucessful Updation
            // response code = 1 Item with same name already exist
            // response code = 2 Item was not updated sucessfully

            responseCode = 0;
            sqlQuery = "SELECT itemName from PKD_MAIN_INVENTORY where itemCode <>" + itemCode + " and itemName='" + itemName + "'";
            resultSet = conn.execSQL(sqlQuery);
            if (resultSet.Read())
            {
                responseCode = 1;
                resultSet.Close();
                return responseCode;
            }
            resultSet.Close();

            sqlQuery = "UPDATE PKD_MAIN_INVENTORY set ";
            sqlQuery = sqlQuery + "itemName='" + itemName + "', ";
            sqlQuery = sqlQuery + "bufferCount=" + buffer + " , ";
            sqlQuery = sqlQuery + "measuringUnit=" + measuringUnit + " , ";
            sqlQuery = sqlQuery + "taxPercentage=" + taxPercentage + " , ";
            sqlQuery = sqlQuery + "sellingPrice=" + sellingPrice + " , ";
            sqlQuery = sqlQuery + "wholesalePrice=" + wholeSalePrice + " , ";
            sqlQuery = sqlQuery + "productType=" + itemType + " , ";
            sqlQuery = sqlQuery + "vendorDetails='" + vendorDetails + "' ";
            sqlQuery = sqlQuery + "where itemCode=" + itemCode;

            if (conn.updateSQL(sqlQuery) < 0)
            {
                responseCode = 2; vendorDetails = sqlQuery;
                return responseCode;
            }
            return responseCode;
        }

        public int UpdateCostPrice()
        {
            //Update Cost Price for any particular entry
            // return code - 0 Sucessfull Updation
            // return code - 1 Failed in Updating CP
            // return code - 2 Failed in Updating Investment

            responseCode = 0;

            sqlQuery = "UPDATE PKD_COST_PRICE set costPrice=" + costPrice + " where itemCode =" + itemCode + " and itemSubCode=" + itemSubCode;
            if (conn.updateSQL(sqlQuery) < 0)
            {
                responseCode = 1;
                return responseCode;
            }
            sqlQuery = "UPDATE PKD_INVESTMENTS set amount=" + costPrice * quantity + " where itemCode =" + itemCode + " and itemSubCode=" + itemSubCode;
            if (conn.updateSQL(sqlQuery) < 0)
            {
                responseCode = 2;
                return responseCode;
            }
            return responseCode;
        }

        public int addNewStock()
        {
            // Update Cost Price for any particular entry
            // return code - 0 Sucessfull Updation
            // return code - 1 Failed in Updating Inventory
            // return code - 2 Failed in Updating Cost PRice
            // return code - 3 Failed in Updating Investment
            responseCode = 0;
            sqlQuery = "UPDATE PKD_MAIN_INVENTORY set totalQuantity=" + quantity + " where itemCode =" + itemCode;
            if (conn.updateSQL(sqlQuery) < 0)
            {
                responseCode = 1;
                return responseCode;
            }

            sqlQuery = "INSERT into PKD_COST_PRICE (itemCode,costPrice,initQuantity,currQuantity) values(";
            sqlQuery = sqlQuery + itemCode+ ",";
            sqlQuery = sqlQuery + costPrice + ",";
            sqlQuery = sqlQuery + initQuantity + ",";
            sqlQuery=sqlQuery+ currQuantity + ")";
            if (conn.updateSQL(sqlQuery) < 0)
            {
                responseCode = 2;
                return responseCode;
            }

            sqlQuery = "SELECT MAX(itemSubCode) from PKD_COST_PRICE where itemCode = " + itemCode;
            resultSet = conn.execSQL(sqlQuery);
            resultSet.Read();
            itemSubCode = Convert.ToUInt16(resultSet[0].ToString());
            resultSet.Close();

            sqlQuery = "INSERT into PKD_INVESTMENTS (itemCode,itemSubcode,quantity,amount,notes) values(";
            sqlQuery = sqlQuery + itemCode+ " , ";
            sqlQuery = sqlQuery + itemSubCode + " , ";
            sqlQuery = sqlQuery + initQuantity + " , ";
            sqlQuery = sqlQuery + (initQuantity * costPrice) + " , ";
            sqlQuery = sqlQuery + "'AUTOENTER')";
            if (conn.updateSQL(sqlQuery) < 0)
            {
                responseCode = 3;
                return responseCode;
            }
            return responseCode;
        }

    }
    //seperate function for getting current itemcode+ subcode. 

    class StockEngine_EditSystem
    {
        private UInt16 responseCode;
        private String sqlQuery;
        private MySqlDataReader resultSet;

        private DbConn conn;
        public StockEngine_EditSystem()
        {
            conn = new DbConn();
            conn.connect();
        }
        ~StockEngine_EditSystem()
        {
            conn.disconnects();
        }

        public bool removeStock(updateStock us , decimal diff)
        {
            string mainquant = "Select totalQuantity from PKD_MAIN_INVENTORY where itemCode = " + us.icode;
            
            sqlQuery = mainquant;
            resultSet = conn.execSQL(sqlQuery);
            resultSet.Read();
            double mainq = Convert.ToDouble(resultSet["totalQuantity"]);
            resultSet.Close();
            mainq = mainq - Convert.ToDouble(diff);
            string updatemain = "UPDATE PKD_MAIN_INVENTORY set ";
            updatemain = updatemain + "totalQuantity='" + mainq + "' ";
            updatemain = updatemain + "where itemCode=" + us.icode;
            sqlQuery = updatemain;
            Console.WriteLine("UpdateMain = " + sqlQuery);
            string updatecp = "UPDATE PKD_COST_PRICE set ";
            updatecp = updatecp + "initQuantity='" + mainq + "', ";
            updatecp = updatecp + "currQuantity='" + mainq + "' ";
            updatecp = updatecp + "where itemSubCode=" + us.iscode;
            Console.WriteLine("Updatecp = " + updatecp);
            if (conn.updateSQL(sqlQuery) >= 0)
            {
                if (conn.updateSQL(updatecp) >= 0)
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;

        }

        public bool removeInvestment(updateStock us , decimal diff)
        {
            string getstockdetails = "SELECT amount from PKD_INVESTMENTS where itemSubCode = " + us.iscode;
            sqlQuery = getstockdetails;
            resultSet = conn.execSQL(sqlQuery);
            if (resultSet == null)
            {
                Console.WriteLine("Error in Select");
                return false;
            }
            resultSet.Read();
            double iamount = Convert.ToDouble(resultSet["amount"]);
            double origCP = iamount / (double)(Convert.ToDecimal(us.iquant));
            resultSet.Close();
            Console.WriteLine("OrigCP = " + origCP);
            string updateinv = "UPDATE PKD_INVESTMENTS set ";
            updateinv = updateinv + "quantity='" + us.updatequant + "', ";
            updateinv = updateinv + "amount='" + (Convert.ToDecimal(us.updatequant) * (decimal)origCP) + "' ";
            updateinv = updateinv + "where itemSubCode=" + us.iscode;
            sqlQuery = updateinv;
            Console.WriteLine(sqlQuery);
            if (conn.updateSQL(sqlQuery) >= 0)
            {
                return true;
            }
            else
                return false;

        }

        public bool addStock(updateStock us, decimal diff)
        {
            string mainquant = "Select totalQuantity from PKD_MAIN_INVENTORY where itemCode = " + us.icode;

            sqlQuery = mainquant;
            resultSet = conn.execSQL(sqlQuery);
            resultSet.Read();
            double mainq = Convert.ToDouble(resultSet["totalQuantity"]);
            resultSet.Close();
            mainq = mainq + Convert.ToDouble(diff);
            string updatemain = "UPDATE PKD_MAIN_INVENTORY set ";
            updatemain = updatemain + "totalQuantity='" + mainq + "' ";
            updatemain = updatemain + "where itemCode=" + us.icode;
            sqlQuery = updatemain;
            Console.WriteLine("UpdateMain = " + sqlQuery);
            string updatecp = "UPDATE PKD_COST_PRICE set ";
            updatecp = updatecp + "initQuantity='" + (Convert.ToDecimal(us.iquant) + diff) + "', ";
            updatecp = updatecp + "currQuantity='" + (Convert.ToDecimal(us.iquant) + diff) + "' ";
            updatecp = updatecp + "where itemSubCode=" + us.iscode;
            Console.WriteLine("Updatecp = " + updatecp);
            if (conn.updateSQL(sqlQuery) >= 0)
            {
                if (conn.updateSQL(updatecp) >= 0)
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;

        }

        public bool addInvestment(updateStock us, decimal diff)
        {
            string getstockdetails = "SELECT amount from PKD_INVESTMENTS where itemSubCode = " + us.iscode;
            sqlQuery = getstockdetails;
            resultSet = conn.execSQL(sqlQuery);
            if (resultSet == null)
            {
                Console.WriteLine("Error in Select");
                return false;
            }
            resultSet.Read();
            double iamount = Convert.ToDouble(resultSet["amount"]);
            double origCP = iamount / (double)(Convert.ToDecimal(us.iquant));
            resultSet.Close();
            Console.WriteLine("OrigCP = " + origCP);
            string updateinv = "UPDATE PKD_INVESTMENTS set ";
            updateinv = updateinv + "quantity='" + us.updatequant + "', ";
            updateinv = updateinv + "amount='" + (Convert.ToDecimal(us.updatequant) * (decimal)origCP) + "' ";
            updateinv = updateinv + "where itemSubCode=" + us.iscode;
            sqlQuery = updateinv;
            Console.WriteLine(sqlQuery);
            if (conn.updateSQL(sqlQuery) >= 0)
            {
                return true;
            }
            else
                return false;

        }
    }
}
