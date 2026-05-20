//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Vehicle 
    {
        public void Attach(Element pElement)
        {
            Debug.Assert(pElement != null);

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            Element pCurr = this.poHead;

            pElement.pNext = pCurr;
            this.poHead = pElement;
        }

        public void Detach(Element pElement)
        {
            Debug.Assert(pElement != null);

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            Element pCurr = this.poHead;
            Element pPrev = null;

            while (pCurr != null)
            {
                if (pCurr == pElement)
                {
                    if (pCurr == this.poHead && pCurr.pNext == null)
                    {
                        this.poHead = null;
                        break;
                    }
                    else if (pCurr == this.poHead)
                    {
                        pCurr = (Element)pCurr.pNext;
                        this.poHead = null;
                        this.poHead = pCurr;
                        break;
                    }
                    else
                    {
                        pPrev.pNext = pCurr.pNext;
                        pCurr = null;
                        break;
                    }
                }
                pPrev = pCurr;                    
                pCurr = (Element)pCurr.pNext;

            }
        }

        public void Accept(Visitor visitor)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Element current = poHead;
            while (current != null)
            {
                current.Accept(visitor);
                current = (Element)current.pNext;
            }
        }
        

        // Holds the Elements with a Single Linked list
        // Add to the front of the list O(1)
        public Element poHead;
    }
}

// --- End of File ---

