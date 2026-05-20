using System;
using System.Diagnostics;

namespace SE456
{
    class MoveUFOLeft : MoveStrategy
    {
        public override void Move(UFO pUFO)
        {
            Debug.Assert(pUFO != null);

            if (pUFO.delta > 0)
            {
                pUFO.delta *= -1.0f;
            }
        }
    }
}

// --- End of File ---