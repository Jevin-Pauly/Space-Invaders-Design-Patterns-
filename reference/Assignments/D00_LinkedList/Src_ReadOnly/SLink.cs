//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace PA
{
    // ----------------------------------
    // ---     DO NOT MODIFY FILE     ---
    // ----------------------------------

    abstract public class SLink
    {
        protected SLink()
        {
            this.Clear();
        }
        public void Clear()
        {
            this.pNext = null;
        }

        // Data: -----------------------------
        public SLink pNext;

    }
}

// --- End of File ---