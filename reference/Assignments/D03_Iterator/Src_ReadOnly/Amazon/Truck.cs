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
    public class Truck : DLink
    {
        public Truck() : base()
        {
            //Debug.WriteLine("New Truck() {0}",this.GetHashCode());
            this.pBoxes = new Box[Truck.numBoxes];
            Debug.Assert(this.pBoxes != null);
            
            for(int i = 0; i < Truck.numBoxes; i++)
            {
                this.pBoxes[i] = new Box();
                Debug.Assert(this.pBoxes[i] != null);
            }
        }

        public bool GetEmptyShelf(out int index)
        {
            bool success = false;
            index = -1;
            for( int i = 0; i < Truck.numBoxes; i++)
            {
                if(this.pBoxes[i].name == Box.Name.Empty)
                {
                    index = i;
                    success = true;
                    break;
                }
            }

            return success;
        }

        // -----------------------------------------------------------------
        // Data:
        //       Do NOT add or change data
        // -----------------------------------------------------------------
        // Yes - it would be easy to add data (make unit test easier)
        //       But that's not the problem
        // -----------------------------------------------------------------
        public const uint numBoxes = 4;
        public Box[] pBoxes;
    }
}

// --- End of File ---
