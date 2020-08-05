using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ShiftBL
    {
        
        ShiftDL objshiftdl = new ShiftDL();

        /// <summary>
        /// Save shift
        /// </summary>
  
        public Shift SaveShift(Shift objshift)
        {
            try
            {
                
                return objshiftdl.Add(objshift);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get shift
        /// </summary>
       
        public List<Shift> GetAllShift()
        {
            try
            {
                return objshiftdl.All();
               
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
