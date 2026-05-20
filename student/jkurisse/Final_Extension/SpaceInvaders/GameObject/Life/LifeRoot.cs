using System;
using System.Diagnostics;

namespace SE456
{
    public class LifeRoot : Composite
    {
        public LifeRoot(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(1, 1, 1);
            this.lifeCount = 0;

            this.pSB_Lives = SpriteBatchMan.Find(SpriteBatch.Name.PlayerLives);
            Debug.Assert(this.pSB_Lives != null);

            this.pSB_Box = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Box != null);
        }

        ~LifeRoot()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.Visit(this);
        }
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public void CreateLives(int numLives)
        {
            for (int i = 0; i < numLives; i++)
            {
                GameObject pLife = null;
                // Create or ressurect
                GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.ShipLife);
                if (pGameObjNode == null)
                {
                    pLife = new Life(GameObject.Name.ShipLife, SpriteGame.Name.Ship, 88.0f + (i * 45), 33.0f);
                }
                else
                {
                    // Recycle it.
                    pLife = pGameObjNode.pGameObj;
                    GhostMan.Remove(pGameObjNode);

                    ((Life)pLife).Resurrect(88.0f + (i * 45), 33.0f);
                    ((Life)pLife).SetPos(88.0f + (i * 45), 33.0f);
                    //pBomb.MultiplyScale(0.5f, 0.5f);
                }
                this.Add(pLife);
                pLife.ActivateSprite(pSB_Lives);
                pLife.ActivateCollisionSprite(pSB_Box);
            }
        }

        public Life GetLife()
        {
            return (Life)IteratorForwardComposite.GetChild(this);
        }

        // Data: ---------------
        public int lifeCount;
        private SpriteBatch pSB_Lives;
        private SpriteBatch pSB_Box;


    }
}

// --- End of File ---