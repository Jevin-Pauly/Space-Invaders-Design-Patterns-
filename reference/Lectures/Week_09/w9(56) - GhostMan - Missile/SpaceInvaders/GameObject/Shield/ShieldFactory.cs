//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class ShieldFactory
    {
        private ShieldFactory()
        {
            this.pSpriteBatch = null;
            this.pCollisionSpriteBatch = null;
            this.pTree = null;
        }
        private void privSet(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, Composite pTree)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteBatchMan.Find(collisionSpriteBatch);
            Debug.Assert(this.pCollisionSpriteBatch != null);

            Debug.Assert(pTree != null);
            this.pTree = pTree;
        }
        private void privSetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }
        ~ShieldFactory()
        {
        }
        private GameObject privCreate(ShieldCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pShield = null;

            switch (type)
            {
                case ShieldCategory.Type.Brick:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop1:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_LeftTop1, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop0:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_LeftTop0, posX, posY);
                    break;

                case ShieldCategory.Type.LeftBottom:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_LeftBottom, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop1:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_RightTop1, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop0:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_RightTop0, posX, posY);
                    break;

                case ShieldCategory.Type.RightBottom:
                    pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_RightBottom, posX, posY);
                    break;

                case ShieldCategory.Type.Root:
                    pShield = new ShieldRoot(gameName, SpriteGame.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    Debug.Assert(false);
                    break;

                case ShieldCategory.Type.Grid:
                    pShield = new ShieldGrid(gameName, SpriteGame.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    break;

                case ShieldCategory.Type.Column:
                    pShield = new ShieldColumn(gameName, SpriteGame.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(1.0f, 0.0f, 0.0f);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add to the tree
            this.pTree.Add(pShield);

            // Attached to Group
            pShield.ActivateSprite(this.pSpriteBatch);
            pShield.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pShield;
        }

        public static GameObject CreateSingleShield()
        {
            ShieldFactory pFactory = ShieldFactory.privInstance();

            Composite pShieldRoot = (Composite)new ShieldRoot(
                                GameObject.Name.ShieldRoot, 
                                SpriteGame.Name.NullObject, 0.0f, 0.0f);



            GameObjectNodeMan.Attach(pShieldRoot);

            pFactory.privSet(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);

            // create a grid
            GameObject pGrid = pFactory.privCreate(ShieldCategory.Type.Grid, GameObject.Name.ShieldGrid);
        

            int j = 0;

            GameObject pColumn;

         
            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            pFactory.privSetParent(pColumn);

            float start_x = 400.0f;
            float start_y = 400.0f;
            float off_x = 0;
            float brickWidth = 40.0f;
            float brickHeight = 20.0f;

            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight);


            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            pFactory.privSetParent(pColumn);

            off_x += brickWidth;
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);


            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            pFactory.privSetParent(pColumn);

            off_x += brickWidth;
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);

            return pShieldRoot;
        }

        private static ShieldFactory privInstance()
        {
            if(pInstance == null)
            {
                ShieldFactory.pInstance = new ShieldFactory();
            }

            Debug.Assert(pInstance != null);

            return pInstance;
        }

        // Data: ---------------------
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionSpriteBatch;
        private Composite pTree;

        private static ShieldFactory pInstance = null;
    }
}

// --- End of File ---
