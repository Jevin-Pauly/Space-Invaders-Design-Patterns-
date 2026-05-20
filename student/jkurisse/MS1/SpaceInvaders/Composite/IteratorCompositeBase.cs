using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    abstract public class IteratorCompositeBase
    {
        abstract public Component Next();
        abstract public bool IsDone();
        abstract public Component First();
        abstract public Component Curr();
    }

}

// --- End of File ---
