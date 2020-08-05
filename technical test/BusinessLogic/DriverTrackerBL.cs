using Common;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DriverTrackerBL
    {
        DriverTrackerDL drivertrackerdl = new DriverTrackerDL();
        
        /// <summary>
        /// Save driver tracker information
        /// </summary>
       
        public DriverTracker SaveDriverTracker(DriverTracker objdrivertracker)
        {
            try
            {
               
                return drivertrackerdl.Add(objdrivertracker);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// To modify driver tracker
        /// </summary>
  
        public DriverTracker EditDriverTracker(DriverTracker objdrivertracker)
        {
            try
            {

                return drivertrackerdl.Amend(objdrivertracker);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// Get drivertracers
        /// </summary>
        /// <param name="property"> Property name of drivertracker table</param>
        /// <param name="value">String value for that property</param>
        /// <returns></returns>
        public List<DriverTracker> GetAllDriverTrackers(string property = null, string value = null)
        {
            try
            {
                return drivertrackerdl.All(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get drivertrackers
        /// </summary>
        /// <param name="property"> Property name of drivertrackers table</param>
        /// <param name="value">Int value for that property</param>
        /// <returns></returns>
        public List<DriverTracker> GetAllDriverTrackers(string property = null, int value = 0)
        {
            try
            {
                return drivertrackerdl.All(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
