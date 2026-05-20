//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class SpriteNodeMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteNodeMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            psSpriteNodeCompare = new SpriteNode();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------

        public SpriteNode Attach(Sprite.Name name)
        {
            SpriteNode pSpriteNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pSpriteNode != null);

            // Initialize the data
            pSpriteNode.Set(name);
            return pSpriteNode;
        }

        public void Draw()
        {
            // walk through the list and render
            Iterator pIt = this.baseGetIterator();
            Debug.Assert(pIt != null);

            // iterate through the nodes
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                // Downcast (its OK - homogeneous list)
                // Assumes someone before here called update() on each sprite
                SpriteNode pNode = (SpriteNode)pIt.Current();
                pNode.pSprite.Render();
            }
        }
        public void Remove(SpriteNode pSpriteNode)
        {
            Debug.Assert(pSpriteNode != null);
            this.baseRemove(pSpriteNode);
        }
        public void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteNode Man: ------");

            this.baseDump();
        }
        public void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteNode Man: ------");

            this.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }


        //------------------------------------
        // Override Abstract methods
        //------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SpriteNode();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        override protected bool derivedCompare(NodeBase pSpriteNodeBaseA, NodeBase pSpriteNodeBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pSpriteNodeBaseA != null);
            Debug.Assert(pSpriteNodeBaseB != null);

            SpriteNode pDataA = (SpriteNode)pSpriteNodeBaseA;
            SpriteNode pDataB = (SpriteNode)pSpriteNodeBaseB;

            bool status = false;

            if (pDataA.pSprite.GetName() == pDataB.pSprite.GetName())
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(NodeBase pSpriteNodeBase)
        {
            Debug.Assert(pSpriteNodeBase != null);
            SpriteNode pSpriteNode = (SpriteNode)pSpriteNodeBase;
            pSpriteNode.Wash();
        }
        override protected void derivedDumpNode(NodeBase pSpriteNodeBase)
        {
            Debug.Assert(pSpriteNodeBase != null);
            SpriteNode pData = (SpriteNode)pSpriteNodeBase;
            pData.Dump();
        }

        //------------------------------------
        // Private methods
        //------------------------------------


        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SpriteNode psSpriteNodeCompare;

    }
}

// --- End of File ---
