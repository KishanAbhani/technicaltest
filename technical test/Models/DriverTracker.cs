using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DriverTracker
    {
        private string _TRACKID;
        private int _WEEKNUMBER;
        private string _DRIVERID;
        private string _SCHEDULEID;
        private int _SHIFTID;
        private int _TOTALTRIP;
        private int _DAYTRIP;
        private int _NIGHTTRIP;
        private string _WEEKDAY;

        public string trackid
        {
            get
            {
                return _TRACKID;
            }
            set
            {
                _TRACKID = value;
            }
        }
        public int weeknumber
        {
            get
            {
                return _WEEKNUMBER;
            }
            set
            {
                _WEEKNUMBER = value;
            }
        }
        public string driverid
        {
            get
            {
                return _DRIVERID;
            }
            set
            {
                _DRIVERID = value;
            }
        }
        public string scheduleid
        {
            get
            {
                return _SCHEDULEID;
            }
            set
            {
                _SCHEDULEID = value;
            }
        }
        public int totaltrip
        {
            get
            {
                return _TOTALTRIP;
            }
            set
            {
                _TOTALTRIP = value;
            }
        }
        public int daytrip
        {
            get
            {
                return _DAYTRIP;
            }
            set
            {
                _DAYTRIP = value;
            }
        }
        public int nighttrip
        {
            get
            {
                return _NIGHTTRIP;
            }
            set
            {
                _NIGHTTRIP = value;
            }
        }
        public int shiftid
        {
            get
            {
                return _SHIFTID;
            }
            set
            {
                _SHIFTID = value;
            }
        }
        public string weekday
        {
            get
            {
                return _WEEKDAY;
            }
            set
            {
                _WEEKDAY = value;
            }
        }

    }
}
