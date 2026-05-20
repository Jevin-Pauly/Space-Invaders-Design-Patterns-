//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace PA
{
    // ----------------------------------
    // ---     DO NOT MODIFY FILE     ---
    // ----------------------------------

    abstract public class DLink 
    {

        protected DLink()
        {
            this.Clear();
        }
        public void Clear()
        {
            this.pNext = null;
            this.pPrev = null;
        }

        // Data: -----------------------------
        public DLink pNext;
        public DLink pPrev;

    }
}

// --- End of File ---
