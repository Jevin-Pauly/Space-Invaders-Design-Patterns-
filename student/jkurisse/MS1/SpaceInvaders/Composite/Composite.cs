using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class Composite : GameObject
    {
        public Composite()
            : base(Component.Container.COMPOSITE, GameObject.Name.Null_Object, SpriteGame.Name.Null_Object)
        {
            // LTN - Composite
            this.poDLinkMan = new DLinkMan();
        }

        public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.AddToFront(pComponent);

            pComponent.pParent = this;

            GameObjectNodeMan.Attach((GameObject)pComponent);
        }

        public Component GetHead()
        {
            Debug.Assert(this.poDLinkMan != null);
            Component pHead = (GameObject)this.poDLinkMan.poHead;
            return pHead;
        }

        public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.Remove(pComponent);
        }


        //public void Move(float _x, float _y)
        //{
        //    Iterator pIt = this.poDLinkMan.GetIterator();
        //    Debug.Assert(pIt != null);
        //
        //    for (pIt.First(); !pIt.IsDone(); pIt.Next())
        //    {
        //        GameObject pNode = (GameObject)pIt.Current();
        //        Debug.Assert(pNode != null);
        //
        //        pNode.Move(_x, _y);
        //    }
        //}
        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Composite:");

            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
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


        protected DLinkMan poDLinkMan;
    }
}

// --- End of File ---
