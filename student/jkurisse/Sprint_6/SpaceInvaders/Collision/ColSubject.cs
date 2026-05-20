//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ColSubject
    {
        public ColSubject()
        {
            this.pObjB = null;
            this.pObjA = null;
            this.dummyObjA = null;
            this.dummyObjB = null; 
            //this.pHead = null;
            this.poSLinkMan = new SLinkMan();
            Debug.Assert(this.poSLinkMan != null);
        }

        ~ColSubject()
        {
            this.pObjB = null;
            this.pObjA = null;
            // ToDo
            // Need to walk and nuke the list
            //this.pHead = null;
        }

        public void Attach(ColObserver pObserver)
        {
            // protection
            Debug.Assert(pObserver != null);

            Debug.Assert(this.poSLinkMan != null);
            this.poSLinkMan.AddToFront(pObserver);

            pObserver.pSubject = this;

        }

        public void Notify()
        {
            //if (this.dummyObjA != this.pObjA || this.dummyObjB != this.pObjB)
            //{
                Iterator It = this.poSLinkMan.GetIterator();
                for (It.First(); !It.IsDone(); It.Next())
                {
                    ColObserver pNode = (ColObserver)It.Current();
                    Debug.Assert(pNode != null);

                    // Fire off the listener
                    pNode.Notify();
                }
            //}
            //this.dummyObjA = this.pObjA;
            //this.dummyObjB = this.pObjB;
        }

        public void Detach(ColObserver pObserver)
        {
            Debug.Assert(pObserver != null);

            this.poSLinkMan.Remove(pObserver);
        }


        // Data: ------------------------
        private SLinkMan poSLinkMan;
        public GameObject pObjA;
        public GameObject pObjB;
        public GameObject dummyObjA;
        public GameObject dummyObjB;

    }
}

// --- End of File ---
