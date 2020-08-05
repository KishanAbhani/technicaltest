using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ScheduleDL
    {
        public OracleConnection con;
        //public ScheduleDL()
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

        //~ScheduleDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public Schedule Add(Schedule schedule)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                string SQLStatement = "Insert into Schedules values('" + schedule.scheduleid + "', " + schedule.week + ",sysdate)";
                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                return schedule;
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
        public Schedule Amend(Schedule schedule)
        {
            return null;
        }

        public bool Abdicate(string rootid)
        {
            return true;
        }

        public List<Schedule> All(string property = null, string value = null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Schedule> listschedule = new List<Schedule>();
                string SQLStatement = "Select * from Schedules";
                if (property != null)
                    SQLStatement += " where " + property + " ='" + value + "'";
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Schedule objschedule = new Schedule();
                        objschedule.scheduleid = Convert.ToString(reader["SCHEDULE_ID"]);
                        objschedule.week = Convert.ToInt16(reader["WEEK"]);
                        
                        

                        listschedule.Add(objschedule);


                    }
                }


                return listschedule;
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

        public Schedule Alone(string property, string value)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Schedule objschedule = new Schedule();
                string SQLStatement = "Select * from Schedules where " + property + " ='" + value + "'";

                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {
                        objschedule.scheduleid = Convert.ToString(reader["SCHEDULE_ID"]);
                        objschedule.week = Convert.ToInt16(reader["WEEK_DAY"]);
                        
                        
                    }
                }


                return objschedule;
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

        public List<Result> AllData(int weeknumber =0)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Result> listschedule = new List<Result>();
                if (weeknumber == 0)
                    weeknumber = Constants.week;
                string SQLStatement = "select Employee.EMP_NAME, DRIVERTRACKER.WEEK_DAY, SHIFT.SHIFT  from DRIVERTRACKER";
                        SQLStatement += " join DRIVERS on DRIVERS.DRIVER_ID = DRIVERTRACKER.DRIVER_ID ";
                        SQLStatement += " join Employee on Employee.EMP_ID = DRIVERS.EMP_ID ";
                        SQLStatement += " join SHIFT on SHIFT.shift_id = DRIVERTRACKER.SHIFT_ID Where WEEK_NUMBBER =" + weeknumber;
                        SQLStatement += " ORDER BY ";
                        SQLStatement += " CASE";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Sunday' THEN 1";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Monday' THEN 2";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Tuesday' THEN 3";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Wednesday' THEN 4";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Thursday' THEN 5";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Friday' THEN 6";
                        SQLStatement += " WHEN DRIVERTRACKER.WEEK_DAY = 'Saturday' THEN 7";
                        SQLStatement += " END ASC";


                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Result objresult = new Result();
                        objresult.fullname = Convert.ToString(reader["EMP_NAME"]);
                        objresult.weekday = Convert.ToString(reader["WEEK_DAY"]);
                        objresult.shift = Convert.ToString(reader["SHIFT"]);



                        listschedule.Add(objresult);


                    }
                }


                return listschedule;
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
