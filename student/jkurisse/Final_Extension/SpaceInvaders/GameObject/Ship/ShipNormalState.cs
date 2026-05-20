using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class ShipNormalState : MoveState
    {
        public override void Handle(Ship pShip, bool left)
        {
            if (left)
            {
                pShip.SetMoveState(ShipMan.MState.LeftBumper);
            }
            else
            {
                pShip.SetMoveState(ShipMan.MState.RightBumper);
            }
        }

        public override void MoveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
        }

    }
}