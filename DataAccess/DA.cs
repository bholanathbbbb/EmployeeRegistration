using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Domain;
using Finisar.SQLite;

namespace DataAccess
{

    public class DA
    {

        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private SQLiteConnection sqlite_conn;
        private SQLiteCommand sqlite_cmd;

        public DA()
        {
            sqlite_conn = SingletonDB.GetDBConnection();
        }

        public bool SignIn(User userInfo)
        {
            try
            {
                if (sqlite_conn.State == ConnectionState.Open || sqlite_conn.State == ConnectionState.Executing)
                {
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name = 'Employee';";
                    SQLiteDataReader reader = sqlite_cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string CommandText = "SELECT EmployeeNumber, Password FROM Employee";
                        DB = new SQLiteDataAdapter(CommandText, SingletonDB.GetDBConnection());
                        DS.Reset();
                        DB.Fill(DS);
                        DT = DS.Tables[0];

                        string find = "EmployeeNumber = '" + userInfo.EmployeeNumber + "' AND Password = '" + userInfo.Password + "'";
                        DataRow[] foundRows = DT.Select(find);


                        if (foundRows.Length > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }

        public bool SignUp(Employee empInfo)
        {
            try
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                if (!tableExists("Employee"))
                {
                    sqlite_cmd.CommandText = "CREATE TABLE Employee (EmployeeNumber integer primary key, EmployeeName varchar(100),Password varchar(50),Designation varchar(20), ServiceLine varchar(20),Role varchar(20));";
                    sqlite_cmd.ExecuteNonQuery();
                }

                string txtSQLQuery = "INSERT INTO  Employee (EmployeeNumber,EmployeeName,Password,Designation,ServiceLine,Role) VALUES ('" + empInfo.UserInfo.EmployeeNumber.ToString() + "','" + empInfo.EmployeeName + "','" + empInfo.UserInfo.Password + "','" + empInfo.Designation + "','" + empInfo.ServiceLine + "','" + empInfo.Role + "')";
                sqlite_cmd.CommandText = txtSQLQuery;
                sqlite_cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public List<ReferenceKey> GetReferenceValues(string val)
        {
            List<ReferenceKey> keys = new List<ReferenceKey>();
            try
            {
                string CommandText = GetReferenceQuery(val);
                DB = new SQLiteDataAdapter(CommandText, sqlite_conn);
                DS.Reset();
                DB.Fill(DS);

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    keys.Add(new ReferenceKey() { RKey = row["ID"].ToString(), RValue = row["Value"].ToString() });
                }
            }
            catch (Exception)
            {
                
                throw;
            }


            return keys;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> empsInfo = new List<Employee>();
            try
            {
                string CommandText = "SELECT EmployeeNumber, EmployeeName, Designation, ServiceLine, Role FROM Employee";
                DB = new SQLiteDataAdapter(CommandText, SingletonDB.GetDBConnection());
                DS.Reset();
                DB.Fill(DS);

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    empsInfo.Add(new Employee()
                    {
                        UserInfo = new User() { EmployeeNumber = row["EmployeeNumber"].ToString() }
                        ,
                        EmployeeName = row["EmployeeName"].ToString(),
                        Designation = row["Designation"].ToString(),
                        ServiceLine = row["ServiceLine"].ToString(),
                        Role = row["Role"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return empsInfo;
        }

        public string GetReferenceQuery(string val)
        {
            string query = string.Empty;
            try
            {

                switch (val)
                {
                    case CommonConstants.Designation:
                        query = "SELECT DesignationID AS ID, Designation AS Value FROM Designation";
                        break;
                    case CommonConstants.ServiceLine:
                        query = "SELECT ServiceLineID AS ID, ServiceLine AS Value FROM ServiceLine";
                        break;
                    case CommonConstants.Role:
                        query = "SELECT RoleID AS ID, Role AS Value FROM Role";
                        break;

                }
            }
            catch (Exception)
            {
                
                throw;
            }


            return query;
        }

        public bool tableExists(String tableName)
        {
            try
            {
                if (tableName == null)
                {
                    return false;
                }

                string CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = '" + tableName + "'";
                DB = new SQLiteDataAdapter(CommandText, sqlite_conn);
                DS.Reset();
                DB.Fill(DS);

                if (DS.Tables[0].Rows[0][0].ToString() == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
