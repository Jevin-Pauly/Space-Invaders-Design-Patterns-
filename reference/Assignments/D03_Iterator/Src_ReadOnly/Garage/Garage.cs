//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Garage
    {
        public Garage()
        {
            this.poHead = null;
        }

        public void Add(Car pCar)
        {
            Debug.Assert(pCar != null);

            // Add to Front of list

            if(this.poHead == null)
            {
                // First Add
                this.poHead = pCar;
                pCar.pNext = null;
                pCar.pPrev = null;
            }
            else
            {
                // Append to list in front
                Car pTmp = this.poHead;
                this.poHead = pCar;
                pCar.pPrev = null;
                pCar.pNext = pTmp;
                pTmp.pPrev = pCar;
            }
        }

        // -----------------------------------------------------------------
        // Data:
        //       Do NOT add or change data
        // -----------------------------------------------------------------
        // Yes - it would be easy to add data (make unit test easier)
        //       But that's not the problem
        // -----------------------------------------------------------------

        public Car poHead;
    }
}

// --- End of File ---
