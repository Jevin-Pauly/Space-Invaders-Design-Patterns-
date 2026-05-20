//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class GameObjectNull : Leaf
    {
        public GameObjectNull()
            : base(GameObject.Name.NullObject, SpriteGame.Name.NullObject, 0, 0)
        {

        }

        public override void Move(float x, float y)
        {
        }
        public override void Update()
        {
            // do nothing - its a null object
        }

        private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
    }
}

// --- End of File ---
