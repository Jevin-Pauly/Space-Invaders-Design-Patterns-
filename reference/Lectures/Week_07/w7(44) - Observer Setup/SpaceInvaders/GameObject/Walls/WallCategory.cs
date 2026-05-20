//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class WallCategory : Leaf
    {
        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom,
            Top,

            Unitialized
        }

        protected WallCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
        : base(gameName, spriteName, _x, _y)
        {

        }

        ~WallCategory()
        {
        }



        // Data ----------


    }
}

// --- End of File ---
