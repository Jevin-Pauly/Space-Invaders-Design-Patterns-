using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class GameObjectNull : Leaf
    {
        public GameObjectNull()
            : base(GameObject.Name.Null_Object, SpriteGame.Name.Null_Object, 0, 0)
        {

        }

        //public override void Move(float x, float y)
        //{
        //}
        public override void Update()
        {
            // do nothing - its a null object
        }

        //private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();

    }
}

// --- End of File ---
