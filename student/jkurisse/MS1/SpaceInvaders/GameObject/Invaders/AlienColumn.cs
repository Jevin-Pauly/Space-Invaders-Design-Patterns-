using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class AlienColumn : Composite
    {
        public AlienColumn()
            : base()
        {
            this.name = Name.AlienColumn;
            this.poColObj.pColSprite.SetColor(1, 0, 0);
        }

        public override void Update()
        {

            base.BaseUpdateBoundingBox(this);
            base.Update();

        }



        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Column:");

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);

                pNode.Dump();
            }
        }

        //private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
    }
}

// --- End of File ---