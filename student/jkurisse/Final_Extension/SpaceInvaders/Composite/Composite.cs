//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class Composite : GameObject
    {
        public Composite()
            : base(Component.Container.COMPOSITE,
                  GameObject.Name.NullObject,
                  SpriteGame.Name.NullObject)
        {
            this.poDLinkMan = new DLinkMan();
        }

        public Composite(GameObject.Name name, SpriteGame.Name spriteName)
        : base(Component.Container.COMPOSITE,
               name,
               spriteName)
        {
            this.poDLinkMan = new DLinkMan();
        }

        override public void Resurrect(SpriteGame.Name name)
        {
            // check the DLinkMan
            Debug.Assert(this.poDLinkMan.poHead == null);

            base.Resurrect(name);
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.AddToFront(pComponent);

            pComponent.pParent = this;

            //GameObjectNodeMan.Attach((GameObject)pComponent);
        }
        public Component GetHead()
        {
            Debug.Assert(this.poDLinkMan != null);
            Component pHead = (GameObject)this.poDLinkMan.poHead;
            return pHead;
        }

        public override int GetNumChildren()
        {
            int count = 0;

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                count++;
            }

            return count;
        }

        public Component GetLastChild()
        {
            Debug.Assert(this.poDLinkMan != null);

            // Get the head of the child list
            Component pHead = (Component)this.poDLinkMan.poHead;

            if (pHead == null)
            {
                return null;
            }

            // If the head is not a composite, it's the lowest child
            if (!(pHead is Composite))
            {
                return pHead;
            }

            // If the head is a composite, recursively traverse down the hierarchy
            Composite pComposite = (Composite)pHead;
            Component pLastChild = pComposite.GetLastChild();

            // If the last child is null (empty column), return the column
            if (pLastChild == null)
            {
                return pComposite;
            }
            // Return the last non-empty child
            return pLastChild;
        }

        public Component GetSearchedChild(GameObject.Name name)
        {
            // Ensure the DLinkMan is not null
            Debug.Assert(this.poDLinkMan != null);

            // Get the head of the child list
            Component pNode = (Component)this.poDLinkMan.poHead;

            // Traverse the child list to find the first child with the specified name
            while (pNode != null)
            {
                // Check if the current node matches the specified name
                if ((GameObject.Name)pNode.GetName() == name)
                {
                    // Return the node if found
                    return pNode;
                }

                // Move to the next node
                pNode = (Component)pNode.pNext;
            }

            // Return null if no child with the specified name is found
            return null;
        }

        public Component GetFirstChild()
        {
            // Ensure the DLinkMan is not null
            Debug.Assert(this.poDLinkMan != null);

            // Get the head of the child list
            Component pNode = (Component)this.poDLinkMan.poHead;
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                pNode = (Component)pIt.Current();
            }

            // Return pNode if not null
            while (pNode != null)
            {
                // Return the node if found
                return pNode;
            }

            // Return null if no child
            return null;
        }



        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.Remove(pComponent);
        }
        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Composite:");

            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for(pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);

                pNode.Print();
            }
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }

        override public void DumpNode()
        {
            if (IteratorForwardComposite.GetParent(this) != null)
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:{1} <---- Composite", this.GetHashCode(), IteratorForwardComposite.GetParent(this).GetHashCode());
            }
            else
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:null <---- Composite", this.GetHashCode());
            }
        }
        protected DLinkMan poDLinkMan;
    }
}

// --- End of File ---
