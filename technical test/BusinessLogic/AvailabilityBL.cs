using Common;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AvailabilityBL
    {
        AvailabilityDL availabilitydl = new AvailabilityDL();
        #region Business call
        DriverBL driverbl = new DriverBL();
        ShiftBL shiftbl = new ShiftBL();
        #endregion

        /// <summary>
        /// Assign availability randomly 
        /// </summary>
        /// <param name="empid">Selected employee</param>
        /// <returns></returns>
        public bool SaveAvailabilityAuto(string empid)
        {
            try
            {
                List<Availability> lstavailabilities = availabilitydl.All("WEEK_NUMBER", Constants.week);
                
                for (int i = 0; i < Constants.days.Length; i++)
                {
                    if (Array.IndexOf(Constants.holidays, Constants.days[i]) < 0)
                    {
                        string driverid = driverbl.GetDriverInfo("EMP_ID", empid).driverid;
                        Availability objavail = (lstavailabilities != null) ? lstavailabilities.Find(x => x.driverid == driverid && x.weeknumber == Constants.week) : null;
                        if (objavail == null)
                        {
                            objavail = new Availability();
                            objavail.driverid = driverid;
                            objavail.weeknumber = Constants.week;
                            objavail.weekday = Constants.days[i];
                            objavail.driveravailabbility = shiftbl.GetAllShift().Find(x => x.shift.ToUpper() == "ALL").shiftid;
                            availabilitydl.Add(objavail);
                        }
                        else
                        {
                            objavail.driverid = driverid;
                            objavail.weeknumber = Constants.week;
                            objavail.weekday = Constants.days[i];
                            objavail.driveravailabbility = shiftbl.GetAllShift().Find(x => x.shift.ToUpper() == "ALL").shiftid;
                            availabilitydl.Amend(objavail);
                        }
                            
                        

                    }
                }
               
                return true ;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Set Availability for selected driver
        /// </summary>
        /// <param name="driverid">Selected driver</param>
        /// <param name="day"> Day like Monday, Sunday, etc</param>
        /// <param name="driveravailabbility">Driver availability for a day</param>
        /// <returns></returns>
        public bool SaveAvailability(string driverid, string day, int driveravailabbility = (int)Constants.Available.Both)
        {
            try
            {
                Availability objavail = new Availability();
                

                        objavail.driverid = driverid;
                        objavail.weeknumber = Constants.week;
                        objavail.weekday = day;
                        if (driveravailabbility == (int)Constants.Available.Both)
                            driveravailabbility = shiftbl.GetAllShift().Find(x => x.shift.ToUpper() == "ALL").shiftid;
                        else if (driveravailabbility == (int)Constants.Available.FirstHalf)
                            driveravailabbility = shiftbl.GetAllShift().Find(x => x.shift.ToUpper() == "FIRST SHIFT").shiftid;
                        else if (driveravailabbility == (int)Constants.Available.SecondHalf)
                            driveravailabbility = shiftbl.GetAllShift().Find(x => x.shift.ToUpper() == "SECOND SHIFT").shiftid;
                        else
                            driveravailabbility = 0;
                        objavail.driveravailabbility = driveravailabbility;


                availabilitydl.Add(objavail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Get availabilities
        /// </summary>
        /// <param name="property"> Property name of availability table</param>
        /// <param name="value">String value for that property</param>
        /// <returns></returns>
        public List<Availability> GetAllAvailabilities(string property = null, string value = null)
        {
            try
            {
                return availabilitydl.All(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get availabilities
        /// </summary>
        /// <param name="property"> Property name of availability table</param>
        /// <param name="value">Int value for that property</param>
        /// <returns></returns>
        public List<Availability> GetAllAvailabilities(string property = null, int value = 0)
        {
            try
            {
                return availabilitydl.All(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get availability
        /// </summary>
        /// <param name="property"> Property name of availability table</param>
        /// <param name="value">Value for that property</param>
        /// <returns></returns>
        public Availability GetAvilabilityInfo(string property = null, string value = null)
        {
            try
            {
                return availabilitydl.Alone(property, value);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
