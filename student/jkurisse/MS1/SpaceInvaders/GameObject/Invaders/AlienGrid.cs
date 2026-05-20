using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class AlienGrid : Composite
    {
        public AlienGrid()
            : base()
        {
            this.name = Name.AlienGrid;

            this.poColObj.pColSprite.SetColor(0, 1, 0);
            //this.delta = 2.0f;
        }


        public void Move(float newX, float newY)
        {
            // STN - Temp new for looping every Move function
            IteratorComposite pFor = new IteratorComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += newX;

                pNode = pFor.Next();
            }
        }


        public override void Update()
        {

            base.BaseUpdateBoundingBox(this);
            base.Update();

        }

        //private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
        //private float delta;
    }
}

// --- End of File ---
