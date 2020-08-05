using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Result
    {
        private string _FULLNAME;
        private string _WEEKDAY;
        private string _SHIFT;

        public string fullname
        {
            get
            {
                return _FULLNAME;
            }
            set
            {
                _FULLNAME = value;
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
    }
}
