//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    //-----------------------------------------
    // Reverse Iterator
    //    Start at the last node...
    //    Iterator to the first node
    //-----------------------------------------
    public class Car_ReverseIterator : Car_BaseIterator
    {
        public Car_ReverseIterator(Garage pGarage)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            garage = pGarage;
            currCar = null;
        }

        override public Car Next()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (IsDone())
            {
                return null;
            }

            if (currCar == null)
            {
                currCar = Last();
            }
            else
            {
                currCar = (Car)currCar.pPrev;
            }
            return currCar;

        }

        override public bool IsDone()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return (currCar == null);
        }

        override public Car First()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (garage == null)
            {
                return null;
            }
            currCar = Last();
            return currCar;
        }

        override public Car Current()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return currCar;
        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------

        private Car Last()
        {
            Car lastCar = garage.poHead;

            while (lastCar != null && lastCar.pNext != null) 
            {
                lastCar = (Car)lastCar.pNext;
            }

            return lastCar;
        }

        private Garage garage;
        private Car currCar;

    }
}

// --- End of File ---

