using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    abstract public class Component : DLink
    {
        public enum Container
        {
            LEAF,
            COMPOSITE,
            Unknown
        }

        public Component(Component.Container _type)
        {
            this.type = _type;
        }

        public abstract void Print();
        //public abstract void Move(float x, float y);

        // Data
        public Container type;
        public Component pParent = null;
    }
}

// --- End of File ---
