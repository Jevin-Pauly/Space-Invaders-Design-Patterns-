using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class ShipBumperRightState : MoveState
    {
        public override void Handle(Ship pShip, bool left)
        {
            if (left)
            {
                pShip.SetMoveState(ShipMan.MState.Normal);
            }
        }

        public override void MoveRight(Ship pShip)
        {
        }

        public override void MoveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
            this.Handle(pShip, true);
        }

    }
}
