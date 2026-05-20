using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class SpriteGameProxyNull : SpriteGameProxy
    {
        public SpriteGameProxyNull()
            : base(SpriteGameProxy.Name.NullObject)
        {

        }

        public override void Render()
        {
            // do nothing
        }

        public override void Update()
        {
            // do nothing
        }
    }
}

// --- End of File ---
