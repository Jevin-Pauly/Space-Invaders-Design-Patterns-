using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class ShipBumpLeftObserver : ColObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipMan.GetShip();

            // Correction... only method that changes state is Handle
            // So correct this....
            // pShip.SetState(ShipMan.State.Ready);
            //pShip.Handle();
            pShip.MoveHandle(true);
        }

        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.ShipBumpLeftObserver;
        }
    }

    // data
}

// --- End of File ---
