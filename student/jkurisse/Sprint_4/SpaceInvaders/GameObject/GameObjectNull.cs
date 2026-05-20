using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class GameObjectNull : GameObject
    {
        public GameObjectNull()
            : base(GameObject.Name.Null_Object, null)
        {

        }

        public override void Update()
        {
            // do nothing - its a null object
            Debug.WriteLine("NULL object");
        }
    }
}

// --- End of File ---
