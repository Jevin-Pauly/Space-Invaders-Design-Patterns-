//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Node : SLink
    {
        public enum Name
        {
            Cat,
            Dog,
            Bird,
            Fish,
            Rabbit,
            Worm,
            Unitialized
        }

        // ------------------------------
        // Add CODE/REFACTOR here
        // ------------------------------


        // ------------------------------
        // Data:
        // ------------------------------
        public Name name;
        public int x;

    }
}

// --- End of File ---
