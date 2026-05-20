//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class SpriteBase : DLink
    {
        abstract public void Render();
        abstract public void Update();
    }
}

// --- End of File ---
