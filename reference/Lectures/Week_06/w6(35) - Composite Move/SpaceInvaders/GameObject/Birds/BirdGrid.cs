//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class BirdGrid : Composite
    {
        public BirdGrid()
            : base(GameObject.Name.BirdGrid, psSpriteGameProxyNull)
        {
        }

        private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
    }
}

// --- End of File ---
