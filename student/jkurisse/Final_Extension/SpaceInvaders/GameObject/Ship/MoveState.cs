//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class MoveState
    {
        // state()
        public abstract void Handle(Ship pShip, bool left);

        // strategy()
        public abstract void MoveRight(Ship pShip);
        public abstract void MoveLeft(Ship pShip);

        //public abstract void ShootMissile(Ship pShip);

    }
}

// --- End of File ---
