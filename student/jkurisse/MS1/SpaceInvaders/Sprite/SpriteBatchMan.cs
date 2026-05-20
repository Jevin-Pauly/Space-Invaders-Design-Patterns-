using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SpriteBatchMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        // LTN - SpriteBatchMan
        private SpriteBatchMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new SLinkMan(), new SLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            psSpriteBatchCompare = new SpriteBatch();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 2, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                // LTN - SpriteBatchMan
                psInstance = new SpriteBatchMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                SpriteBatchMan.DumpStats();
            }
        }

        public static SpriteBatch Add(SpriteBatch.Name name, float priority = 0, int reserveNum = 3, int reserveGrow = 1)
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.basePartialAdd(priority);
            pSpriteBatch.priority = priority;
            Debug.Assert(pSpriteBatch != null);

            // Initialize the data
            pSpriteBatch.Set(name, priority, reserveNum, reserveGrow);

            // Add to the linked list in sorted order
            //pMan.AddSorted(pSpriteBatch);

            return pSpriteBatch;
        }



        public static void Draw()
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            // walk through the list and render
            Iterator pIt = pMan.baseGetIterator();
            Debug.Assert(pIt != null);
            
            // Iterate through the nodes and add them to the list
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                SpriteBatch pSpriteBatch = (SpriteBatch)pIt.Current();
                if (pSpriteBatch.IsEnabled())
                {
                    pSpriteBatch.GetSpriteNodeMan().Draw();
                }
                
                
            }
        }
        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two SpriteBatchs

            // So:  Use the Compare SpriteBatch - as a reference
            //      use in the Compare() function
            SpriteBatchMan.psSpriteBatchCompare.name = name;

            SpriteBatch pData = (SpriteBatch)pMan.baseFind(SpriteBatchMan.psSpriteBatchCompare);
            return pData;
        }
        public static void Remove(SpriteBatch pSpriteBatch)
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSpriteBatch != null);
            pMan.baseRemove(pSpriteBatch);
        }



        public static SpriteBatch UpdatePriority(SpriteBatch.Name name, int priority)
        {
            // Singleton
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Find
            SpriteBatch pNode = SpriteBatchMan.Find(name);
            Debug.Assert(pNode != null);

            // Remove without washing
            pMan.basePartialRemove(pNode);

            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.basePartialAdd(priority);
            pSpriteBatch.priority = priority;
            return pSpriteBatch;
        }






        public static void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteBatch Man: ------");

            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();

        }
        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteBatch Man: ------");

            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }


        //------------------------------------
        // Override Abstract methods
        //------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            // LTN - SpriteBatchMan
            NodeBase pNodeBase = new SpriteBatch();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        override protected bool derivedCompare(NodeBase pSpriteBatchBaseA, NodeBase pSpriteBatchBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pSpriteBatchBaseA != null);
            Debug.Assert(pSpriteBatchBaseB != null);

            SpriteBatch pDataA = (SpriteBatch)pSpriteBatchBaseA;
            SpriteBatch pDataB = (SpriteBatch)pSpriteBatchBaseB;

            bool status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(NodeBase pSpriteBatchBase)
        {
            Debug.Assert(pSpriteBatchBase != null);
            SpriteBatch pSpriteBatch = (SpriteBatch)pSpriteBatchBase;
            pSpriteBatch.Wash();
        }
        override protected void derivedDumpNode(NodeBase pSpriteBatchBase)
        {
            Debug.Assert(pSpriteBatchBase != null);
            SpriteBatch pData = (SpriteBatch)pSpriteBatchBase;
            pData.Dump();
        }

        //------------------------------------
        // Private methods
        //------------------------------------

        private static SpriteBatchMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SpriteBatch psSpriteBatchCompare;
        private static SpriteBatchMan psInstance = null;
    }
}

