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

        //public void SetParent(GameObject pParentNode)
        //{
        //    // OK being null
        //    Debug.Assert(pParentNode != null);
        //    this.pTree = (Composite)pParentNode;
        //}

        public static bool GetShield()
        {
            ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);
            ShieldGrid pGridCheck = pShieldRoot.GetShieldGrid();
            if(pGridCheck != null)
            {
                return true;
            }
            return false;
        }



        private GameObject privCreate(ShieldCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pShield = null;

            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            if (pGameObjNode != null)
            {
                pShield = pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                //GhostMan.Dump();

                switch (type)
                {
                    case ShieldCategory.Type.Brick:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick);
                        break;
                    case ShieldCategory.Type.LeftTop1:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick_LeftTop1);
                        break;
                    case ShieldCategory.Type.LeftTop0:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick_LeftTop0);
                        break;
                    case ShieldCategory.Type.LeftBottom:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick_LeftBottom);
                        break;
                    case ShieldCategory.Type.RightTop1:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick_RightTop1);
                        break;
                    case ShieldCategory.Type.RightTop0:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick_RightTop0);
                        break;
                    case ShieldCategory.Type.RightBottom:
                        ((ShieldBrick)pShield).Resurrect(posX, posY, SpriteGame.Name.Brick_RightBottom);
                        break;

                    case ShieldCategory.Type.Root:
                        Debug.Assert(false);
                        break;

                    case ShieldCategory.Type.Grid:
                        ((ShieldGrid)pShield).Resurrect(posX, posY);
                        break;

                    case ShieldCategory.Type.Column:
                        ((ShieldColumn)pShield).Resurrect(posX, posY); ;
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }
            else
            {
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
                        Debug.Assert(false);
                        break;

                    case ShieldCategory.Type.Grid:
                        pShield = new ShieldGrid(gameName, SpriteGame.Name.NullObject, posX, posY);
                        break;

                    case ShieldCategory.Type.Column:
                        pShield = new ShieldColumn(gameName, SpriteGame.Name.NullObject, posX, posY);
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }

            // add to the tree
            this.pTree.Add(pShield);

            // Attached to Group
            pShield.ActivateSprite(this.pSpriteBatch);
            pShield.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pShield;
        }


        public static GameObject CreateShields()
        {
            ShieldFactory pFactory = ShieldFactory.privInstance();

            ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);

            if (pShieldRoot == null)
            {
                pShieldRoot = new ShieldRoot(GameObject.Name.ShieldRoot, SpriteGame.Name.NullObject);
            }

            GameObjectNodeMan.Attach(pShieldRoot);

            pFactory.privSet(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);

            // create a grid
            GameObject pShieldGrid = pFactory.privCreate(ShieldCategory.Type.Grid, GameObject.Name.ShieldGrid);

            GameObject pShieldColumn;
            int temp = 0;
            for (int i = 0; i < 4; i++)
            {
                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                float start_x = 91.0f + 141.0f * i;
                float start_y = 150.0f;
                float off_x = 0.0f;
                float brickWidth = 11.0f;
                float brickHeight = 11.0f;

                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x, start_y + 4 * brickHeight);

                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                off_x += brickWidth;
                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);

                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                off_x += brickWidth;
                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);

                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                off_x += brickWidth;
                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);

                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                off_x += brickWidth;
                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);

                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                off_x += brickWidth;
                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);

                pFactory.privSetParent(pShieldGrid);
                pShieldColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + temp++);

                off_x += brickWidth;
                pFactory.privSetParent(pShieldColumn);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                pFactory.privCreate(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            }
            return pShieldRoot;
        }


        private static ShieldFactory privInstance()
        {
            if (pInstance == null)
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
