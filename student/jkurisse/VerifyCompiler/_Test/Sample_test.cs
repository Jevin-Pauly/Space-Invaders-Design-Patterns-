//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using UnitTest;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Sample_test : UnitTestBase
    {
        public void Smoke_Test()
        {
            if (Tests_Flags.SmokeTest_Test_Enable)
            {
                //-------------------------------------------------------------
                // Printing
                //-------------------------------------------------------------

                // explicit printing
                System.Diagnostics.Debug.WriteLine("Debug window printing...");
                Debug.WriteLine("\n");

                // simplied using the using directive
                int x = 5;
                int y = 10;
                Debug.WriteLine("  y:{1} x: {0} ", x, y);

                CHECK(x == 5);
                CHECK(y == 10);

                //-------------------------------------------------------------
                // Structs (value type) on stack no new()
                //-------------------------------------------------------------

                Position pos;

                pos.x = 5;
                pos.y = 7;

                Debug.WriteLine("\nPos struct");
                Debug.WriteLine("  Pos x:{0} y:{1} ", pos.x, pos.y);

                Debug.Write("  Pos x:" + pos.x + " y:" + pos.y + "\n");

                CHECK(pos.x == 5);
                CHECK(pos.y == 7);

                //-------------------------------------------------------------
                // Structs by reference on heap with new()
                //-------------------------------------------------------------

                Position pPos = new Position(1, 2);

                Debug.WriteLine("\nPos struct by pointer");
                Debug.WriteLine("  Pos x:{0} y:{1} ", pPos.x, pPos.y);

                CHECK(pPos.x == 1);
                CHECK(pPos.y == 2);

                //-------------------------------------------------------------
                // Class (reference type) on heap need new()
                //-------------------------------------------------------------

                Car pJetta = new Car();

                pJetta.d = 99;
                pJetta.pos.x = 88;

                Debug.WriteLine("\nJetta");
                Debug.WriteLine("  Pos x:{0} y:{1} ", pJetta.pos.x, pJetta.pos.y);
                Debug.WriteLine("  d:{0}", pJetta.d);

                CHECK(pJetta.d == 99);
                CHECK(pJetta.pos.x == 88);

                //-------------------------------------------------------------
                // Boxing / UnBoxing
                //-------------------------------------------------------------

                // pos is value type, box it, make it reference type
                object pObj = pos;

                // unbox it, bring it back to value type
                Position pos2 = (Position)pObj;

                CHECK(pos.Equals(pos2));

                //-------------------------------------------------------------
                // Pass by reference
                //-------------------------------------------------------------

                Car pGolf = new Car();

                pGolf.d = 55;
                pGolf.pos.x = 66;
                pGolf.pos.y = 77;

                Debug.WriteLine("\nGolf before");
                pGolf.PrintMe();

                Car.AddHundred(pGolf);

                Debug.WriteLine("\nGolf after");
                pGolf.PrintMe();

                CHECK(pGolf.pos.x == 166);
                CHECK(pGolf.pos.y == 177);
                CHECK(pGolf.d == 155);

                //-------------------------------------------------------------
                // Pass by using out
                //-------------------------------------------------------------

                Car pPassat = new Car(33, 22, 11);
                Position pos3;

                Debug.WriteLine("\nPassat");
                pPassat.PrintMe();

                Debug.WriteLine("\nPassat: Get Position");
                pPassat.GetPos(out pos3);

                pos3.PrintMe();

                CHECK(pos3.y == 11);
                CHECK(pos3.x == 22);

                //-------------------------------------------------------------
                // Pass by using ref
                //-------------------------------------------------------------

                Car pTiguan = new Car(99, 88, 77);

                Car pRental = pTiguan;

                Debug.WriteLine("\nTiguan");
                pTiguan.PrintMe();

                CHECK(pTiguan.pos.x == 88);
                CHECK(pTiguan.pos.y == 77);
                CHECK(pTiguan.d == 99);

                Car.Presto(ref pTiguan);

                Debug.WriteLine("\nTiguan: Presto Chango");
                pTiguan.PrintMe();

                CHECK(pTiguan.pos.x == 222);
                CHECK(pTiguan.pos.y == 333);
                CHECK(pTiguan.d == 111);

                Debug.WriteLine("\n");

            }
            else
            {
                IGNORE();
            }
        }


    }

}

// --- End of File ---

