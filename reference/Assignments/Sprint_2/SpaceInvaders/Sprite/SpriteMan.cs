//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class SpriteMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteMan(ListBase _poActive, ListBase _poReserve, int reserveNum = 3, int reserveGrow = 1)
                : base(_poActive, _poReserve, reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            this.poSpriteCompare = new Sprite();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public Sprite Add(Sprite.Name name, Image pImage, Azul.Rect pScreenRect)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(pScreenRect != null);

            Sprite pSprite = (Sprite)this.baseAdd();
            Debug.Assert(pSprite != null);

            // Initialize the data
            pSprite.Set(name, pImage, pScreenRect);
            return pSprite;
        }

        public Sprite Find(Sprite.Name name)
        {
            // Compare functions only compares two Sprites

            // So:  Use the Compare Sprite - as a reference
            //      use in the Compare() function
            this.poSpriteCompare.name = name;

            Sprite pData = (Sprite)this.baseFind(this.poSpriteCompare);
            return pData;
        }
        public void Remove(Sprite pSprite)
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
            NodeBase pNodeBase = new Sprite();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        override protected bool derivedCompare(NodeBase pSpriteBaseA, NodeBase pSpriteBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pSpriteBaseA != null);
            Debug.Assert(pSpriteBaseB != null);

            Sprite pDataA = (Sprite)pSpriteBaseA;
            Sprite pDataB = (Sprite)pSpriteBaseB;

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
            Sprite pSprite = (Sprite)pSpriteBase;
            pSprite.Wash();
        }
        override protected void derivedDumpNode(NodeBase pSpriteBase)
        {
            Debug.Assert(pSpriteBase != null);
            Sprite pData = (Sprite)pSpriteBase;
            pData.Dump();
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private readonly Sprite poSpriteCompare;
    }
}

// --- End of File ---
