using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Shift
    {
        private int _SHIFTID;
        private string _SHIFT;
        private int _STARTTIME;
        private string _STARTPERIOD;
        private int _ENDTIME;
        private string _ENDPERIOD;


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

        public string shift
        {
            get
            {
                return _SHIFT;
            }
            set
            {
                _SHIFT = value;
            }
        }
        public int starttime
        {
            get
            {
                return _STARTTIME;
            }
            set
            {
                _STARTTIME = value;
            }
        }

        public string startperiod
        {
            get
            {
                return _STARTPERIOD;
            }
            set
            {
                _STARTPERIOD = value;
            }
        }

        public int endtime
        {
            get
            {
                return _ENDTIME;
            }
            set
            {
                _ENDTIME = value;
            }
        }

        public string endperiod
        {
            get
            {
                return _ENDPERIOD;
            }
            set
            {
                _ENDPERIOD = value;
            }
        }



    }
}
