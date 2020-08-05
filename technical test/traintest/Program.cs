using System;
using System.Collections.Generic;
using BusinessLogic;
using Common;
using Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
namespace traintest
{
    class Program
    {

        static string root, startlocation, endlocation,empname,contact,email;

        #region Call Business Class
        static RootsBL objrootbl = new RootsBL();
        static EmployeeBL objemployeebl = new EmployeeBL();
        static AvailabilityBL availabilitybl = new AvailabilityBL();
        static DriverBL driverbl = new DriverBL();
        static ScheduleBL schedulebl = new ScheduleBL();
        #endregion
        static void Main(string[] args)
        {
            string selopt=null;
            try
            {
                while(selopt!="0")
                {
                    Console.WriteLine("select below options.");
                    Console.WriteLine("1 Add Roots");
                    Console.WriteLine("2 Add Employees");
                    Console.WriteLine("3 Show Roots");
                    Console.WriteLine("4 Show Current week Timetable");                   
                    Console.WriteLine("0 Exit");

                    selopt = Console.ReadLine();
                    switch (selopt)
                    {
                        case "1":
                            SaveRootsInfo();
                            break;
                        case "2":
                            SaveEmployeeInfo();
                            break;
                        case "3":
                            ShowRoots();
                            break;
                        case "4":
                            GetTable(Constants.week -1);
                            break;
                        default:
                            Console.WriteLine("Please select valid option");
                            break;

                    }                    
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
                Console.ReadKey();
            }
        }
        /// <summary>
        /// To ask route information from user
        /// </summary>
        public static void GetRootsInfo()
        {
            Console.Write("Enter the root name: ");
            root = Console.ReadLine();
            Console.Write("Enter the start location: ");
            startlocation = Console.ReadLine();
            Console.Write("Enter the end location: ");
            endlocation = Console.ReadLine();
        }

        /// <summary>
        /// To ask employee information from user
        /// </summary>
        public static void GetEmployeeInfo()
        {
            Console.Write("Enter the employee name: ");
            empname = Console.ReadLine();
            Console.Write("Enter the contact name: ");
            contact = Console.ReadLine();
            Console.Write("Enter the email: ");
            email = Console.ReadLine();
        }

        /// <summary>
        /// To save data in root table
        /// </summary>
        public static void SaveRootsInfo()
        {
            int numroot;
            Console.Write("Enter how many roots you want to enter: ");
            numroot =Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<numroot; i++)
            {
                GetRootsInfo();
                Root objroot = new Root();
                objroot.root = root;
                objroot.startlocation = startlocation;
                objroot.endlocation = endlocation;
                if (objrootbl.SaveRoot(objroot) != null)
                    Console.WriteLine("Root Added Successful");
                else
                    Console.WriteLine("Error while adding Root");
            }
            
        }
        /// <summary>
        /// To save Employee
        /// </summary>
        public static void SaveEmployeeInfo()
        {
            int numemp;
            Console.Write("Enter howmany Employee you want to enter: ");
            numemp = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numemp; i++)
            {
                GetEmployeeInfo();
                Employee objemployee = new Employee();
                objemployee.empname = empname;
                objemployee.contactnumber = contact;
                objemployee.email = email;
                if (objemployeebl.SaveEmployee(objemployee) != null)
                    Console.WriteLine("Employee Added Successful");
                else
                    Console.WriteLine("Error while adding Employee");
            }

        }

