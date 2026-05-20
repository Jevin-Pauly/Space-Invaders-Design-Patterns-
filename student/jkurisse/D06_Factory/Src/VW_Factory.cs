//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Volkswagen_Factory : Factory_Base
    {
        public override Vehicle Create(Vehicle.Model _m, Vehicle.Color _c)
        {

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Vehicle newV;

            if (_m == Vehicle.Model.Jetta)
            {
                newV = new Jetta(Vehicle.Doors.Four, _c, Vehicle.Engine.Diesel);
            }
            else if (_m == Vehicle.Model.Golf)
            {
                newV = new Golf(Vehicle.Doors.Two, _c, Vehicle.Engine.Petrol);
            }
            else if (_m == Vehicle.Model.Tiguan)
            {
                newV = new Tiguan(Vehicle.Doors.Four, _c, Vehicle.Engine.Electric);
            }
            else if (_m == Vehicle.Model.Atlas)
            {
                newV = new Atlas(Vehicle.Doors.Four, _c, Vehicle.Engine.Petrol);
            }
            else
            {
                return null;
            }

            return newV;
        }

    }
}

// --- End of File ---
