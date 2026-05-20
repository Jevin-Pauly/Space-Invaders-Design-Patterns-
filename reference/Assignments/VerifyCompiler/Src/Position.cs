//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    struct Position
    {
        public int x;
        public int y;

        public Position(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public void PrintMe()
        {
            Debug.WriteLine("  Pos x:{0} y:{1} ", this.x, this.y);
        }
    }

}

// --- End of File ---
