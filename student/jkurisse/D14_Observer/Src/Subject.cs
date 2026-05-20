//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace PA
{
    public class Subject
    {
        public void Notify()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Observer pCurr = this.poHead;

            while (pCurr != null)
            {
                pCurr.Notify();
                pCurr = (Observer)pCurr.pNext;
            }
        }

        public void Detach(Observer pObserver)
        {
            Debug.Assert(pObserver != null);
            Debug.Assert(this.poHead != null);
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Observer pCurr = this.poHead;
            Observer pPrev = null;

            while (pCurr != null)
            {
                if (pCurr == pObserver)
                {
                    if (pCurr == this.poHead && pCurr.pNext == null)
                    {
                        this.poHead = null;
                        break;
                    }
                    else if (pCurr == this.poHead)
                    {
                        pCurr = (Observer)pCurr.pNext;
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
                pCurr = (Observer)pCurr.pNext;

            }
        }

        public void Attach(Observer pObserver)
        {
            Debug.Assert(pObserver != null);
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            pObserver.SetSubject(this);
            Observer pCurr = poHead;
            pObserver.pNext = pCurr;
            poHead = pObserver;
        }

        // Holds the observers with a Single Linked list
        // Add to the front of the list O(1)
        private Observer poHead;
        
    }
}

// --- End of File ---

