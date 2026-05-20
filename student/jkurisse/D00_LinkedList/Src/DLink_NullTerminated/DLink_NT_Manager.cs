//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class DLink_NT_Manager 
    {
        public DLink_NT_Manager()
        {
            this.poHead = null;
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
            }
            //If list is not empty
            else
            {
                DLink temp = poHead;
                while (temp != null)
                {
                    if(temp.pNext == null)
                    {
                        temp.pNext = _pNode;
                        _pNode.pPrev = temp;
                        _pNode.pNext = null;
                    }
                    temp = temp.pNext;
                }
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
            //If any other node is to be removed
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
    }
}

// --- End of File ---
