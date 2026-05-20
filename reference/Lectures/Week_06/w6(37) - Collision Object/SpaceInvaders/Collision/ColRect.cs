//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ColRect : Azul.Rect
    {
        public ColRect(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }
        public ColRect(Azul.Rect pRect)
            : base(pRect)
        {
        }
        public ColRect(ColRect pRect)
            : base(pRect)
        {
        }
        public ColRect()
            : base()
        {
        }
        public bool Intersect(ColRect ColRectA, ColRect ColRectB)
        {
            // future
            return true;
        }

        public void Union(ColRect ColRect)
        {
            // future
        }

    }
}

// --- End of File ---
