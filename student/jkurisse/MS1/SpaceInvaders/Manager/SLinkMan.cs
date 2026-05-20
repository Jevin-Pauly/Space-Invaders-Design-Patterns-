using SpaceInvaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SLinkMan : ListBase
    {
        public SLinkMan()
        {
            // LTN - SLinkMan
            this.poIterator = new SLinkIterator();
            this.poHead = null;
        }
        override public void AddToFront(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);

            SLink pNode = (SLink)_pNode;
            // add node
            if (poHead == null)
            {
                // push to the front
                poHead = pNode;
                pNode.pNext = null;
            }
            else
            {
                // push to front
                pNode.pNext = poHead;

                // update head
                poHead = pNode;
            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        public void AddToEnd(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;

            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = pNode;
                pNode.pNext = null;
            }
            else
            {
                // spin until end
                SLink pTmp = poHead;
                //SLink pLast = pTmp;
                while (pTmp.pNext != null)
                {
                    //pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                // push to front
                pTmp.pNext = pNode;
                pNode.pNext = null;

            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        override public void AddPriority(NodeBase _pNode, float priority)
        {
            // add to front
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;
        
            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = (SLink)_pNode;
                poHead.pNext = null;
                return;
            }
            // Traverse the list to find the correct position based on priority
            SLink pTmp = poHead;
            SLink pPrev = null;
            while (pTmp != null && pTmp.priority <= priority)
            {
                pPrev = pTmp;
                pTmp = pTmp.pNext;
            }
        
            // Insert the node before the current node (or at the end if there's no higher priority node)
            if (pPrev == null)
            {
                // Insert at the beginning
                ((SLink)_pNode).pNext = poHead;
                poHead = (SLink)_pNode;
            }
            else
            {
                // Insert between pPrev and pTmp
                pPrev.pNext = (SLink)_pNode;
                ((SLink)_pNode).pNext = pTmp;
            }
            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        override public void Remove(NodeBase _pNode)
        {
            // There should always be something on list
            Debug.Assert(poHead != null);
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;

            // four cases

            if (poHead == pNode && pNode.pNext == null)
            {   // Only node
                poHead = null;
            }
            else if (poHead == pNode)
            {   // First node
                poHead = pNode.pNext;
            }
            else if (pNode.pNext == null)
            {   // Last node
                SLink pTemp = poHead;
                while (pTemp.pNext != pNode)
                {
                    pTemp = pTemp.pNext;
                }
                // pTemp is the node before the last node
                pTemp.pNext = null;
            }
            else // (pNode.pPrev != null && pNode.pNext != null)
            {   // Middle node
                SLink pTemp = poHead;
                while (pTemp.pNext != pNode)
                {
                    pTemp = pTemp.pNext;
                }
                // Link prev node (pTemp) to next next node (pNode.pNext)
                pTemp.pNext = pNode.pNext;
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();
        }


        public override void PartialRemove(NodeBase _pNode)
        {
            //// There should always be something on list
            //Debug.Assert(poHead != null);
            //Debug.Assert(_pNode != null);
            //SLink pNode = (SLink)_pNode;
            //
            //// four cases
            //
            //if (poHead == pNode && pNode.pNext == null)
            //{   // Only node
            //    poHead = null;
            //}
            //else if (poHead == pNode)
            //{   // First node
            //    poHead = pNode.pNext;
            //}
            //else if (pNode.pNext == null)
            //{   // Last node
            //    SLink pTemp = poHead;
            //    while (pTemp.pNext != pNode)
            //    {
            //        pTemp = pTemp.pNext;
            //    }
            //    // pTemp is the node before the last node
            //    pTemp.pNext = null;
            //}
            //else // (pNode.pPrev != null && pNode.pNext != null)
            //{   // Middle node
            //    SLink pTemp = poHead;
            //    while (pTemp.pNext != pNode)
            //    {
            //        pTemp = pTemp.pNext;
            //    }
            //    // Link prev node (pTemp) to next next node (pNode.pNext)
            //    pTemp.pNext = pNode.pNext;
            //}
        }







        override public NodeBase RemoveFromFront()
        {
            // There should always be something on list
            Debug.Assert(poHead != null);

            // return node
            SLink pNode = poHead;

            // Update head (OK if it points to NULL)
            poHead = poHead.pNext;
            //if (poHead != null)
            //{
            //    poHead.pPrev = null;
            //    // do not change pEnd
            //}
            //else
            //{
            //    // only one on the list
            //    // pHead == null
            //}

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();

            return pNode;
        }

        // HACK
        //override public NodeBase GetFirst()
        //{
        //    // can be null
        //    return poHead;
        //}

        override public Iterator GetIterator()
        {
            Debug.Assert(this.poIterator != null);
            this.poIterator.Reset(this.poHead);

            return this.poIterator;
        }

        //public void Dump()
        //{
        //    Debug.WriteLine("SLinkMan: \n");
        //    SLink pTmp = this.poHead;
        //    while (pTmp != null)
        //    {
        //        Node pNode = (Node)pTmp;
        //        pNode.Dump();
        //
        //        pTmp = pTmp.pNext;
        //    }
        //
        //
        //    Debug.WriteLine("----- \n");
        //}

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public SLink poHead;
        public SLinkIterator poIterator;
    }
}