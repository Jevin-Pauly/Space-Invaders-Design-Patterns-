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
    public class Singleton_Base
    {
        protected Singleton_Base(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        // Leave this function alone
        public void Add(int _x, int _y)
        {
            x += _x;
            y += _y;
        }
        public void Sub(int _x, int _y)
        {
            x -= _x;
            y -= _y;
        }

        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        // -------------------------------------------------
        //  Leave private x, y
        // -------------------------------------------------
        private int x;
        private int y;

    }
}

// --- End of File ---

