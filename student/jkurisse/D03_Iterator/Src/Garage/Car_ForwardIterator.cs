//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    //-----------------------------------------
    // Forward Iterator
    //    Start at the first node...
    //    Iterator to the Last node
    //-----------------------------------------
    public class Car_ForwardIterator : Car_BaseIterator
    {
        public Car_ForwardIterator(Garage pGarage)
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
                currCar = garage.poHead;
            }
            else
            {
                currCar = (Car)currCar.pNext;
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
            currCar = garage.poHead;
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

        private Garage garage;
        private Car currCar;

    }
}

// --- End of File ---

