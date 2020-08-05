using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Driver
    {
        private string _DRIVERID;
        private string _EMPID;
        private string _ROOTID;

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
        public string empid
        {
            get
            {
                return _EMPID;
            }
            set
            {
                _EMPID = value;
            }
        }

        public string rootid
        {
            get
            {
                return _ROOTID;
            }
            set
            {
                _ROOTID = value;
            }
        }

    }
}
