//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class BirdYellow : BirdBase
    {
        public BirdYellow(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.YellowBird, spriteName, posX, posY)
        {
            //this.delta = 2.0f;
        }

        public override void Update()
        {
            //this.x += this.delta;

            //if (this.x > 600.0f || this.x < 200.0f)
            //{
            //    this.delta *= -1.0f;
            //}

            base.Update();
        }

        // Data
        //private float delta;

    }
}

// --- End of File ---
