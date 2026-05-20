//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class ShipStateMissileFlying : ShootState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetShootState(ShipMan.SState.Ready);
        }
        //public override void MoveRight(Ship pShip)
        //{
        //    pShip.x += pShip.shipSpeed;
        //}
        //public override void MoveLeft(Ship pShip)
        //{
        //    pShip.x -= pShip.shipSpeed;
        //}
        public override void ShootMissile(Ship pShip)
        {

        }
    }
}

// --- End of File ---
