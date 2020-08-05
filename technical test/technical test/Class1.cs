using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace technical_test
{
    class Class1
    {
        static void Main(string[] args)
        {
            try
            {
                string constr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=foston.bournemouth.ac.uk)(PORT=1968))(CONNECT_DATA=(SERVICE_NAME=s5229658.bournemouth.ac.uk)));User Id=s5229658;Password=Winter123";
                string table = "";
                OracleConnection con = new OracleConnection(constr);
                con.Open();
                Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
                // con.Dispose();
                Console.Write("Enter the table name: ");
                table = Console.ReadLine();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM " + table;
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("" + reader.GetString(0));
                }
                Console.WriteLine("Press RETURN to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
                Console.ReadKey();
            }
        }
    }
}