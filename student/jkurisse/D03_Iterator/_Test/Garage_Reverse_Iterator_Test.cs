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
    public class Garage_Reverse_Iterator_Tests : UnitTestBase
    {
        public void Garage_Reverse_Iterator()
        {
            if (Tests_Flags.Garage_Reverse_Iterator_Enable)
            {
                Garage pGarage = new Garage();
                CHECK(pGarage != null);

                Car pE = new Car(Car.Name.Panda, 77);
                CHECK(pE != null);

                Car pD = new Car(Car.Name.Kona, 33);
                CHECK(pD != null);

                Car pC = new Car(Car.Name.Jetta, 88);
                CHECK(pC != null);

                Car pB = new Car(Car.Name.Civic, 22);
                CHECK(pB != null);

                Car pA = new Car(Car.Name.Nexon, 99);
                CHECK(pA != null);

                pGarage.Add(pE);
                pGarage.Add(pD);
                pGarage.Add(pC);
                pGarage.Add(pB);
                pGarage.Add(pA);

                // ------------------------------------

                // iterator test
                Car_ReverseIterator pIt = new Car_ReverseIterator(pGarage);
                CHECK(pIt != null);

                // ------------------------------------
                // Test should verify this loop
                // ------------------------------------
                //for (pIt.First(); !pIt.IsDone(); pIt.Next())
                //{
                //    Car p = pIt.Current();
                //    p.Print();
                //}

                // -----------------------------------

                Car pTmp = pIt.First();
                CHECK(pTmp == pE);

                bool flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                pTmp = pIt.Next();
                CHECK(pTmp == pD);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pD);

                pTmp = pIt.Next();
                CHECK(pTmp == pC);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pC);

                pTmp = pIt.Next();
                CHECK(pTmp == pB);
      
                // ----- Take 2 - reset first --------

                pTmp = pIt.First();
                CHECK(pTmp == pE);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                pTmp = pIt.Next();
                CHECK(pTmp == pD);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pD);

                pTmp = pIt.Next();
                CHECK(pTmp == pC);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pC);

                pTmp = pIt.Next();
                CHECK(pTmp == pB);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pB);

                pTmp = pIt.Next();
                CHECK(pTmp == pA);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pA);

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                pTmp = pIt.Next();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }
    }

}

// --- End of File ---

