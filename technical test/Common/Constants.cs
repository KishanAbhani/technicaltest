using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Constants
    {
        //Connection String
        public static string connectionstring = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=foston.bournemouth.ac.uk)(PORT=1968))(CONNECT_DATA=(SERVICE_NAME=s5229658.bournemouth.ac.uk)));User Id=s5229658;Password=Winter123";
        // Mention all holiday in a week
        public static string[] holidays = { "Sunday", "Saturday" };
        public static string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        //There are five drivers assigned to a route, to create a schedule you need to have all
        //five drivers assigned to that route
        public static int driversperroute = 5;
        //Week number
        public static int week = 1;
        public static int maxshift = 4;
        public static int maxtrippershift = 2;
        public static int dayshift = 2;
        public static int nightshift = 2;
        //Available for driver
        public enum Available
        {
            Leave = 0,
            FirstHalf = 1,
            SecondHalf = 2,
            Both = 12
        }
    }
    public class ShiftType
    {
        public const string FirstShift = "first shift";
        public const string SecondShift = "second shift";
    }
}
