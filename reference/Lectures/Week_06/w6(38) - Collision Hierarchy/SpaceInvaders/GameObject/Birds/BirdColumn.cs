//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class BirdColumn : Composite
    {
        public BirdColumn()
            : base()
        {
            this.name = Name.BirdColumn;

            this.poColObj.pColSprite.SetColor(0, 0, 1);
        }

        public override void Update()
        {
            IteratorComposite pIt = new IteratorComposite(this);
            Debug.Assert(pIt != null);
    

            GameObject pGameObj = (GameObject)IteratorComposite.GetChild(this);

            // create a local pointer
            ColRect pColTotal = this.poColObj.poColRect;

            // Set it to the first child;
            pColTotal.Set(pGameObj.poColObj.poColRect);

            Debug.WriteLine("\n");
            for(pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                pGameObj = (GameObject)pIt.Curr();
                Debug.Assert(pGameObj != null);
                Debug.WriteLine("obj:{0} {1} ", pGameObj.GetHashCode(), pGameObj.GetName());

                // Inside union (x,y,width,height are updated)
                pColTotal.Union(pGameObj.poColObj.poColRect);
            }

            // Transfer to the game object its center
            this.x = this.poColObj.poColRect.x;
            this.y = this.poColObj.poColRect.y;

            Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", pColTotal.x, pColTotal.y, pColTotal.width, pColTotal.height);

            base.Update();

        }

        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Column:");

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            // Walk through the nodes
           for(pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);

                pNode.Dump();
            }
        }

        private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
    }
}

// --- End of File ---
