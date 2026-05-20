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

            this.poColObj.pColSprite.SetColor(1, 1, 0);
            //this.MultiplyScale(0.5f, 0.5f);
        }

        //public void Reset()
        //{
        //    this.y = 500.0f;
        //    this.pStrategy.Reset(this.y);
        //}
        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 4.0f;
            this.poColObj.pColSprite.SetColor(1, 1, 0);

            base.Resurrect(SpriteGame.Name.def);
        }

        public override void Update()
        {
            base.Update();
            this.y -= delta;

            // Strategy
            //this.pStrategy.Fall(this);
        }
        public float GetBoundingBoxHeight()
            {
            return this.poColObj.poColRect.height;
            }
        ~Bomb()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.Visit(this);
        }
        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }
        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.pSpriteProxy != null);
        
            this.pSpriteProxy.sx *= sx;
            this.pSpriteProxy.sy *= sy;
            base.Update();
        }

        // Data
        public float delta;
        //private FallStrategy pStrategy;
    }
}

// --- End of File ---
