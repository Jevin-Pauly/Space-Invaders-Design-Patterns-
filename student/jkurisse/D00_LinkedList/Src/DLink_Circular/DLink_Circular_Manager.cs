//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class DLink_Circular_Manager 
    {
        public DLink_Circular_Manager()
        {
            this.poHead = null;
        }

        public void AddToFront(DLink _pNode)
        {
            //If data is null
            if (_pNode == null)
            {
                return;
            }

            //If list empty
            if (poHead == null)
            {
                _pNode.pNext = _pNode;
                _pNode.pPrev = _pNode;
                poHead = _pNode;
                return;
            }
            
            //If list has items
            _pNode.pNext = poHead;
            _pNode.pPrev = poHead.pPrev;
            poHead.pPrev.pNext = _pNode;
            poHead.pPrev = _pNode;
            poHead = _pNode;
        }

        public void AddToEnd(DLink _pNode)
        {
            //If data is null
            if (_pNode == null)
            {
                return;
            }

            //If list empty
            if (poHead == null)
            {
                _pNode.pNext = _pNode;
                _pNode.pPrev = _pNode;
                poHead = _pNode;
                return;
            }

            //If list has items
            _pNode.pNext = poHead;
            _pNode.pPrev = poHead.pPrev;
            poHead.pPrev.pNext = _pNode;
            poHead.pPrev = _pNode;
            //Same as add to front except we dont move poHead to new node
        }

        public void Remove(DLink _pNode)
        {
            //If list or remove value is null
            if (_pNode == null || poHead == null)
            {
                return;
            }

            //If head is the value to be removed
            if (poHead == _pNode)
            {
                poHead.pPrev.pNext = poHead.pNext;
                poHead.pNext.pPrev = poHead.pPrev;

                //Store next
                DLink temp = poHead.pNext;
                //If only one node
                if (poHead == poHead.pNext)
                {
                    poHead.pNext = poHead.pPrev = poHead = null;
                }
                //If more than one node move head to next node
                else
                {
                    poHead.pNext = poHead.pPrev = poHead = null;
                    poHead = temp;
                }
                return;
            }

            //If any other value is to be removed
            else
            {
                DLink temp = _pNode;
                _pNode.pPrev.pNext = _pNode.pNext;
                _pNode.pNext.pPrev = _pNode.pPrev;
                temp = null;
            }

        }
        public DLink RemoveFromFront()
        {
            //If list or remove value is null
            if (poHead == null)
            {
                return null;
            }

            DLink temp = poHead;

            if (poHead.pNext == poHead)
            {
                poHead = null;
            }
            else
            {
                poHead.pNext.pPrev = poHead.pPrev;
                poHead.pPrev.pNext = poHead.pNext;
                poHead = poHead.pNext;
                temp.pPrev = temp.pNext = null;
            }

            return temp;
        }

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public DLink poHead;
    }
}

// --- End of File ---
