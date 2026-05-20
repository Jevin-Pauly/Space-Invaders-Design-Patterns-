//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using UnitTest;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Factory_Tests : UnitTestBase
    {
        public void Factory_Shakeout()
        {
            if (Tests_Flags.Factory_Test_Enable)
            {
                // Create factory
                Volkswagen_Factory pVW_Factory = new Volkswagen_Factory();
                CHECK(pVW_Factory != null);

                // ------------------------------------

                // Create Car
                Vehicle pVehicle_A = pVW_Factory.Create(Vehicle.Model.Golf, Vehicle.Color.Red);
                CHECK(pVehicle_A != null);
                
                CHECK(pVehicle_A.GetType().Name == "Golf");
                
                // Deeper checking...
                Golf pGolf = (Golf)pVehicle_A;
                CHECK(pGolf.c == Vehicle.Color.Red);
                CHECK(pGolf.d == Vehicle.Doors.Two);
                CHECK(pGolf.e == Vehicle.Engine.Petrol);
                CHECK(pGolf.poDrive.GetType().Name == "TwoWheelDrive");
                CHECK(pGolf.poStyle.GetType().Name == "Hatchback");

                // -----------------------------------

                Vehicle pVehicle_B = pVW_Factory.Create(Vehicle.Model.Jetta, Vehicle.Color.Blue);
                CHECK(pVehicle_B != null);

                CHECK(pVehicle_B.GetType().Name == "Jetta");

                // Deeper checking...
                Jetta pJetta = (Jetta)pVehicle_B;
                CHECK(pJetta.c == Vehicle.Color.Blue);
                CHECK(pJetta.d == Vehicle.Doors.Four);
                CHECK(pJetta.e == Vehicle.Engine.Diesel);
                CHECK(pJetta.poStyle.GetType().Name == "Sedan");

                // -----------------------------------

                Vehicle pVehicle_C = pVW_Factory.Create(Vehicle.Model.Tiguan, Vehicle.Color.Yellow);
                CHECK(pVehicle_C != null);

                CHECK(pVehicle_C.GetType().Name == "Tiguan");

                // Deeper checking...
                Tiguan pTiguan = (Tiguan)pVehicle_C;
                CHECK(pTiguan.c == Vehicle.Color.Yellow);
                CHECK(pTiguan.d == Vehicle.Doors.Four);
                CHECK(pTiguan.e == Vehicle.Engine.Electric);
                CHECK(pTiguan.poDrive.GetType().Name == "AllWheelDrive");

                // -----------------------------------

                Vehicle pVehicle_D = pVW_Factory.Create(Vehicle.Model.Atlas, Vehicle.Color.Black);
                CHECK(pVehicle_D != null);

                CHECK(pVehicle_D.GetType().Name == "Atlas");

                // Deeper checking...
                Atlas pAtlas = (Atlas)pVehicle_D;
                CHECK(pAtlas.c == Vehicle.Color.Black);
                CHECK(pAtlas.d == Vehicle.Doors.Four);
                CHECK(pAtlas.e == Vehicle.Engine.Petrol);
                CHECK(pAtlas.poDrive.GetType().Name == "AllWheelDrive");
                CHECK(pAtlas.poRow.GetType().Name == "ThirdRow");
                CHECK(pAtlas.poTow.GetType().Name == "TowPackage");

            }
            else
            {
                IGNORE();
            }
        }


    }

}

// --- End of File ---

