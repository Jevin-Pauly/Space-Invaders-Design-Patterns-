//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class Component : DLink
    {
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Print();
    }
}

// --- End of File ---
