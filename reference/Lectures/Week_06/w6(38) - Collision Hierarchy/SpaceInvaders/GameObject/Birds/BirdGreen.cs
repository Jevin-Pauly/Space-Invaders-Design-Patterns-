//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class BirdGreen : BirdBase
    {
        public BirdGreen(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.GreenBird, spriteName, posX, posY)
        {
            this.delta = 3.0f;
        }


        public override void Update()
        {
            this.y += this.delta;

            if (this.y > 500.0f || this.y < 100.0f)
        {
                this.delta *= -1.0f;
        }

            base.Update();
        }

        // Data: ---------------
        private float delta;
    }
}

// --- End of File ---
