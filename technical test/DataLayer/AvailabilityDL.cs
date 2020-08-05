using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class AvailabilityDL
    {
        public OracleConnection con;
        //public AvailabilityDL()
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

        //~AvailabilityDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public Availability Add(Availability avail)
        {

            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Guid id = Guid.NewGuid();
                string SQLStatement = "Insert into Availability values('" + id + "', '" + avail.driverid + "'," + avail.weeknumber + ",'" + avail.weekday + "'," + avail.driveravailabbility + ",sysdate)";
                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                
                return Alone("ID",Convert.ToString(id));
            }
            catch (Exception e)
            {
                return null;
                //}

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public Availability Amend(Availability availability)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();

                string SQLStatement = "Update Availability SET ";
                SQLStatement += " DRIVER_ID =" + availability.driverid;
                SQLStatement += " WEEK_NUMBER =" + availability.weeknumber;
                SQLStatement += " WEEK_DAY =" + availability.weekday;
                SQLStatement += " DRIVER_AVAILABILITY =" + availability.driveravailabbility;
                SQLStatement += " CREATE_DATE = sysdate";
                SQLStatement += " WHERE ID=" + availability.id;


                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }

                return availability;
            }
            catch (Exception e)
            {
                return null;
                //}

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool Abdicate(string rootid)
        {
            return true;
        }

        public List<Availability> All(string property = null, string value = null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Availability> listavailability = new List<Availability>();
                string SQLStatement = "Select * from Availability";
                if (!string.IsNullOrEmpty(property))
                    SQLStatement += " where " + property + " ='" + value + "'";
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Availability objavailability = new Availability();
                        objavailability.id = Convert.ToString(reader["ID"]);
                        objavailability.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objavailability.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objavailability.weekday = Convert.ToString(reader["WEEK_DAY"]);
                        objavailability.driveravailabbility = Convert.ToInt16(reader["DRIVER_AVAILABILITY"]);
                        
                        listavailability.Add(objavailability);


                    }
                }
               

                return listavailability;
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

        public List<Availability> All(string property = null, int value = 0)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Availability> listavailability = new List<Availability>();
                string SQLStatement = "Select * from Availability";
                if (!string.IsNullOrEmpty(property))
                    SQLStatement += " where " + property + " =" + value;
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Availability objavailability = new Availability();
                        objavailability.id = Convert.ToString(reader["ID"]);
                        objavailability.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objavailability.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objavailability.weekday = Convert.ToString(reader["WEEK_DAY"]);
                        objavailability.driveravailabbility = Convert.ToInt16(reader["DRIVER_AVAILABILITY"]);
                        
                        listavailability.Add(objavailability);


                    }
                }

                
                return listavailability;
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

        public Availability Alone(string property = null, string value = null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Availability objavailability = new Availability();
                string SQLStatement = "Select * from Availability";
                if (!string.IsNullOrEmpty(property))
                    SQLStatement += " where " + property + " ='" + value + "'";
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        
                        objavailability.id = Convert.ToString(reader["ID"]);
                        objavailability.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objavailability.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objavailability.weekday = Convert.ToString(reader["WEEK_DAY"]);
                        objavailability.driveravailabbility = Convert.ToInt16(reader["DRIVER_AVAILABILITY"]);
                        
                        

                    }
                }

                
                return objavailability;
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

        public Availability Alone(string property = null, int value = 0)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Availability objavailability = new Availability();
                string SQLStatement = "Select * from Availability";
                if (!string.IsNullOrEmpty(property))
                    SQLStatement += " where " + property + " =" + value;
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {


                        objavailability.id = Convert.ToString(reader["ID"]);
                        objavailability.driverid = Convert.ToString(reader["DRIVER_ID"]);
                        objavailability.weeknumber = Convert.ToInt16(reader["WEEK_NUMBER"]);
                        objavailability.weekday = Convert.ToString(reader["WEEK_DAY"]);
                        objavailability.driveravailabbility = Convert.ToInt16(reader["DRIVER_AVAILABILITY"]);



                    }
                }


                return objavailability;
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
