using Azul;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SpriteNodeMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        // LTN - SpriteNodeMan
        public SpriteNodeMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new SLinkMan(), new SLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            psSpriteNodeCompare = new SpriteNode();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void Set(SpriteBatch.Name name, int reserveNum, int reserveGrow)
        {
            this.name = name;

            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            this.baseSetReserve(reserveNum, reserveGrow);
        }



        //public SpriteNode Attach(SpriteGame.Name pNode)
        //{
        //    SpriteNode pSpriteNode = (SpriteNode)this.baseAdd();
        //    Debug.Assert(pSpriteNode != null);
        //
        //    // Initialize the data
        //    pSpriteNode.Set(name);
        //    return pSpriteNode;
        //}

        public SpriteNode Attach(SpriteBase pNode)
        {
            SpriteNode pSpriteNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pSpriteNode != null);

            // Initialize the data
            pSpriteNode.Set(pNode);
            return pSpriteNode;
        }

        public SpriteNode Attach(SpriteGameProxy pNode)
        {
            // Go to Man, get a node from reserve, add to active, return it
            SpriteNode pSpriteNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pSpriteNode != null);

            // Initialize SpriteBatchNode
            pSpriteNode.Set(pNode);

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
                pNode.pSpriteBase.Render();
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
            // LTN - SpriteNodeMan
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

            if (pDataA.pSpriteBase.GetName() == pDataB.pSpriteBase.GetName())
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
        private SpriteBatch.Name name;
    }
}
