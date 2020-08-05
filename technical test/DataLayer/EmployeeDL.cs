using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EmployeeDL
    {
        public OracleConnection con;
        //public EmployeeDL()
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

        //~EmployeeDL()
        //{
        //    con.Close();
        //    con.Dispose();
        //    Console.WriteLine("Connected to Oracle Database {0} is closed now", con.ServerVersion);
        //}

        public Employee Add(Employee emp)
        {
           
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                string guid = Convert.ToString(Guid.NewGuid());
                string SQLStatement = "Insert into Employee values('" + guid + "', '" + emp.empname + "','" + emp.contactnumber + "','" + emp.email + "',sysdate)";
                //Console.WriteLine(SQLStatement);
                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    sqlCommandOracle.ExecuteScalar();
                }
                return Alone("EMP_ID",guid);
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
        public Employee Amend(Employee root)
        {
            return null;
        }

        public bool Abdicate(string rootid)
        {
            return true;
        }

        public List<Employee> All()
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                List<Employee> listemployee = new List<Employee>();
                string SQLStatement = "Select * from Employee";

                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        Employee objemployee = new Employee();
                        objemployee.empid = Convert.ToString(reader["EMP_ID"]);
                        objemployee.empname = Convert.ToString(reader["EMP_NAME"]);
                        objemployee.contactnumber = Convert.ToString(reader["CONTACT_NUMBER"]);
                        objemployee.email= Convert.ToString(reader["EMAIL"]);

                        listemployee.Add(objemployee);


                    }
                }


                return listemployee;
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

        public Employee Alone(string property=null, string value=null)
        {
            try
            {
                con = new OracleConnection(Constants.connectionstring);
                con.Open();
                Employee objemployee = new Employee();
                string SQLStatement = "Select * from Employee";
                if(!string.IsNullOrEmpty(property))
                    SQLStatement +=" where "+property+" ='"+value+"'";

                if (con.State.ToString().Equals("Open"))
                {
                    OracleCommand sqlCommandOracle = new OracleCommand(SQLStatement, con);
                    OracleDataReader reader = sqlCommandOracle.ExecuteReader();


                    while (reader.Read())
                    {

                        objemployee.empid = Convert.ToString(reader["EMP_ID"]);
                        objemployee.empname = Convert.ToString(reader["EMP_NAME"]);
                        objemployee.contactnumber = Convert.ToString(reader["CONTACT_NUMBER"]);
                        objemployee.email = Convert.ToString(reader["EMAIL"]);

                        


                    }
                }


                return objemployee;
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
