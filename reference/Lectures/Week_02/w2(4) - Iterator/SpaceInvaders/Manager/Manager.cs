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
            Iterator pIt = poReserve.GetIterator();
            Debug.Assert(pIt != null);

            // Are there any nodes on the Reserve list?
            if (pIt.First() == null)
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
            Iterator pIt = poActive.GetIterator();
            Debug.Assert(pIt != null);

            // Found node
            Node pData = null;

            // iterate through the nodes
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                // Downcast (its OK - homogeneous list)
                Node pTmp = (Node)pIt.Current();
                if (pTmp.name == name)
                {
                    // found it
                    pData = pTmp;
                    break;
                }
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

            Iterator pItActive = poActive.GetIterator();
            Debug.Assert(pItActive != null);

            Node pNodeActive = (Node)pItActive.First();
            if (pNodeActive == null)
            {
                Debug.WriteLine("    Active Head: null");
            }
            else
            {
                Debug.WriteLine("    Active Head:  {0} ({1})", pNodeActive.name, pNodeActive.GetHashCode());
            }

            Iterator pItReserve = poReserve.GetIterator();
            Debug.Assert(pItReserve != null);

            Node pNodeReserve = (Node)pItReserve.First();
            if (pNodeReserve == null)
            {
                Debug.WriteLine("   Reserve Head: null\n");
            }
            else
            {
                Debug.WriteLine("   Reserve Head:  {0} ({1})\n", pNodeReserve.name, pNodeReserve.GetHashCode());
            }

            Debug.WriteLine("   ------ Active List: -----------\n");


            int i = 0;

           // iterate through the nodes
           for (pItActive.First(); !pItActive.IsDone(); pItActive.Next())
            {
                Debug.WriteLine("   {0}: -------------", i);
                Node pTmp = (Node)pItActive.Current();

                pTmp.Dump();
                i++;
            }

            Debug.WriteLine("");
            Debug.WriteLine("   ------ Reserve List: ----------\n");

            i = 0;
            // iterate through the nodes
            for (pItReserve.First(); !pItReserve.IsDone(); pItReserve.Next())
            {
                Debug.WriteLine("   {0}: -------------", i);
                Node pTmp = (Node)pItReserve.Current();

                pTmp.Dump();
                i++;
            }

            Debug.WriteLine("\n   ****** Manager End ******************\n");
        }

        // ------------------------------------
        // Data:
        // ------------------------------------

        private ListBase poActive;
        private ListBase poReserve;
        private readonly int mDeltaGrow;
        private int mTotalNumNodes;
        private int mNumReserved;
        private int mNumActive;

    }
}

// --- End of File ---
