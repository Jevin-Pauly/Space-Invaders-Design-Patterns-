//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class Composite : GameObject
    {
        public Composite()
            : base(GameObject.Name.Null_Object, null)
        {
            this.poDLinkMan = new DLinkMan();
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            this.poDLinkMan.AddToFront(pComponent);
        }

        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            this.poDLinkMan.Remove(pComponent);
        }

        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Composite:");

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for(pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();

                // Update the node
                Debug.Assert(pNode != null);

                pNode.Dump();
            }
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }


        private DLinkMan poDLinkMan;
    }
}

// --- End of File ---
