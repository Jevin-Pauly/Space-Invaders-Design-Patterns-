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
    public class Garage_Forward_Empty_Tests : UnitTestBase
    {
        public void Garage_Forward_Empty_Iterator()
        {
            if (Tests_Flags.Garage_Forward_Iterator_Empty_Enable)
            {
                Garage pGarage = new Garage();
                CHECK(pGarage != null);

                // ------------------------------------

                // iterator test
                Car_ForwardIterator pIt = new Car_ForwardIterator(pGarage);
                CHECK(pIt != null);

                // -----------------------------------

                bool flag = pIt.IsDone();
                CHECK(flag == true); 
                
                Car pTmp = pIt.First();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                // ------------------------------------

                // iterator test
                Car_ForwardIterator pIt2 = new Car_ForwardIterator(null);
                CHECK(pIt2 != null);

                // -----------------------------------

                flag = pIt2.IsDone();
                CHECK(flag == true);

                pTmp = pIt2.First();
                CHECK(pTmp == null);

                pTmp = pIt2.Current();
                CHECK(pTmp == null);

                pTmp = pIt2.Next();
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

