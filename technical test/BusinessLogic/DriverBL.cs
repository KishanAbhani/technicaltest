using Common;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;

using System.Text;

namespace BusinessLogic
{
    public class DriverBL
    {
        DriverDL driverdl = new DriverDL();
        #region Business call
        EmployeeBL employeebl = new EmployeeBL();
        #endregion

        /// <summary>
        /// Save driver information
        /// </summary>     
        
        public Driver SaveDriver(string empid, string rootid)
        {
            try
            {
                Driver objdriver = new Driver();
                objdriver.empid = empid;
                objdriver.rootid = rootid;

                return driverdl.Add(objdriver);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Select driver randomly
        /// </summary>
        /// <param name="routeid">Selected route</param>
        
        public List<Driver> SelectDriverAuto(string routeid)
        {
            List<Driver> lstdriver = driverdl.All("ROOT_ID", routeid);
            
            if (lstdriver == null || lstdriver.Count < 1 )
            {
                lstdriver = AssignDriverFirstTime(routeid);
            }

            return lstdriver.GetRange(index: 0, count: Constants.driversperroute);

        }

        /// <summary>
        /// Assign driver randomly for selected route
        /// </summary>
        /// <param name="routeid">Selected route</param>
        
        public List<Driver> AssignDriverFirstTime(string routeid)
        {
            List<Driver> lstdriver = new List<Driver>();
            int count = 0;
            List<Employee> lstemployee = new List<Employee>();
            lstemployee = employeebl.GetAllEmployees();
            foreach(Employee emp in lstemployee)
            {
                if (count < Constants.driversperroute)
                    break;
                Driver driver = driverdl.Alone("EMP_ID", emp.empid);
                if (driver == null || driver.driverid == null )
                {

                    if (SaveDriver(emp.empid, routeid) != null)
                        count++;
                    else
                        Console.WriteLine("Error while saving driver information.");
                }
             
            }
            return driverdl.All("ROOT_ID", routeid).GetRange(index:0,count:Constants.driversperroute);

        }

        /// <summary>
        /// Get Drivers
        /// </summary>
        /// <param name="property"> Property name of driver table</param>
        /// <param name="value">Value for that property</param>
        /// <returns></returns>
        public List<Driver> GetAllDrivers(string property=null, string value=null)
        {
            try
            {
                return driverdl.All(property, value);
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get driver
        /// </summary>
        /// <param name="property"> Property name of driver table</param>
        /// <param name="value">Value for that property</param>
        /// <returns></returns>
        public Driver GetDriverInfo(string property = null, string value = null)
        {
            try
            {
                return driverdl.Alone(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
