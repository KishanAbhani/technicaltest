using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class EmployeeBL
    {
        EmployeeDL employeedl = new EmployeeDL();

        /// <summary>
        /// Save employee data
        /// </summary>
    
        public Employee SaveEmployee(Employee objemployee)
        {
            try
            {               

                return employeedl.Add(objemployee);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get employees
        /// </summary>
     
        public List<Employee> GetAllEmployees()
        {
            try
            {
                return employeedl.All();
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get employee
        /// </summary>
        /// <param name="property"> Property name of employee table</param>
        /// <param name="value">Value for that property</param>
        /// <returns></returns>
        public Employee GetEmployeeInfo(string property = null, string value = null)
        {
            try
            {
                return employeedl.Alone(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