        public static void ShowRoots()
        {
            
            List<Root> lstroot = new List<Root>();
            lstroot = objrootbl.GetAllRoots();
            string rootname;
            for(int i=0; i<lstroot.Count; i++)
            {
                Console.WriteLine("{0} : {1} : {2}", lstroot[i].root, lstroot[i].startlocation, lstroot[i].endlocation);
            }
            Console.WriteLine("Do you want to assign Drivers for any root?");
            Console.WriteLine("Yes or No");
            if(Console.ReadLine().ToUpper() == "YES")
            {
                Console.WriteLine("Please enter route name.");
                rootname = Console.ReadLine().ToUpper();                
                if(lstroot.Exists(x=>x.root.ToUpper() == rootname))
                {
                    ShowEmployee(lstroot.Find(x=>x.root.ToUpper() == rootname).rootid);
                }
                

            }
        }
        /// <summary>
        /// To show employee 
        /// </summary>
        /// <param name="rootid">To allow select driver for selected root</param>
        public static void ShowEmployee(string rootid)
        {
            List<Employee> lstemp = new List<Employee>();
            
            List<Availability> availability = new List<Availability>();
            
            lstemp = objemployeebl.GetAllEmployees();
            for (int i = 0; i < lstemp.Count; i++)
            {
                Console.WriteLine("{0} : {1} : {2} ",lstemp[i].empname, lstemp[i].contactnumber, lstemp[i].email);
            }

            SetDriverAvailability(lstemp, rootid);

        }
        /// <summary>
        /// Set availability for given driver
        /// </summary>
        /// <param name="lstemp"> List of employee name</param>
        /// <param name="rootid"> Selected root </param>
        public static void SetDriverAvailability(List<Employee> lstemp,string rootid)
        {
            
            List<Driver> lstdrivers = new List<Driver>();
            List<Driver> lstnewassigndriver = new List<Driver>();
            string drvname;
            bool isshow= false;
            int count = Constants.driversperroute;
            string[] name = new string[count];
            lstdrivers = driverbl.GetAllDrivers();
            
            Console.WriteLine("Enter the name of any {0} drivers one by one follow by enter key or type auto to select automatically",Constants.driversperroute);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter {0} name=>", i + 1);
                drvname = Console.ReadLine();
                if (lstemp.Exists(x => x.empname == drvname))
                {
                    name[i] = lstemp.Find(x => x.empname == drvname).empid;
                    Driver driver = (lstdrivers != null)? lstdrivers.Find(x => x.empid == name[i]) : null;
                    if(driver != null && driver.rootid != rootid)
                    {
                        Console.WriteLine("Given driver already asigned for another route");
                        Console.WriteLine("Please type exit to Exit from the loop");
                        i--;
                        continue;
                       
                    }
                    else if(driver == null)
                    {
                        driver = driverbl.SaveDriver(name[i], rootid);
                    }
                    lstnewassigndriver.Add(driver);
                    string[] avail = { "first shift", "second shift", "ALL" };
                    Console.WriteLine("Please enter driver availability");
                    Console.WriteLine("1. First Shift");
                    Console.WriteLine("2. Second Shift");
                    Console.WriteLine("12. ALL");
                    for (int daycount = 0; daycount < Constants.days.Length; daycount++)
                    {

                        if (Array.IndexOf(Constants.holidays, Constants.days[daycount]) < 0)
                        {
                            Console.WriteLine("Enter avilability for {0}", Constants.days[daycount]);
                            int ans = Convert.ToInt16(Console.ReadLine());
                            availabilitybl.SaveAvailability(driver.driverid, Constants.days[daycount], ans);
                        }
                    }

                    isshow = true;

                }
                else if (drvname.ToUpper() == "AUTO" && i == 0)
                {
                    isshow = true;
                    break;
                }
                else if (drvname.ToUpper() == "EXIT")
                {
                    break;
                }                   
                else
                {
                    i--;
                    Console.WriteLine("Enter Valid driver name or if you want to exit type exit");
                }

            }
            if (isshow)
            {
                Console.WriteLine("Would you like to create schedule?");
                Console.WriteLine("Give answer by typing Yes or No");
                if (Console.ReadLine().ToUpper() == "YES")
                    CreateSchedule(lstnewassigndriver, rootid);
            }
                



        }
        /// <summary>
        /// Create schedule
        /// </summary>
        /// <param name="lstdrivers"> List of all driver for selected route</param>
        /// <param name="rootid"> Selected root</param>
        public static void CreateSchedule(List<Driver> lstdrivers,string rootid)
        {
            
            schedulebl.CreateSchedule(lstdrivers, rootid);
            GetTable(Constants.week);
            Constants.week += 1;
        }
        /// <summary>
        /// Get schedule for current week
        /// </summary>
        /// <param name="week">Week number</param>
        public static void GetTable(int week)
        {
            List<Result> lstresult=schedulebl.GetTable(week);
            if(lstresult == null || lstresult.Count <0)
            {
                Console.WriteLine("There is no schedule for this week");
            }
            else
            {
                Console.WriteLine("Full Name : Week Day : Shift ");
                for (int i = 0; i < lstresult.Count; i++)
                {
                    Console.WriteLine("{0} : {1} : {2} ", lstresult[i].fullname, lstresult[i].weekday, lstresult[i].shift);
                }
            }
          
        }
    }
}
