using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class Squid : AlienBase
    {
        public Squid(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Squid, spriteName, posX, posY)
        {
        }

        override public System.Enum GetName()
        {
            return AlienBase.Name.Squid;
        }


        //public override void Move(float _x, float _y)
        //{
        //    this.x += _x;
        //    this.y += _y;
        //}


        public override void Update()
        {
            /*            this.y += 1.0f;
                        if (this.y > 600.0f)
                        {
                            this.y = 0.0f;
                        }
            */
            //Debug.WriteLine("squid");
            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
