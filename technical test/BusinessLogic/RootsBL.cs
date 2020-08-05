using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class RootsBL
    {
        RootsDL objrootdl = new RootsDL();

        /// <summary>
        /// Save root
        /// </summary>
       
        public Root SaveRoot(Root objroot)
        {
            try
            {
                
               
                return objrootdl.Add(objroot);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get roots
        /// </summary>
       
        public List<Root> GetAllRoots()
        {
            try
            {
                return objrootdl.All();
                
            }
            catch(Exception e)
            {
                return null;
            }
        }

    }
}
