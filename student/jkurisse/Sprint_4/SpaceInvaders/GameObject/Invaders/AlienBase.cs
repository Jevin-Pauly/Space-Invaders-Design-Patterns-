using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    abstract class AlienBase : GameObject
    {
        public enum Type
        {
            Red,
            Yellow,
            Green,
            White,

            Squid,
            Octopus,
            Crab
        }

        protected AlienBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName, spriteName, _x, _y)
        {

        }
    }
}

// --- End of File ---
