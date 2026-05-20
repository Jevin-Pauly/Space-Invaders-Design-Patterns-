//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class AlienGrid : Composite
    {
        public AlienGrid(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.name = Name.AlienGrid;

            this.poColObj.pColSprite.SetColor(0, 0, 1);

            this.delta = 4.0f;
            this.change = 4.0f;
            this.temp = 0;
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            base.Resurrect(SpriteGame.Name.def);

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
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
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs AlienGrid
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Visit(Missile m)
        {
            // BirdGroup vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs AlienGrid
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

        public void MoveGrid(int alienCount)
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                if(this.delta < 0.0f)
                {
                    this.temp = -1 * (alienCount * .21818f);
                }
                else
                {
                    this.temp = (alienCount * .21818f);
                }


                pGameObj.x += this.delta + this.temp;

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
        private float temp;
    }

}

// --- End of File ---
