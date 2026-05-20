//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class SpriteGameMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteGameMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new SLinkMan(), new SLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            poSpriteCompare = new SpriteGame();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new SpriteGameMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
            SpriteGameMan pMan = SpriteGameMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton

            ImageMan.DumpStats();
        }


        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public static SpriteGame Add(SpriteGame.Name name, Image pImage, float x, float y, float w, float h)
        {
            SpriteGameMan pMan = SpriteGameMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pImage != null);
            //Debug.Assert(pScreenRect != null);

            SpriteGame pSprite = (SpriteGame)pMan.baseAdd();
            Debug.Assert(pSprite != null);

            // Initialize the data
            pSprite.Set(name, pImage, x, y, w, h);
            return pSprite;
        }

        public static SpriteGame Find(SpriteGame.Name name)
        {
            SpriteGameMan pMan = SpriteGameMan.privGetInstance();
            Debug.Assert(pMan != null);
            // Compare functions only compares two Sprites

            // So:  Use the Compare SpriteGame - as a reference
            //      use in the Compare() function
            SpriteGameMan.poSpriteCompare.name = name;

            SpriteGame pData = (SpriteGame)pMan.baseFind(SpriteGameMan.poSpriteCompare);
            return pData;
        }
        public void Remove(SpriteGame pSprite)
        {
            Debug.Assert(pSprite != null);
            this.baseRemove(pSprite);
        }
        public void Dump()
        {
            this.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SpriteGame();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        override protected bool derivedCompare(NodeBase pSpriteBaseA, NodeBase pSpriteBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pSpriteBaseA != null);
            Debug.Assert(pSpriteBaseB != null);

            SpriteGame pDataA = (SpriteGame)pSpriteBaseA;
            SpriteGame pDataB = (SpriteGame)pSpriteBaseB;

            bool status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(NodeBase pSpriteBase)
        {
            Debug.Assert(pSpriteBase != null);
            SpriteGame pSprite = (SpriteGame)pSpriteBase;
            pSprite.Wash();
        }
        override protected void derivedDumpNode(NodeBase pSpriteBase)
        {
            Debug.Assert(pSpriteBase != null);
            SpriteGame pData = (SpriteGame)pSpriteBase;
            pData.Dump();
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static SpriteGameMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private static SpriteGame poSpriteCompare;
        private static SpriteGameMan psInstance = null;
    }
}

// --- End of File ---
