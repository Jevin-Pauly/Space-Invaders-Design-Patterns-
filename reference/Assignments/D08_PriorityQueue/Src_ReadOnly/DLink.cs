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
    public class DLink
    {
        public DLink()
        {
            this.pNext = null;
            this.pPrev = null;
        }

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        public DLink pNext;
        public DLink pPrev;
    }
}

// --- End of File ---
