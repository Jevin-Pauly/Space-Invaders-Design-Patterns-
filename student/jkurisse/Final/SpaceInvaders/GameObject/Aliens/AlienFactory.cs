//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class AlienFactory
    {
        private AlienFactory()
        {
            this.pSpriteBatch = null;
            this.pCollisionSpriteBatch = null;
            this.pTree = null;
        }
        private void privSet(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName, Composite pTree)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pCollisionSpriteBatch != null);

            Debug.Assert(pTree != null);
            this.pTree = pTree;
        }

        public void privSetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }

        ~AlienFactory()
        {
        }

        public static bool GetAlien()
        {
            AlienRoot pAlienRoot = (AlienRoot)GameObjectNodeMan.Find(GameObject.Name.AlienRoot);
            AlienGrid pGridCheck = pAlienRoot.GetAlienGrid();
            if (pGridCheck != null)
            {
                return true;
            }
            return false;
        }

        private GameObject privCreate(AlienCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pAlien = null;

            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            if (pGameObjNode != null)
            {
                pAlien = pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                switch (type)
                {
                    case AlienCategory.Type.Squid:
                        ((Aliens)pAlien).Resurrect(posX, posY, SpriteGame.Name.Squid);
                        break;
                    case AlienCategory.Type.Octopus:
                        ((Aliens)pAlien).Resurrect(posX, posY, SpriteGame.Name.Octopus);
                        break;
                    case AlienCategory.Type.Crab:
                        ((Aliens)pAlien).Resurrect(posX, posY, SpriteGame.Name.Crab);
                        break;
                    case AlienCategory.Type.Grid:
                        ((AlienGrid)pAlien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Column:
                        ((AlienColumn)pAlien).Resurrect(posX, posY);
                        break;

                    case AlienCategory.Type.Root:
                        Debug.Assert(false);
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
                    case AlienCategory.Type.Squid:
                        pAlien = new Aliens(gameName, SpriteGame.Name.Squid, posX, posY);
                        break;

                    case AlienCategory.Type.Octopus:
                        pAlien = new Aliens(gameName, SpriteGame.Name.Octopus, posX, posY);
                        break;

                    case AlienCategory.Type.Crab:
                        pAlien = new Aliens(gameName, SpriteGame.Name.Crab, posX, posY);
                        break;

                    case AlienCategory.Type.Grid:
                        pAlien = new AlienGrid(gameName, SpriteGame.Name.NullObject, posX, posY);
                        break;

                    case AlienCategory.Type.Column:
                        pAlien = new AlienColumn(gameName, SpriteGame.Name.NullObject, posX, posY);
                        break;

                    case AlienCategory.Type.Root:
                        Debug.Assert(false);
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }

            // add to the tree
            this.pTree.Add(pAlien);

            // Attached to Group
            pAlien.ActivateSprite(this.pSpriteBatch);
            pAlien.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pAlien;
        }


        public static GameObject CreateAliens()
        {
            AlienFactory pFactory = AlienFactory.privInstance();

            AlienRoot pAlienRoot = (AlienRoot)GameObjectNodeMan.Find(GameObject.Name.AlienRoot);

            if (pAlienRoot == null)
            {
                pAlienRoot = new AlienRoot(GameObject.Name.AlienRoot, SpriteGame.Name.NullObject);
            }

            GameObjectNodeMan.Attach(pAlienRoot);

            pFactory.privSet(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes, pAlienRoot);

            GameObject pAlienGrid = pFactory.privCreate(AlienCategory.Type.Grid, GameObject.Name.AlienGrid);

            for (int i = 0; i < 11; i++)
            {
                float X = 86.0f + (50.0f * i);
                // Set Parent for Column as Grid
                pFactory.privSetParent(pAlienGrid);
                GameObject pAlienCol = pFactory.privCreate(AlienCategory.Type.Column, GameObject.Name.AlienColumn);

                // Set Parent for Aliens as Column
                pFactory.privSetParent(pAlienCol);
                pFactory.privCreate(AlienCategory.Type.Octopus, GameObject.Name.Aliens, X, 400.0f);
                pFactory.privCreate(AlienCategory.Type.Octopus, GameObject.Name.Aliens, X, 400.0f + 50.0f);
                pFactory.privCreate(AlienCategory.Type.Crab, GameObject.Name.Aliens, X, 500.0f);
                pFactory.privCreate(AlienCategory.Type.Crab, GameObject.Name.Aliens, X, 500.0f + 50.0f);
                pFactory.privCreate(AlienCategory.Type.Squid, GameObject.Name.Aliens, X, 600.0f);
            }

            return pAlienRoot;
        }



        private static AlienFactory privInstance()
        {
            if (pInstance == null)
            {
                AlienFactory.pInstance = new AlienFactory();
            }

            Debug.Assert(pInstance != null);

            return pInstance;
        }

        // Data: ---------------------

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionSpriteBatch;
        private Composite pTree;

        private static AlienFactory pInstance = null;
    }
}

// --- End of File ---
