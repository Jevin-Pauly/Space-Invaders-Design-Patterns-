//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class BirdWhite : AlienCategory
    {
        public BirdWhite(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.WhiteBird, spriteName, posX, posY, AlienCategory.Type.Aliens)
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an WhiteBird
            // Call the appropriate collision reaction            
            other.Visit(this);
        }

        public override void Update()
        {
            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
