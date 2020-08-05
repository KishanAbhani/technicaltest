using Common;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ScheduleBL
    {
        ScheduleDL scheduledl = new ScheduleDL();

        #region Business call
        EmployeeBL employeebl = new EmployeeBL();
        DriverBL driverbl = new DriverBL();
        ShiftBL shiftbl = new ShiftBL();
        AvailabilityBL availabilitybl = new AvailabilityBL();
        DriverTrackerBL drivertrackerbl = new DriverTrackerBL();
        #endregion

        /// <summary>
        /// Create schedule for current week
        /// </summary>
        /// <param name="lstdriver"> List of all drivers</param>
        /// <param name="routeid"> Selected root </param>
        /// <returns></returns>
        public List<Schedule> CreateSchedule(List<Driver> lstdriver, string routeid)
        {
            try
            {
                int initialvalue = 0;

                Schedule objschedule = new Schedule();
                List<Schedule> lstschedule = new List<Schedule>();
                List<Shift> lstshift = new List<Shift>();
                List<DriverTracker> lstdrivertrackers = new List<DriverTracker>();
                List<DriverTracker> alldrivertrackers = new List<DriverTracker>();
                List<Availability> availability = new List<Availability>();

                lstshift = shiftbl.GetAllShift();

                // DriverTracker : All inforamtion for that driver like driver route, driver shift, etc;
                alldrivertrackers = drivertrackerbl.GetAllDriverTrackers("WEEK_NUMBBER", Constants.week);

                //If user selected auto option at that time we assign driver and availability randomly.
                if (lstdriver == null || lstdriver.Count < 1)
                {
                    lstdriver = driverbl.SelectDriverAuto(routeid);
                    if(lstdriver == null || lstdriver.Count <1 )
                    {
                        Console.WriteLine("There are no enough driver to assign for this route");
                        return null;
                    }
                    foreach (Driver drv in lstdriver)
                    {
                        if (!availabilitybl.SaveAvailabilityAuto(drv.empid))
                            Console.WriteLine("Error while inserting availabbility");

                    }

                }

                //Get availability for each driver for each day so we can assign shift according to that
                availability = availabilitybl.GetAllAvailabilities("WEEK_NUMBER", Constants.week);

                // Create Schedule and use this schedule id in drivertracker table
                string scheduleid = Convert.ToString(Guid.NewGuid());                
                objschedule.scheduleid = scheduleid;
                objschedule.week = Constants.week;
                scheduledl.Add(objschedule);

                //Assign driver for current week on their availability
                foreach (Driver driver in lstdriver)
                {
                    foreach (Shift shift in lstshift.FindAll(x => x.shiftid < 10)) // we need to assign first shift and second shift only
                    {
                        for (int i = initialvalue; i < Constants.days.Length; i++)
                        {
                            if (Array.IndexOf(Constants.holidays, Constants.days[i]) < 0) // To skip holiday
                            {

                                // If we have already asign that driver and want to modify their shift 
                                DriverTracker drivertracker = (alldrivertrackers!=null)? alldrivertrackers.Find(x => x.driverid == driver.driverid
                                                                && x.shiftid == shift.shiftid
                                                                && x.weekday == Constants.days[i]) : null;

                                // Get driver availability for that day
                                Availability avail = new Availability();
                                avail = availability.Find(x => x.weekday == Constants.days[i] && x.driverid == driver.driverid);

                                /* A driver cannot work more than one shift in a day.
                                 * The schedules should be randomly generated to ensure fairness.
                                 * A driver can only work a maximum of two shifts per week.
                                 */

                                if (!(lstdrivertrackers.Exists(x => x.weeknumber == Constants.week && x.weekday == Constants.days[i] && x.shiftid == shift.shiftid))
                                    && (avail.driveravailabbility == lstshift.Find(x => x.shift.ToUpper() == "ALL").shiftid
                                    || avail.driveravailabbility == shift.shiftid)
                                    && !(lstdrivertrackers.Exists(x => x.driverid == driver.driverid
                                                                      && x.weeknumber == Constants.week
                                                                      && (x.weekday == Constants.days[i] || x.shiftid == shift.shiftid))))
                                {


                                    if (!string.IsNullOrEmpty(objschedule.scheduleid))
                                    {
                                        if(drivertracker == null)
                                        {
                                            drivertracker = new DriverTracker();
                                            drivertracker.scheduleid = scheduleid;
                                            drivertracker.weeknumber = Constants.week;
                                            drivertracker.driverid = driver.driverid;
                                            drivertracker.shiftid = shift.shiftid;
                                            drivertracker.totaltrip = 2;
                                            drivertracker.weekday = Constants.days[i];
                                            drivertrackerbl.SaveDriverTracker(drivertracker);
                                        }
                                        else
                                        {
                                            drivertracker.scheduleid = scheduleid;
                                            drivertracker.weeknumber = Constants.week;
                                            drivertracker.driverid = driver.driverid;
                                            drivertracker.shiftid = shift.shiftid;
                                            drivertracker.totaltrip = 2;
                                            drivertracker.weekday = Constants.days[i];
                                            drivertrackerbl.EditDriverTracker(drivertracker);

                                        }
                                        
                                        lstdrivertrackers.Add(drivertracker);
                                        

                                    }
                                    initialvalue = i;
                                    break;

                                }
                                else if (lstdrivertrackers.Count == (Constants.days.Length - Constants.holidays.Length) * Constants.maxshift)
                                    break;
                            }


                            if (i == Constants.days.Length -1)
                            {
                                i = 0;
                                initialvalue = 0;
                            }                               
                            
                                
                        }


                    }
                }



                return scheduledl.All("SCHEDULE_ID", Convert.ToString(scheduleid));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get all schedules
        /// </summary>
        /// <returns></returns>
        public List<Schedule> GetAllSchedule()
        {
            try
            {
                return scheduledl.All();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get schedule result in formate
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public List<Result> GetTable(int week)
        {
            try
            {
                return scheduledl.AllData(week);

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
