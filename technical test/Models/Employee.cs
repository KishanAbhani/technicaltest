using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Employee
    {
        private string _EMPID;
        private string _EMPNAME;
        private string _CONTACTNUMBER;
        private string _EMAIL;

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

        public string empname
        {
            get
            {
                return _EMPNAME;
            }
            set
            {
                _EMPNAME = value;
            }
        }

        public string contactnumber
        {
            get
            {
                return _CONTACTNUMBER;
            }
            set
            {
                _CONTACTNUMBER = value;
            }
        }

        public string email
        {
            get
            {
                return _EMAIL;
            }
            set
            {
                _EMAIL = value;
            }
        }

    }
}
