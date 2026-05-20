//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class Leaf : GameObject
    {
        public Leaf(GameObject.Name gameName, SpriteGame.Name spriteName, float x, float y)
            : base(Component.Container.LEAF, gameName, spriteName, x, y)
        {
        }

        override public void Print()
        {
            this.Dump();
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }

    }
}

// --- End of File ---
