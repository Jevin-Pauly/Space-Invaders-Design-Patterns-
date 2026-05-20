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
    public class Letter : SLink
    {
        // -----------------------------------------------------------
        //  Very simple class, slink is for attaching to Flyweight
        // -----------------------------------------------------------
        public Letter(string _string)
        {
            this.mString = _string;
        }


        public string mString;
    }
}

// --- End of File ---

