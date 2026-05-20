//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class BirdBase : Leaf
    {
        public enum Type
        {
            Red,
            Yellow,
            Green,
            White
        }

        protected BirdBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName,spriteName,_x,_y)
        {

        }
    }
}

// --- End of File ---
