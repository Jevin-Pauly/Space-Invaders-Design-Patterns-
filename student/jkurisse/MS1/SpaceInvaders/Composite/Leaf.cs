using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    abstract class Leaf : GameObject
    {
        public Leaf(GameObject.Name gameName, SpriteGame.Name spriteName, float x, float y)
            : base(Component.Container.LEAF, gameName, spriteName, x, y)
        {
        }

        override public void Print()
        {
            this.Dump();
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }

    }
}

// --- End of File ---

