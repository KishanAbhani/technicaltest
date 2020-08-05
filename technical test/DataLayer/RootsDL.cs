using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataLayer
{
    public class RootsDL
    {
        public OracleConnection con;
        //public RootsDL()
        //{
        //    try
        //    {
        //        con = new OracleConnection(Constants.connectionstring);
        //        con.Open();
        //        Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error on Connection");

        //    }

        //}

        //~RootsDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public Root Add(Root root)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                string guid = Convert.ToString(Guid.NewGuid());
                string SQLStatement = "Insert into Roots values('" + guid + "', '" + root.root + "','" + root.startlocation + "','" + root.endlocation + "',sysdate)";
                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                return Alone("ROOT_ID",guid);
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            
        }
        public bool Amend(Root root)
        {
            return true;
        }

        public bool Abdicate(string rootid)
        {
            return true;
        }

        public List<Root> All()
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Root> listroot = new List<Root>();
                string SQLStatement = "Select * from Roots";
                DataSet dataSet = new DataSet();
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();
                    

                    while (reader.Read())
                    {

                        Root objroot = new Root();
                        objroot.rootid = Convert.ToString(reader["ROOT_ID"]);
                        objroot.root = Convert.ToString(reader["Root"]);
                        objroot.startlocation = Convert.ToString(reader["Start_Location"]);
                        objroot.endlocation = Convert.ToString(reader["End_Location"]);
                        listroot.Add(objroot);                         
                            
                        
                    }
                }

                
                return listroot;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Root Alone(string property = null, string value = null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Root objroot = new Root();
                string SQLStatement = "Select * from Roots";
                if (!string.IsNullOrEmpty(property))
                    SQLStatement += " where " + property + " ='" + value + "'";

                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        objroot.rootid = Convert.ToString(reader["ROOT_ID"]);
                        objroot.root = Convert.ToString(reader["Root"]);
                        objroot.startlocation = Convert.ToString(reader["Start_Location"]);
                        objroot.endlocation = Convert.ToString(reader["End_Location"]);




                    }
                }


                return objroot;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
