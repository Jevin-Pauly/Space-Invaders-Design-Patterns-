//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Vehicle 
    {
        public void Attach(Element pElement)
        {
            Debug.Assert(pElement != null);

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
        }

        public void Detach(Element pElement)
        {
            Debug.Assert(pElement != null);

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
        }

        public void Accept(Visitor visitor)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
        }
        

        // Holds the Elements with a Single Linked list
        // Add to the front of the list O(1)
        public Element poHead;
    }
}

// --- End of File ---

