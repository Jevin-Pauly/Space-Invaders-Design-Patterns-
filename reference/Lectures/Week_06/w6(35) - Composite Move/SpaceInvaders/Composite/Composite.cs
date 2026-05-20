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
        protected Composite(GameObject.Name gameName, SpriteGameProxy pProxy)
            : base(gameName, pProxy)
        {
            this.poDLinkMan = new DLinkMan();
        }

        public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.AddToFront(pComponent);

            GameObjectNodeMan.Attach((GameObject)pComponent);
        }

        public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.Remove(pComponent);
        }


        public override void Move(float _x, float _y)
        {
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);

                pNode.Move(_x, _y);
            }
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

                pNode.Print();
            }
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }


        protected DLinkMan poDLinkMan;
    }
}

// --- End of File ---
