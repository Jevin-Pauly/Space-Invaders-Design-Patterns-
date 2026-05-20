//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public abstract class Factory_Base
    {
        public abstract Vehicle Create(Vehicle.Model _m, Vehicle.Color _c);
    }
}

// --- End of File ---

