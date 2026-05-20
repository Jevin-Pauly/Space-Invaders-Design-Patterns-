//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract class Leaf : GameObject
    {
        public Leaf(GameObject.Name gameName, SpriteGame.Name spriteName, float x, float y)
            : base(gameName, spriteName, x, y)
        {
        }
        protected Leaf(GameObject.Name gameName, SpriteGameProxy pProxy)
            : base(gameName, pProxy)
        {
        }

        override public void Add(Component c)
        {
            Debug.Assert(false);
        }

        override public void Remove(Component c)
        {
            Debug.Assert(false);
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
