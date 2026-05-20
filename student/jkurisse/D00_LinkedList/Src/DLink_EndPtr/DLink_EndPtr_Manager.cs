//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class DLink_EndPtr_Manager 
    {
        public DLink_EndPtr_Manager()
        {
            this.poHead = null;
            this.pEnd = null;
        }

        public void AddToFront(DLink _pNode)
        {
            //If value to be added is null
            if (_pNode == null)
                return;

            //If list is empty
            if (poHead == null)
            {
                poHead = _pNode;
                pEnd = _pNode;
            }
            //If list is not empty
            else
            {
                _pNode.pNext = poHead;
                poHead.pPrev = _pNode;
                //Update head
                poHead = _pNode;
            }
        }

        public void AddToEnd(DLink _pNode)
        {
            if (_pNode == null)
                return;

            //If list is empty
            if (poHead == null)
            {
                poHead = _pNode;
                pEnd = _pNode;
            }
            //If list is not empty
            else
            {
                _pNode.pPrev = pEnd;
                pEnd.pNext = _pNode;
                //Update end
                pEnd = _pNode;
            }
        }

        public void Remove(DLink _pNode)
        {
            if (_pNode == null || poHead == null)
                return;

            //If node to remove is head
            if (_pNode == poHead)
            {
                DLink temp = poHead;
                poHead = poHead.pNext;
                poHead.pPrev = null;
                temp = null;
            }

            //If node to remove is end
            else if (_pNode == pEnd)
            {
                DLink temp = pEnd;
                pEnd = pEnd.pPrev;
                pEnd.pNext = null;
                temp = null;
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
            //If list is null
            if (poHead == null)
                return null;

            DLink temp = poHead;

            //If only one value
            if (poHead.pNext == null)
            {
                poHead = null;
                pEnd = null;
            }
            //If more than one value
            else
            {
                poHead.pNext.pPrev = null;
                poHead = poHead.pNext;
            }

            temp.pNext = temp.pPrev = null;

            return temp;
        }

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public DLink poHead;
        public DLink pEnd;

    }
}

// --- End of File ---
