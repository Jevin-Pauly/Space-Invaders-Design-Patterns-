//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

// -----------------------------------------------
// Add CODE/REFACTOR here
// -----------------------------------------------
//    Fill in methods
//    Add additional methods if desired
//    Add additional data if desired
// -----------------------------------------------

namespace PA
{
    class PriorityQueue
    {
        public Node GetHead()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            return (Node)poHead;
        }

        public void Remove( Node pNode )
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (poHead != null)
            {
                //Only Node
                if (poHead == pNode && poHead.pNext == null)
                {
                    poHead = null;
                }
                //First Node
                else if (poHead == pNode)
                {
                    poHead = poHead.pNext;
                    poHead.pPrev = null;
                }
                //Others
                else
                {
                    pNode.pPrev.pNext = pNode.pNext;
                    if (pNode.pNext != null)
                    {
                        pNode.pNext.pPrev = pNode.pPrev;
                    }
                }
                pNode.pPrev = null;
                pNode.pNext = null;
            }
           
        }
        public void Insert( Node pNode )
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (poHead == null)
            {
                poHead = pNode;
                return;
            }

            
            Node current = (Node)poHead;

            while (current != null)
            {
                // Compare
                if (pNode.key < current.key)
                {
                    // Insert pNode before the current node
                    pNode.pNext = current;
                    pNode.pPrev = current.pPrev;
                    if (current.pPrev != null)
                    {
                        current.pPrev.pNext = pNode;
                    }
                    else
                    {
                        // Update poHead
                        poHead = pNode;
                    }
                    current.pPrev = pNode;
                    return;
                }

                //Iterate until next is null
                if (current.pNext == null)
                {
                    break;
                }
                current = (Node)current.pNext;
            }

            // Insert it at the end of the list
            pNode.pPrev = null;
            pNode.pNext = null;
            current.pNext = pNode;
            pNode.pPrev = current;
        }

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        public DLink poHead;
    }
}

// --- End of File ---

