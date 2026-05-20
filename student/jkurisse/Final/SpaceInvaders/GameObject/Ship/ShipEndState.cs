//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class ShipStateDead : MoveState
    {
        public override void Handle(Ship pShip, bool dir)
        {
            pShip.SetMoveState(ShipMan.MState.Dead);
        }
        public override void MoveRight(Ship pShip)
        {

        }
        public override void MoveLeft(Ship pShip)
        {

        }
    }
}

// --- End of File ---
