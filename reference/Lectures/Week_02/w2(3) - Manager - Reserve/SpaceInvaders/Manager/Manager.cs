//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class Manager
    {
        public Manager(ListBase _poActive, ListBase _poReserve, int InitialNumReserved = 5, int DeltaGrow = 2)
        {
            // Check now or pay later
            Debug.Assert(_poActive != null);
            Debug.Assert(_poReserve != null);
            Debug.Assert(InitialNumReserved >= 0);
            Debug.Assert(DeltaGrow > 0);

            // Initialize all variables
            this.mDeltaGrow = DeltaGrow;
            this.mNumReserved = 0;
            this.mNumActive = 0;
            this.mTotalNumNodes = 0;
            this.poActive = _poActive;
            this.poReserve = _poReserve;

            // Preload the reserve
            this.privFillReservedPool(InitialNumReserved);
        }
        public Node Add(Node.Name name, int val)
        {
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
            pNode.Set(name, val);

            // copy to active
            poActive.AddToFront(pNode);

            // YES - here's your new one (may its reused from reserved)
            return pNode;
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
        public Node Find(Node.Name name)
        {
            // search the active list
            DLink pNode = (DLink)poActive.GetFirst();
            // Found node
            Node pData = null;

            // Walk through the nodes
            while (pNode != null)
            {
                // Downcast (its OK - homogeneous list)
                Node pTmp = (Node)pNode;
                if (pTmp.name == name)
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
        public void Dump()
        {
            Debug.WriteLine("");
            Debug.WriteLine("   ****** Manager Begin ****************\n");

            Debug.WriteLine("         mDeltaGrow: {0} ", mDeltaGrow);
            Debug.WriteLine("     mTotalNumNodes: {0} ", mTotalNumNodes);
            Debug.WriteLine("       mNumReserved: {0} ", mNumReserved);
            Debug.WriteLine("         mNumActive: {0} \n", mNumActive);

            Node pDataAct = (Node)poActive.GetFirst();
            if (pDataAct == null)
            {
                Debug.WriteLine("    Active Head: null");
            }
            else
            {
                Debug.WriteLine("    Active Head:  {0} ({1})", pDataAct.name, pDataAct.GetHashCode());
            }

            Node pDataRes = (Node)poReserve.GetFirst();
            if (pDataRes == null)
            {
                Debug.WriteLine("   Reserve Head: null\n");
            }
            else
            {
                Debug.WriteLine("   Reserve Head:  {0} ({1})\n", pDataRes.name, pDataRes.GetHashCode());
            }

            Debug.WriteLine("   ------ Active List: -----------\n");

            DLink pNode = (DLink)poActive.GetFirst();

            int i = 0;
            while (pNode != null)
            {
                Node pData = (Node)pNode;
                Debug.WriteLine("   {0}: -------------", i);
                pData.Dump();
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("   ------ Reserve List: ----------\n");

            pNode = (DLink)poReserve.GetFirst();
            i = 0;
            while (pNode != null)
            {
                Node pData = (Node)pNode;
                Debug.WriteLine("   {0}: -------------", i);
                pData.Dump();
                i++;
                pNode = pNode.pNext;
            }
            Debug.WriteLine("\n   ****** Manager End ******************\n");
        }

        // Data: -------------------------------------------
        private ListBase poActive;
        private ListBase poReserve;
        private readonly int mDeltaGrow;
        private int mTotalNumNodes;
        private int mNumReserved;
        private int mNumActive;

    }
}

// --- End of File ---
