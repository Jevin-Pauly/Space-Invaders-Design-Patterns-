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
    public abstract class ElementFruit
    {
        public virtual void Accept(VisitorFruit other)
        {
            // NORMALLY this is an abstract method...
            //    Its virtual and implemented for unit testing purposes
            //    Treat this method "as if" it is abstract...so override in derived
        }
    }
}

// --- End of File ---

