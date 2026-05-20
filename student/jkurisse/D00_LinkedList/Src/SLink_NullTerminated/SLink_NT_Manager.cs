//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class SLink_NT_Manager 
    {
        public SLink_NT_Manager()
        {
            this.poHead = null;
        }

        public void AddToFront(SLink _pNode)
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
                //Update head
                poHead = _pNode;
            }
        }
        public void AddToEnd(SLink _pNode)
        {
            if (_pNode == null)
                return;

            //If list is empty
            if (poHead == null)
            {
                poHead = _pNode;
                poHead.pNext = null;
            }
            //If list is not empty
            else
            {
                SLink temp = poHead;
                while (temp != null)
                {
                    if (temp.pNext == null)
                    {
                        temp.pNext = _pNode;
                        _pNode.pNext = null;
                    }
                    temp = temp.pNext;
                }
            }

        }

        public void Remove(SLink _pNode)
        {
            if (_pNode == null || poHead == null)
                return;

            //If node to remove is head
            if (_pNode == poHead)
            {
                SLink temp = poHead;
                poHead = poHead.pNext;
                temp = null;
            }
            //If any other node is to be removed
            else
            {
                SLink temp = poHead;
                while (temp != null)
                {
                    if (temp.pNext == _pNode)
                    {
                        temp.pNext = _pNode.pNext;
                        _pNode.pNext = null;
                    }
                    temp = temp.pNext;
                }
            }
        }

        public SLink RemoveFromFront()
        {
            //If list is null
            if (poHead == null)
                return null;

            SLink temp = poHead;

            //If only one value
            if (poHead.pNext == null)
            {
                poHead = null;
            }
            //If more than one value
            else
            {
                poHead = poHead.pNext;
            }

            temp.pNext = null;

            return temp;
        }

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public SLink poHead;
    }
}

// --- End of File ---
