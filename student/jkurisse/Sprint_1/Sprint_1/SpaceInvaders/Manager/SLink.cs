//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace SpaceInvaders
{
    abstract public class SLink : NodeBase
    {
        // ------------------------------
        // Add CODE/REFACTOR here
        // ------------------------------
        protected SLink()
        {
            this.Clear();
        }
        public void Clear()
        {
            this.pNext = null;
        }

        // ------------------------------
        // Data:
        // ------------------------------
        public SLink pNext;

    }
}

// --- End of File ---
