using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SE456
{
    public class Life : Leaf
    {
        public Life(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;
            //this.pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.PlayerLives);
            //this.pCollisionSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            this.poColObj.pColSprite.SetColor(1, 1, 0);
            //this.ActivateSprite(this.pSpriteBatch);
            //this.ActivateCollisionSprite(this.pCollisionSpriteBatch);
            //this.MultiplyScale(0.5f, 0.5f);
        }

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
            this.poColObj.pColSprite.SetColor(1, 1, 0);

            base.Resurrect(SpriteGame.Name.def);
        }

        public override void Update()
        {
            base.Update();

            // Strategy
            //this.pStrategy.Fall(this);
        }
        public float GetBoundingBoxHeight()
        {
            return this.poColObj.poColRect.height;
        }
        ~Life()
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
        //private SpriteBatch pSpriteBatch;
        //private SpriteBatch pCollisionSpriteBatch;
    }
}

// --- End of File ---
