//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SE456
{
    class BombSpawnEvent : Command
    {
        public BombSpawnEvent(Random pRandom)
        {
            this.pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Birds = SpriteBatchMan.Find(SpriteBatch.Name.Birds);
            Debug.Assert(this.pSB_Birds != null);

            this.pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            //Debug.WriteLine("event: {0}", deltaTime);

            // Create Bomb
            float value = pRandom.Next(300, 700);
            Bomb pBomb = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombStraight, new FallStraight(), value, 700.0f);
            //     Debug.WriteLine("----x:{0}", value);

            pBomb.ActivateCollisionSprite(this.pSB_Boxes);
            pBomb.ActivateSprite(this.pSB_Birds);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pBombRoot.Add(pBomb);

        }

        GameObject pBombRoot;
        SpriteBatch pSB_Birds;
        SpriteBatch pSB_Boxes;
        Random pRandom;
    }
}

// --- End of File ---
