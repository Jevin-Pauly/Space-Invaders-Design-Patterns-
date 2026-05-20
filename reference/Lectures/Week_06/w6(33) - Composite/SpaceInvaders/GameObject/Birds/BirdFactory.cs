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


        public GameObject Create(BirdBase.Type type, float posX, float posY)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case BirdBase.Type.Green:
                    pGameObj = new BirdGreen(SpriteGame.Name.GreenBird, posX, posY);
                    break;

                case BirdBase.Type.Red:
                    pGameObj = new BirdRed(SpriteGame.Name.RedBird, posX, posY);
                    break;

                case BirdBase.Type.White:
                    pGameObj = new BirdWhite(SpriteGame.Name.WhiteBird, posX, posY);
                    break;

                case BirdBase.Type.Yellow:
                    pGameObj = new BirdYellow(SpriteGame.Name.YellowBird, posX, posY);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            GameObjectNodeMan.Attach(pGameObj);

            // Attached to Group
            this.pSpriteBatch.Attach(pGameObj);

            return pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
    }
}

// --- End of File ---
