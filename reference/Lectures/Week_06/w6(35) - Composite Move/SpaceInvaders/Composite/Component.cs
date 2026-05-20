//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class Component : DLink
    {
        public abstract void Print();
        public abstract void Move(float x, float y);
    }
}

// --- End of File ---
