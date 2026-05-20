//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class AlienFactory
    {

        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pSpriteBoxBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pSpriteBoxBatch != null);
        }

        public GameObject Create(GameObject.Name name, AlienCategory.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienCategory.Type.Squid:
                    // LTN - GameObject
                    pGameObj = new Squid(SpriteGame.Name.Squid, posX, posY);
                    break;

                case AlienCategory.Type.Octopus:
                    // LTN - GameObject
                    pGameObj = new Octopus(SpriteGame.Name.Octopus, posX, posY);
                    break;

                case AlienCategory.Type.Crab:
                    // LTN - GameObject
                    pGameObj = new Crab(SpriteGame.Name.Crab, posX, posY);
                    break;

                case AlienCategory.Type.Grid:
                    // LTN - GameObject
                    pGameObj = new AlienGrid();
                    break;

                case AlienCategory.Type.Column:
                    // LTN - GameObject
                    pGameObj = new AlienColumn();
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }


            // Attached to Group
            pGameObj.ActivateSprite(this.pSpriteBatch);;
            pGameObj.ActivateCollisionSprite(this.pSpriteBoxBatch);
            return pGameObj;
        }

        // Data: ---------------------

        private readonly SpriteBatch pSpriteBatch;
        private readonly SpriteBatch pSpriteBoxBatch;
    }
}

// --- End of File ---
