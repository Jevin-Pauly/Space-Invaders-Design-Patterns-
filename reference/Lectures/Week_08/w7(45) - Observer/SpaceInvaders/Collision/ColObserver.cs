//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{

    abstract public class ColObserver : DLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            SoundObserver,
            GridObserver,
            Uninitialized
        }
        public abstract void Notify();
        override public void Wash()
        {
            Debug.Assert(false);
        }

        public ColSubject pSubject;
    }

    //override public void Dump()
    //{
    //    Debug.Assert(false);
    //}
    //override public System.Enum GetName()
    //{
    //    Debug.Assert(false);
    //}
}

// --- End of File ---
