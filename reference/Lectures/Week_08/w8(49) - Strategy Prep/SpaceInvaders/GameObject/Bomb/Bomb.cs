//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class Bomb : BombCategory
    {
        public Bomb(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName, posX, posY, BombCategory.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 4.0f;

            this.oldPosY = this.y;
        }

        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

        public override void Update()
        {
            base.Update();
            this.y -= delta;

            //StrategyNegXFall();
            StrategyNegYFall();
        }

        private void StrategyStraightFall()
        {

        }

        private void StrategyNegXFall()
        {
            float targetY = oldPosY - 1.0f * this.poColObj.poColRect.height;

            if (this.y < targetY)
            {
                this.pSpriteProxy.sx *= -1.0f;
                oldPosY = targetY;
            }
        }

        private void StrategyNegYFall()
        {
            float targetY = oldPosY - 1.0f * this.poColObj.poColRect.height;

            if (this.y < targetY)
            {
                this.pSpriteProxy.sy *= -1.0f;
                oldPosY = targetY;
            }
        }

        ~Bomb()
        {
        }


        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBomb(this);
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }


        // Data
        public float delta;
        private float oldPosY;
    }
}

// --- End of File ---
