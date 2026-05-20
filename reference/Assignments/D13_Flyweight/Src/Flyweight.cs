//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Flyweight
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //  Fill in the two methods...
        //       add additional helper methods if you want
        // -----------------------------------------------------------

        public Letter GetLetter(string pString)
        {
            // ----------------------------------------------------------
            // Add CODE/REFACTOR here
            // ----------------------------------------------------------
            // return a letter...
            //          returned a share object if found on list
            //          else
            //          created create a new object and add to list
            // ----------------------------------------------------------
            // 1) Return the letter if its already in the flyweight
            // or 
            // 2) not on list...
            //      Create a new letter
            //      attach new letter to flyweight
            // ----------------------------------------------------------

            return null;
        }

        public void Remove(string pString)
        {
            // --------------------------------------------------
            // Add CODE/REFACTOR here
            // --------------------------------------------------
            //  remove a entry on the flyweight if it exists
            // --------------------------------------------------
        }


        // ------------------------------------------
        // Data:
        // ------------------------------------------

        public Letter poHead;
    }
}

// --- End of File ---

