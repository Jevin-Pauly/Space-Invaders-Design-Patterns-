//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class ShipMoveRight : ShipMoveState
    {

        public override void MoveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
            pShip.SetState(ShipMan.MoveState.MoveBoth);
        }
        public override void MoveLeft(Ship pShip)
        {
            
        }

    }
}

// --- End of File ---
