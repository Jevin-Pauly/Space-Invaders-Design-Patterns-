//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class DLinkMan : ListBase
    {
        public DLinkMan()
            : base()
        {
            this.poIterator = new DLinkIterator();
            this.poHead = null;
        }
        override public void AddToFront(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);

            DLink pNode = (DLink)_pNode;
            // add node
            if (poHead == null)
            {
                // push to the front
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = poHead;

                // update head
                poHead.pPrev = pNode;
                poHead = pNode;
            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        public void AddToEnd(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;

            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // spin until end
                DLink pTmp = poHead;
                DLink pLast = pTmp;
                while (pTmp != null)
                {
                    pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                // push to front
                pLast.pNext = pNode;
                pNode.pPrev = pLast;
                pNode.pNext = null;

            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        override public void Remove(NodeBase _pNode)
        {
            // There should always be something on list
            //Debug.Assert(poHead != null);
            Debug.Assert(_pNode != null);
            if (this.poHead != null)
            {
                DLink pNode = (DLink)_pNode;

                // four cases

                if (pNode.pPrev == null && pNode.pNext == null)
                {   // Only node
                    poHead = null;
                }
                else if (pNode.pPrev == null && pNode.pNext != null)
                {   // First node
                    poHead = pNode.pNext;
                    pNode.pNext.pPrev = pNode.pPrev;
                }
                else if (pNode.pPrev != null && pNode.pNext == null)
                {   // Last node
                    pNode.pPrev.pNext = pNode.pNext;
                }
                else // (pNode.pPrev != null && pNode.pNext != null)
                {   // Middle node
                    pNode.pNext.pPrev = pNode.pPrev;
                    pNode.pPrev.pNext = pNode.pNext;
                }

                // remove any lingering links
                // HUGELY important - otherwise its crossed linked 
                pNode.Clear();
            }
            return;
        }
        override public NodeBase RemoveFromFront()
        {
            // There should always be something on list
            Debug.Assert(poHead != null);

            // return node
            DLink pNode = poHead;

            // Update head (OK if it points to NULL)
            poHead = poHead.pNext;
            if (poHead != null)
            {
                poHead.pPrev = null;
                // do not change pEnd
            }
            else
            {
                // only one on the list
                // pHead == null
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();

            return pNode;
        }

        override public void AddPriority(NodeBase _pNode, float priority)
        {
            // Add to front
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;

            // Add node
            if (poHead == null)
            {
                // None on list, so add it
                poHead = (DLink)_pNode;
                poHead.pNext = null;
                poHead.pPrev = null;
                return;
            }

            // Traverse the list to find the correct position based on priority
            DLink pTmp = poHead;
            DLink pPrev = null;
            while (pTmp != null && pTmp.priority <= priority)
            {
                pPrev = pTmp;
                pTmp = (DLink)pTmp.pNext;
            }

            // Insert the node before the current node (or at the end if there's no higher priority node)
            if (pPrev == null)
            {
                // Insert at the beginning
                pNode.pNext = poHead;
                pNode.pPrev = null;
                poHead.pPrev = pNode;
                poHead = pNode;
            }
            else
            {
                // Insert between pPrev and pTmp
                pNode.pNext = pTmp;
                pNode.pPrev = pPrev;
                pPrev.pNext = pNode;

                // Check if pTmp is not null, then set its previous link to the new node
                if (pTmp != null)
                    pTmp.pPrev = pNode;
            }

            // Worst case, poHead was null initially, now we added a node so this is true
            Debug.Assert(poHead != null);
        }

        override public Iterator GetIterator()
        {
            Debug.Assert(this.poIterator != null);
            this.poIterator.Reset(this.poHead);

            return this.poIterator;
        }

        public override void PartialRemove(NodeBase pNode)
        {
        }

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public DLink poHead;
        public DLinkIterator poIterator;
    }
}

// --- End of File ---
