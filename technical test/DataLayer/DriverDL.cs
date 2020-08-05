using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DriverDL
    {
        public OracleConnection con;
        //public DriverDL()
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

        //~DriverDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public Driver Add(Driver driver)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                string guid = Convert.ToString(Guid.NewGuid());
                string SQLStatement = "Insert into Drivers values('" + guid + "', '" + driver.empid + "','" + driver.rootid + "',sysdate)";
                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                return Alone("DRIVER_ID",guid);
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
        public Driver Amend(Driver driver)
        {
            return null;
        }

        public bool Abdicate(string driverid)
        {
            return true;
        }

        public List<Driver> All(string property = null, string value = null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Driver> listdriver = new List<Driver>();
                string SQLStatement = "Select * from Drivers ";
                if (property != null)
                    SQLStatement += " where " + property + " ='" + value + "'";
                
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Driver objdriver = new Driver();
                        objdriver.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objdriver.empid = Convert.ToString(reader["EMP_ID"]);
                        objdriver.rootid = Convert.ToString(reader["ROOT_ID"]);

                        listdriver.Add(objdriver);


                    }
                }


                return listdriver;
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

        public List<Driver> All(string property = null, int value = 0)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Driver> listdriver = new List<Driver>();
                string SQLStatement = "Select * from Drivers ";
                if (property != null)
                    SQLStatement += " where " + property + " =" + value ;

                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Driver objdriver = new Driver();
                        objdriver.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objdriver.empid = Convert.ToString(reader["EMP_ID"]);
                        objdriver.rootid = Convert.ToString(reader["ROOT_ID"]);

                        listdriver.Add(objdriver);


                    }
                }


                return listdriver;
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
        public Driver Alone(string property, string value)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Driver objdriver = new Driver();
                string SQLStatement = "Select * from Drivers ";
                if (property != null)
                    SQLStatement += " WHERE " + property + " ='" + value + "'";

                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {
                        objdriver.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objdriver.empid = Convert.ToString(reader["EMP_ID"]);
                        objdriver.rootid = Convert.ToString(reader["ROOT_ID"]);
                    }
                }


                return objdriver;
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
