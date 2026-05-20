//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SE456
{
    class BombSpawnCmd : Command
    {
        public BombSpawnCmd()
        {
            this.pBombRoot = (BombRoot)GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Bombs = SpriteBatchMan.Find(SpriteBatch.Name.Bombs);
            Debug.Assert(this.pSB_Bombs != null);

            this.pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pAlienRoot = (AlienRoot)GameObjectNodeMan.Find(GameObject.Name.AlienRoot);
            this.pAlienGrid = pAlienRoot.GetAlienGrid();
            this.pRandom = new Random();
        }

        override public void Execute(float deltaTime, bool drop)
        {
            // If rand val is 1 drop bomb
            int i = 0;
            // 1st Column
            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }


            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            // 5th Column
            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            // 10th Column
            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }

            // 11th Column
            pAlienColumn = (AlienColumn)this.pAlienGrid.GetSearchedChild(GameObject.Name.AlienColumn_0 + i++);
            if (pRandom.Next(5) == 1)
            {
                if (pAlienColumn != null)
                {
                    pLowestAlien = (Aliens)this.pAlienColumn.GetFirstChild();
                    this.DropBomb(pLowestAlien);
                }
            }


            TimerEventMan.Add(TimerEvent.Name.BombSpawn, this, deltaTime);
        }

        private void DropBomb (Aliens lowest)
        {
            float yValue = lowest.y;
            float xValue = lowest.x;
            Bomb pBomb = null;
            // Create or ressurect
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.Bomb);
            if (pGameObjNode == null)
            {
                pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombStraight, xValue, yValue - 30);
            }
            else
            {
                // Recycle it.
                pBomb = (Bomb)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                pBomb.Resurrect(400, 100);
                pBomb.SetPos(xValue, yValue - 30);
                //pBomb.MultiplyScale(0.5f, 0.5f);
            }
            pBomb.ActivateCollisionSprite(this.pSB_Boxes);
            pBomb.ActivateSprite(this.pSB_Bombs);
            // Increase bomb count and root update
            pBombRoot.bombCount++;
            pBombRoot.Add(pBomb);
        }

        AlienRoot pAlienRoot;
        AlienGrid pAlienGrid;
        AlienColumn pAlienColumn;
        Aliens pLowestAlien;
        BombRoot pBombRoot;
        SpriteBatch pSB_Bombs;
        SpriteBatch pSB_Boxes;
        Random pRandom;
    }
}

// --- End of File ---

