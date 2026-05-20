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
        }
        override public System.Enum GetName()
        {
            return BirdBase.Name.YellowBird;
        }

        public override void Update()
        {
            //this.y += 2.0f;
            //if (this.y > 600.0f)
            //{
            //    this.y = 0.0f;
            //}

            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
