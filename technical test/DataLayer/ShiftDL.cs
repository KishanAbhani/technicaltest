using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ShiftDL
    {
        public OracleConnection con;
        //public ShiftDL()
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

        //~ShiftDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public Shift Add(Shift shift)
        {
            return null;
            //try
            //{
            //    string SQLStatement = "Insert into Roots values('" + Guid.NewGuid() + "', '" + root.root + "','" + root.startlocation + "','" + root.endlocation + "')";
            //    //Console.WriteLine(SQLStatement);
            //    if (con.State.ToString().Equals("Open"))
            //    {
            //        OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
            //        sqlCommandOracle.ExecuteScalar();
            //    }
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}

        }
        public bool Amend(Root root)
        {
            return true;
        }

        public bool Abdicate(string rootid)
        {
            return true;
        }

        public List<Shift> All()
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Shift> listshift = new List<Shift>();
                string SQLStatement = "Select * from Shift";
                
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Shift objshift = new Shift();
                        objshift.shiftid = Convert.ToInt16(reader["SHIFT_ID"]);
                        objshift.shift = Convert.ToString(reader["SHIFT"]);
                        objshift.starttime = Convert.ToInt16(reader["START_TIME"]);
                        objshift.startperiod = Convert.ToString(reader["START_PERIOD"]);
                        objshift.endtime = Convert.ToInt16(reader["END_TIME"]);
                        objshift.endperiod = Convert.ToString(reader["END_PERIOD"]);
                        listshift.Add(objshift);


                    }
                }

                
                return listshift;
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

        public Root Alone(string rootid)
        {
            return null;
        }
    }
}
