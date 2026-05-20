//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class Component : DLink
    {
        public enum Container
        {
            LEAF,
            COMPOSITE,
            Unknown
        }

        public Component(Component.Container _type)
        {
            this.type = _type;
            this.pParent = null;
        }

        public abstract void Print();
        public abstract void Move(float x, float y);

        // Data
        public Container type;
        public Component pParent ;
    }
}

// --- End of File ---
