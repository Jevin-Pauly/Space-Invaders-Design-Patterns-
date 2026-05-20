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
    public class GlobalMan_Base
    {
        protected GlobalMan_Base(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        // Leave this function alone
        protected void proAdd(int _x, int _y)
        {
            x += _x;
            y += _y;
        }
        protected void proSub(int _x, int _y)
        {
            x -= _x;
            y -= _y;
        }

        protected int proGetX()
        {
            return x;
        }
        protected int proGetY()
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

