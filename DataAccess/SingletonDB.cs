using System;
using System.Linq;
using Finisar.SQLite;
using System.Web.Configuration;

/// <summary>
/// Summary description for SingletonDB
/// </summary>
/// 

namespace DataAccess
{
    public class SingletonDB
    {
        private static volatile SQLiteConnection SQLLiteInstance;
        private static object syncRoot = new object();
        private static string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        private static SQLiteCommand sqlite_cmd;

        private SingletonDB() { }

        public static SQLiteConnection SQLiteConnectionInstance
        {
            get
            {
                if (SQLLiteInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (SQLLiteInstance == null)
                            SQLLiteInstance = new SQLiteConnection(connectionString);
                        SQLLiteInstance.Open();

                        sqlite_cmd = SQLiteConnectionInstance.CreateCommand();
                        sqlite_cmd.CommandText = "CREATE TABLE Designation (DesignationID integer primary key, Designation varchar(100));";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "CREATE TABLE ServiceLine (ServiceLineID integer primary key, ServiceLine varchar(100));";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "CREATE TABLE Role (RoleID integer primary key, Role varchar(100));";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Designation (DesignationID,Designation) VALUES (1,'BTA/Associate Analyst');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Designation (DesignationID,Designation) VALUES (2,'Consultant');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Designation (DesignationID,Designation) VALUES (3,'Senior Consultant');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Designation (DesignationID,Designation) VALUES (4,'Manager');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  ServiceLine (ServiceLineID,ServiceLine) VALUES (1,'System Integration');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  ServiceLine (ServiceLineID,ServiceLine) VALUES (2,'Deloitte Digital');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  ServiceLine (ServiceLineID,ServiceLine) VALUES (3,'SAP');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  ServiceLine (ServiceLineID,ServiceLine) VALUES (4,'Shared Services');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  ServiceLine (ServiceLineID,ServiceLine) VALUES (5,'Application Information Management');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Role (RoleID,Role) VALUES (1,'Developer');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Role (RoleID,Role) VALUES (2,'Tester');";
                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_cmd.CommandText = "INSERT INTO  Role (RoleID,Role) VALUES (3,'Functional');";
                        sqlite_cmd.ExecuteNonQuery();
                    }
                }

                return SQLLiteInstance;
            }
        }

        public static SQLiteConnection GetDBConnection()
        {
            return SQLiteConnectionInstance;
        }
    }
}