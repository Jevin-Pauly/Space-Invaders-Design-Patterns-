//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using SE456;
using System;
using System.Diagnostics;
using static SpaceInvaders.Node;
using System.Windows.Shapes;

namespace SpaceInvaders
{
    public class Manager
    {
        public NodeBase GetActiveHead()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poActive.GetFirst();
        }
        public NodeBase GetReserveHead()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poReserve.GetFirst();
        }
        public int GetDeltaGrow()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return this.mDeltaGrow;
        }
        public int GetTotalNumNodes()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return this.mTotalNumNodes;
        }
        public int GetNumReserved()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return this.mNumReserved;

        }
        public int GetNumActive()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return this.mNumActive;
        }

        public Manager(int _InitialNumReserved = 5, int _DeltaGrow = 2)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            // Check now or pay later
            Debug.Assert(_InitialNumReserved >= 0);
            Debug.Assert(_DeltaGrow > 0);

            // Initialize all variables
            this.mDeltaGrow = _DeltaGrow;
            this.mNumReserved = 0;
            this.mNumActive = 0;
            this.mTotalNumNodes = 0;
            this.poActive = new SLinkMan();
            this.poReserve = new SLinkMan();

            // Preload the reserve
            this.privFillReservedPool(_InitialNumReserved);
        }
        public Node Add(Node.Name _name, int _val)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            // Are there any nodes on the Reserve list?
            if (poReserve.GetFirst() == null)
            {
                // refill the reserve list by the DeltaGrow
                this.privFillReservedPool(this.mDeltaGrow);
            }

            // Always take from the reserve list
            NodeBase pNodeBase = poReserve.RemoveFromFront();
            Debug.Assert(pNodeBase != null);

            // Update stats
            this.mNumActive++;
            this.mNumReserved--;

            // Fill the node with data
            Node pNode = (Node)pNodeBase;
            pNode.Set(_name, _val);

            // copy to active
            poActive.AddToFront(pNode);

            // YES - here's your new one (may its reused from reserved)
            return pNode;
        } 

        public Node Find(Node.Name _name)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            // search the active list
            SLink pNode = (SLink)poActive.GetFirst();
            // Found node
            Node pData = null;

            // Walk through the nodes
            while (pNode != null)
            {
                // Downcast (its OK - homogeneous list)
                Node pTmp = (Node)pNode;
                if (pTmp.name == _name)
                {
                    // found it
                    pData = pTmp;
                    break;
                }
                pNode = pNode.pNext;
            }

            return pData;
        }
        public void Remove(Node pNode)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Debug.Assert(pNode != null);

            // Don't do the work here... delegate it
            poActive.Remove(pNode);

            // wash it before returning to reserve list
            pNode.Wash();

            // add it to the return list
            poReserve.AddToFront(pNode);

            // stats update
            this.mNumActive--;
            this.mNumReserved++;
        }

        private void privFillReservedPool(int count)
        {
            // doesn't make sense if its not at least 1
            Debug.Assert(count >= 0);

            this.mTotalNumNodes += count;
            this.mNumReserved += count;

            // Preload the reserve
            for (int i = 0; i < count; i++)
            {
                NodeBase pNode = this.privCreateNode();
                Debug.Assert(pNode != null);

                poReserve.AddToFront(pNode);
            }
        }
        private NodeBase privCreateNode()
        {
            NodeBase pNode = new Node(Node.Name.Unitialized, 0);
            Debug.Assert(pNode != null);

            return pNode;
        }

        // ------------------------------
        // Add Data here
        // ------------------------------
        private ListBase poActive;
        private ListBase poReserve;
        private readonly int mDeltaGrow;
        private int mTotalNumNodes;
        private int mNumReserved;
        private int mNumActive;
    }
}

// --- End of File ---
