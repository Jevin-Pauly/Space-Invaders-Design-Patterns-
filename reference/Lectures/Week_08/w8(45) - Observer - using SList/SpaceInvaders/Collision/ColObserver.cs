//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{

    abstract public class ColObserver : SLink
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


}

// --- End of File ---
