//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class BirdFactory
    {
        public BirdFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
        }


        public GameObject Create(GameObject.Name name, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (name)
            {
                case GameObject.Name.GreenBird:
                    pGameObj = new BirdGreen(SpriteGame.Name.GreenBird, posX, posY);
                    break;

                case GameObject.Name.RedBird:
                    pGameObj = new BirdRed(SpriteGame.Name.RedBird, posX, posY);
                    break;

                case GameObject.Name.WhiteBird:
                    pGameObj = new BirdWhite(SpriteGame.Name.WhiteBird, posX, posY);
                    break;

                case GameObject.Name.YellowBird:
                    pGameObj = new BirdYellow(SpriteGame.Name.YellowBird, posX, posY);
                    break;

                case GameObject.Name.BirdGrid:
                    pGameObj = new BirdGrid();
                    break;

                case GameObject.Name.BirdColumn:
                    pGameObj = new BirdColumn();
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // Attached to Group
            pGameObj.ActivateSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pSpriteBatch);

            return pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
    }
}

// --- End of File ---
