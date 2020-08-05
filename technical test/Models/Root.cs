using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Root
    {
        private string _ROOTID;
        private string _ROOT;
        private string _STARTLOCATION;
        private string _ENDLOCATION;

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

        public string root
        {
            get
            {
                return _ROOT;
            }
            set
            {
                _ROOT = value;
            }
        }

        public string startlocation
        {
            get
            {
                return _STARTLOCATION;
            }
            set
            {
                _STARTLOCATION = value;
            }
        }
        public string endlocation
        {
            get
            {
                return _ENDLOCATION;
            }
            set
            {
                _ENDLOCATION = value;
            }
        }

    }
}
