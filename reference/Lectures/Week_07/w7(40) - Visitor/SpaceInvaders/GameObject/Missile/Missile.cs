//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class Missile : BirdBase
    {
        public Missile(SpriteGame.Name spriteName, float posX, float posY)
            : base(GameObject.Name.Missile, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;
            this.bHit = false;
        }

        public override void Update()
        {
            base.Update();

            if (!bHit)
            {
                this.y += 1.0f;
            }
        }

        ~Missile()
        {

        }

        public void Hit()
        {
            this.bHit = true;
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction            
            other.VisitMissile(this);
        }

        // Data
        public bool bHit;
    }
}

// --- End of File ---
