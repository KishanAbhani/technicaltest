using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Availability
    {
        private string _ID;
        private string _DRIVERID;
        private int _WEEKNUMBER;
        private string _WEEKDAY;
        private int _DRIVERAVAILABILITY;
        

        public string id
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
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
        //public int dayavailability
        //{
        //    get
        //    {
        //        return _DAYAVAILABILITY;
        //    }
        //    set
        //    {
        //        _DAYAVAILABILITY = value;
        //    }
        //}
        public int driveravailabbility
        {
            get
            {
                return _DRIVERAVAILABILITY;
            }
            set
            {
                _DRIVERAVAILABILITY = value;
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
