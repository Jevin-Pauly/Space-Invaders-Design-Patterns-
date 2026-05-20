using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class Squid : AlienBase
    {
        public Squid(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.RedBird, spriteName, posX, posY)
        {
        }

        public override void Update()
        {
/*            this.y += 1.0f;
            if (this.y > 600.0f)
            {
                this.y = 0.0f;
            }
*/
            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
