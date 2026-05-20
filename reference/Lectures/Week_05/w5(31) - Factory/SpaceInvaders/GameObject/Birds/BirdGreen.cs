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
        }

        public override void Update()
        {
            this.y += 0.50f;
            if (this.y > 600.0f)
            {
                this.y = 0.0f;
            }

            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
