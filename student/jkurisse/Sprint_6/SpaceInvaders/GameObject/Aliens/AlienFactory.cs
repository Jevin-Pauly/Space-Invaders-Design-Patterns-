//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class AlienFactory
    {

        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName, Composite pTree)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pSpriteBoxBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pSpriteBoxBatch != null);

            Debug.Assert(pTree != null);
            this.pTree = pTree;
        }

        public void SetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }

        ~AlienFactory()
        {
            this.pSpriteBatch = null;
            this.pSpriteBoxBatch = null;
        }

        public GameObject Create(GameObject.Name name, AlienCategory.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienCategory.Type.Squid:
                    // LTN - GameObject
                    pGameObj = new Aliens(SpriteGame.Name.Squid, name, posX, posY);
                    break;

                case AlienCategory.Type.Octopus:
                    // LTN - GameObject
                    pGameObj = new Aliens(SpriteGame.Name.Octopus, name, posX, posY);
                    break;

                case AlienCategory.Type.Crab:
                    // LTN - GameObject
                    pGameObj = new Aliens(SpriteGame.Name.Crab, name, posX, posY);
                    break;

                case AlienCategory.Type.Grid:
                    // LTN - GameObject
                    pGameObj = new AlienGrid(SpriteGame.Name.NullObject, name, posX, posY);
                    break;

                case AlienCategory.Type.Column:
                    // LTN - GameObject
                    pGameObj = new AlienColumn(SpriteGame.Name.NullObject, name, posX, posY);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            this.pTree.Add(pGameObj);

            // Attached to Group
            pGameObj.ActivateSprite(this.pSpriteBatch);;
            pGameObj.ActivateCollisionSprite(this.pSpriteBoxBatch);
            return pGameObj;
        }

        // Data: ---------------------

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pSpriteBoxBatch;
        private Composite pTree;
    }
}

// --- End of File ---
