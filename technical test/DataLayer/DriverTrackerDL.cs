using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DriverTrackerDL
    {
        public OracleConnection con;
        //public DriverTrackerDL()
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

        //~DriverTrackerDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public DriverTracker Add(DriverTracker drivertrack)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                string guid = Convert.ToString(Guid.NewGuid());
                string SQLStatement = "Insert into DriverTracker values('" + guid + "', " + drivertrack.weeknumber + ",'" + drivertrack.driverid + "','" + drivertrack.scheduleid + "'," + drivertrack.shiftid     + "," + drivertrack.totaltrip + "," + drivertrack.daytrip + "," + drivertrack.nighttrip + ",'" + drivertrack.weekday + "',sysdate)";
                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                return Alone("TRACK_ID",guid);
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }



        public DriverTracker Amend(DriverTracker drivertrack)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
               
                string SQLStatement = "Update DriverTracker SET ";
                SQLStatement += " WEEK_NUMBBER =" + drivertrack.weeknumber;
                SQLStatement += " DRIVER_ID =" + drivertrack.driverid;
                SQLStatement += " SCHEDULE_ID =" + drivertrack.scheduleid;
                SQLStatement += " SHIFT_ID =" + drivertrack.shiftid;
                SQLStatement += " TOTALTRIP = "+ drivertrack.totaltrip;
                SQLStatement += " DAYTRIP =" + drivertrack.daytrip;
                SQLStatement += " NIGHTTRIP =" + drivertrack.nighttrip;
                SQLStatement += " WEEK_DAY =" + drivertrack.weekday;
                SQLStatement += " CREATE_DATE = sysdate";
                SQLStatement += " WHERE ID=" + drivertrack.trackid;

                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                return drivertrack;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool Abdicate(string drivertrackerid)
        {
            return true;
        }

        public List<DriverTracker> All(string property = null, string value = null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<DriverTracker> listdriver = new List<DriverTracker>();
                string SQLStatement = "Select * from DriverTracker";
                if (property != null)
                    SQLStatement += " where " + property + " ='" + value + "'";
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        DriverTracker objdrivertracker = new DriverTracker();
                        objdrivertracker.trackid = Convert.ToString(reader["TRACK_ID"]);
                        objdrivertracker.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objdrivertracker.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objdrivertracker.scheduleid = Convert.ToString(reader["SCHEDULE_ID"]);
                        objdrivertracker.totaltrip = Convert.ToInt16(reader["TOTALTRIP"]);
                        objdrivertracker.daytrip = Convert.ToInt16(reader["DAYTRIP"]);
                        objdrivertracker.nighttrip = Convert.ToInt16(reader["NIGHTTRIP"]);
                        objdrivertracker.weekday = Convert.ToString(reader["WEEK_DAY"]);

                        listdriver.Add(objdrivertracker);


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
            }
        }

        public List<DriverTracker> All(string property = null, int value = 0)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<DriverTracker> listdriver = new List<DriverTracker>();
                string SQLStatement = "Select * from DriverTracker";
                if (property != null)
                    SQLStatement += " where " + property + " =" + value;
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        DriverTracker objdrivertracker = new DriverTracker();
                        objdrivertracker.trackid = Convert.ToString(reader["TRACK_ID"]);
                        objdrivertracker.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objdrivertracker.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objdrivertracker.scheduleid = Convert.ToString(reader["SCHEDULE_ID"]);
                        objdrivertracker.totaltrip = Convert.ToInt16(reader["TOTALTRIP"]);
                        objdrivertracker.daytrip = Convert.ToInt16(reader["DAYTRIP"]);
                        objdrivertracker.nighttrip = Convert.ToInt16(reader["NIGHTTRIP"]);
                        objdrivertracker.weekday = Convert.ToString(reader["WEEK_DAY"]);

                        listdriver.Add(objdrivertracker);


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
            }
        }
        public DriverTracker Alone(string property, string value)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                string SQLStatement = "Select * from DriverTracker";
                if (property != null)
                    SQLStatement += " where " + property + " ='" + value + "'";
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        DriverTracker objdrivertracker = new DriverTracker();
                        objdrivertracker.trackid = Convert.ToString(reader["TRACK_ID"]);
                        objdrivertracker.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objdrivertracker.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objdrivertracker.scheduleid = Convert.ToString(reader["SCHEDULE_ID"]);
                        objdrivertracker.totaltrip = Convert.ToInt16(reader["TOTALTRIP"]);
                        objdrivertracker.daytrip = Convert.ToInt16(reader["DAYTRIP"]);
                        objdrivertracker.nighttrip = Convert.ToInt16(reader["NIGHTTRIP"]);
                        objdrivertracker.weekday = Convert.ToString(reader["WEEK_DAY"]);

                        return objdrivertracker;


                    }
                }


                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
