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
    public class Amazon
    {
        public Amazon()
        {
            this.poHead = null;
        }

        public Box Add(Box.Name n, int x)
        {
            // First time?
            Truck pTmp = this.poHead;
            if(pTmp == null)
            {
                this.poHead = new Truck();
                pTmp = this.poHead;
                Debug.Assert(this.poHead != null);
            }

            int index;
            bool flag = pTmp.GetEmptyShelf(out index);

            if(flag == true)
            {
                pTmp.pBoxes[index].Set(n, x);
            }
            else
            {
                // truck is full... add a new one
                Truck pTruck = new Truck();
                Debug.Assert(pTruck != null);

                this.privTruckAdd(pTruck);

                flag = pTruck.GetEmptyShelf(out index);
                Debug.Assert(flag == true);
                Debug.Assert(index < Truck.numBoxes);
                Debug.Assert(index >= 0);

                pTruck.pBoxes[index].Set(n, x);
                pTmp = pTruck;
                //Debug.WriteLine(" box index {0}  ptr {1}", index, pTruck.pBoxes[index].GetHashCode());
            }

           // Debug.WriteLine("index {0}", index);
            return pTmp.pBoxes[index];
        }

        private void privTruckAdd(Truck pTruck)
        {
            Debug.Assert(pTruck != null);

            // Add to Front
            if (this.poHead == null)
            {
                this.poHead = pTruck;
                pTruck.pNext = null;
                pTruck.pPrev = null;
            }
            else
            {
                Truck pTmp = this.poHead;
                this.poHead = pTruck;
                pTruck.pPrev = null;
                pTruck.pNext = pTmp;
                pTmp.pPrev = pTruck;
            }
        }

        // -----------------------------------------------------------------
        // Data:
        //       Do NOT add or change data
        // -----------------------------------------------------------------
        // Yes - it would be easy to add data (make unit test easier)
        //       But that's not the problem
        // -----------------------------------------------------------------

        public Truck poHead;
    }
}

// --- End of File ---
