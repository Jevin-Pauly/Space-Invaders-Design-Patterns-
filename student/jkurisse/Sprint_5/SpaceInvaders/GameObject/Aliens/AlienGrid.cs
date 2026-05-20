//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class AlienGrid : Composite
    {
        public AlienGrid()
            : base()
        {
            this.name = Name.BirdGrid;

            this.poColObj.pColSprite.SetColor(0, 0, 1);

            this.delta = 4.0f;
            this.change = 4.0f;
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an BirdGroup
            // Call the appropriate collision reaction            
            other.Visit(this);
    }

        public override void Visit(MissileGroup m)
        {
            // BirdGroup vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
}

        public override void Update()
        {
            //Debug.WriteLine("update: {0}", this);
            base.BaseUpdateBoundingBox(this);

            // proof its working
            //this.poColObj.poColRect.width -= 40.0f;

            base.Update();
        }

        public void MoveGrid()
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += this.delta;

                if(this.change != this.delta)
                {                  
                    pGameObj.y -= 20.0f;
                }

                pNode = pFor.Next();
            }
            this.change = this.delta;
        }

        public float GetDelta()
        {
            return this.delta;
        }

        public void SetDelta(float inDelta)
        {
            this.delta = inDelta;
        }

        // Data: ---------------
        private float delta;
        private float change;
    }

}

// --- End of File ---
