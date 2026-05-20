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
        private SpriteNodeMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            psSpriteNodeCompare = new SpriteNode();
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
                psInstance = new SpriteNodeMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
            SpriteNodeMan pMan = SpriteNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton

            SpriteNodeMan.DumpStats();
        }
        public static SpriteNode Attach(Sprite.Name name)
        {
            SpriteNodeMan pMan = SpriteNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            SpriteNode pSpriteNode = (SpriteNode)pMan.baseAdd();
            Debug.Assert(pSpriteNode != null);

            // Initialize the data
            pSpriteNode.Set(name);
            return pSpriteNode;
        }

        public static void Draw()
        {
            SpriteNodeMan pMan = SpriteNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // walk through the list and render
            Iterator pIt = pMan.baseGetIterator();
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
        public static void Remove(SpriteNode pSpriteNode)
        {
            SpriteNodeMan pMan = SpriteNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSpriteNode != null);
            pMan.baseRemove(pSpriteNode);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteNode Man: ------");

            SpriteNodeMan pMan = SpriteNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();

        }
        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteNode Man: ------");

            SpriteNodeMan pMan = SpriteNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

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
        private static SpriteNodeMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SpriteNode psSpriteNodeCompare;
        private static SpriteNodeMan psInstance = null;
    }
}

// --- End of File ---
