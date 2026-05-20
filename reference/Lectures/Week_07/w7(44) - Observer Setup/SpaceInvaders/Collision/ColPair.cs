//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ColPair : DLink
    {
        public enum Name
        {
            Bird_Missile,
            Alien_Wall,

            NullObject,
            Not_Initialized
        }

        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }

        ~ColPair()
        {

        }
        public void Set(ColPair.Name colpairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = colpairName;
        }
        private void privClear()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }

        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // who is being tested?
                    //Debug.WriteLine("ColPair: test:  {0}, {1}", pNodeA.name, pNodeB.name);

                    // Get rectangles
                    ColRect rectA = pNodeA.poColObj.poColRect;
                    ColRect rectB = pNodeB.poColObj.poColRect;

                    // test them
                    if (ColRect.Intersect(rectA, rectB))
                    {
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)IteratorForwardComposite.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)IteratorForwardComposite.GetSibling(pNodeA);
            }
        }

        //---------------------------------------------------------------------------------------------------------
        // Override
        //---------------------------------------------------------------------------------------------------------

        override public System.Enum GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.privClear();
        }

        //override public bool Compare(NodeBase pTarget)
        //{
        //    // This is used in ManBase.Find() 
        //    Debug.Assert(pTarget != null);

        //    ColPair pDataB = (ColPair)pTarget;

        //    bool status = false;

        //    if (this.name == pDataB.name)
        //    {
        //        status = true;
        //    }

        //    return status;
        //}

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            if (treeA != null)
            {
                Debug.WriteLine("       TreeA: {0}", treeA.GetName());
            }
            else
            {
                Debug.WriteLine("       TreeA: null");
            }

            if (treeB != null)
            {
                Debug.WriteLine("       TreeB: {0}", treeB.GetName());
            }
            else
            {
                Debug.WriteLine("       TreeB: null");
            }

            base.baseDump();
        }

        // Data: ---------------
        public ColPair.Name name;
        public GameObject treeA;
        public GameObject treeB;


    }
}

// --- End of File ---
