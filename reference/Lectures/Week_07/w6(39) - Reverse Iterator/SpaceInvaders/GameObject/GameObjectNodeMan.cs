//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class GameObjectNodeMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private GameObjectNodeMan(int reserveNum, int reserveGrow)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            GameObjectNodeMan.psGameObjectNodeCompare = new GameObjectNode();
            GameObjectNodeMan.psGameObj = new GameObjectNull();
            GameObjectNodeMan.psGameObjectNodeCompare.pGameObj = GameObjectNodeMan.psGameObj;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 8, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new GameObjectNodeMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                GameObjectNodeMan.DumpStats();
            }
        }
        public static GameObjectNode Attach(GameObject pGameObject)
        {
            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pNode = (GameObjectNode)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(pGameObject);
            return pNode;
        }

        public static GameObject Find(GameObject.Name name)
        {
            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            Debug.Assert(GameObjectNodeMan.psGameObjectNodeCompare != null);

            Debug.Assert(GameObjectNodeMan.psGameObjectNodeCompare.pGameObj != null);
            GameObjectNodeMan.psGameObjectNodeCompare.pGameObj.name = name;

            GameObjectNode pData = (GameObjectNode)pMan.baseFind(GameObjectNodeMan.psGameObjectNodeCompare);
            Debug.Assert(pData != null);

            return pData.pGameObj;
        }
        public static void Update()
        {
            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // walk through the list and render
            Iterator pIt = pMan.baseGetIterator();
            Debug.Assert(pIt != null);
            //Debug.WriteLine("\n-------------------------\n");
            for(pIt.First();!pIt.IsDone();pIt.Next())
            {
                GameObjectNode pNode = (GameObjectNode)pIt.Current();
                pNode.pGameObj.Update();
                //Debug.WriteLine(pNode.pGameObj.GetName());
            }
        }
  
        public static void Remove(GameObjectNode pNode)
        {
            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ GameObjectNode Man: ------");

            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }
        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ GameObjectNode Man: ------");

            GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new GameObjectNode();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static GameObjectNodeMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static GameObjectNode psGameObjectNodeCompare;
        private static GameObjectNull psGameObj;
        private static GameObjectNodeMan psInstance = null;

    }
}

// --- End of File ---
