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
    public class Singleton_GetInstance_Tests : UnitTestBase
    {
        public void Singleton_GetInstance()
        {
            if (Tests_Flags.GetInstance_Enable)
            {
                Singleton pSingleton = Singleton.GetInstance();
                CHECK(pSingleton != null);

                // ------------------------------------

                CHECK(pSingleton.GetX() == 5);
                CHECK(pSingleton.GetY() == 6);

                // -----------------------------------

                pSingleton.Add(10, 30);
                CHECK(pSingleton.GetX() == 15);
                CHECK(pSingleton.GetY() == 36);

                // -----------------------------------

                pSingleton.Sub(5, 6);
                CHECK(pSingleton.GetX() == 10);
                CHECK(pSingleton.GetY() == 30);

            }
            else
            {
                IGNORE();
            }
        }

    }

}

// --- End of File ---

