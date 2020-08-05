using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Schedule
    {
        private string _SCHEDULEID;
        private int _WEEK;
        private int _SHIFTID;
        

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

        public int week
        {
            get
            {
                return _WEEK;
            }
            set
            {
                _WEEK = value;
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
        
    }
}
