//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class ElementPlane : Element
    {
        // -------------------------------
        // Add CODE/REFACTOR here
        // -------------------------------
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }
    }
}

// --- End of File ---

