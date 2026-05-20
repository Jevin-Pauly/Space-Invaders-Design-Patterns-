//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class ShipStateReady : ShootState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetShootState(ShipMan.SState.MissileFlying);
        }

        //public override void MoveRight(Ship pShip)
        //{
        //    pShip.x += pShip.shipSpeed;
        //}
        //
        //public override void MoveLeft(Ship pShip)
        //{
        //    pShip.x -= pShip.shipSpeed;
        //}

        public override void ShootMissile(Ship pShip)
        {
            Missile pMissile = ShipMan.ActivateMissile();

            pMissile.SetPos(pShip.x, pShip.y + 20);
            pMissile.SetActive(true);

            pShip.sndEngine.SoundVolume = 0.2f;
            pShip.sndEngine.Play2D("invaderkilled.wav");

            // switch states
            this.Handle(pShip);
        }

    }
}

// --- End of File ---
