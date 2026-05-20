//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    //-----------------------------------------
    // First Iterator
    //    Start at the first Box...
    //    Iterator to the Last Box
    //-----------------------------------------
    public class Box_ForwardIterator : Box_BaseIterator
    {
        public Box_ForwardIterator(Amazon pAmazon)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            amazon = pAmazon;
            currTruck = null;
            currBox = 0;
        }

        override public Box Next()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (IsDone())
            {
                return null;
            }

            //Next Box
            currBox++;
            Box nextBox = currTruck.pBoxes[currBox];

            //As long as box empty
            while (nextBox.x == -1)
            {
                //Move to next box if there is more
                if (currBox < Truck.numBoxes - 1)
                {
                    currBox++;
                    nextBox = currTruck.pBoxes[currBox];
                }
                //If it exceeds total box in truck move to next truck
                else
                {
                    currTruck = (Truck)currTruck.pNext;
                    currBox = 0;
                    nextBox = currTruck.pBoxes[currBox];
                }
            }

            return nextBox;
        }

        override public bool IsDone()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return (currTruck == null);
        }

        override public Box First()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            currTruck = findTruck();
            currBox = 0;
            if (currTruck != null)
            {
                return currTruck.pBoxes[currBox];
            }
            return null;
    }

        override public Box Current()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (currTruck != null && currBox >= 0)
            {
                return currTruck.pBoxes[currBox];
            }

            return null;
        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------

        private Truck findTruck()
        {
            if (amazon == null)
            {
                return null;
            }
            return amazon.poHead;
        }

        private Amazon amazon;
        private Truck currTruck;
        private int currBox;
    }
}

// --- End of File ---

