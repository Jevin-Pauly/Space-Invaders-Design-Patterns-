using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    abstract public class Command
    {
        // define this in concrete
        abstract public void Execute(float deltaTime);
    }
}

// --- End of File ---
