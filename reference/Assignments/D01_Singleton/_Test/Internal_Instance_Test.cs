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
    public class Singleton_InternalInstance_Tests : UnitTestBase
    {
        public void Singleton_InternalInstance()
        {
            if (Tests_Flags.InternalInstance_Enable)
            {
                int x;
                int y;

                x = GlobalMan.GetX();
                y = GlobalMan.GetY();
 
                CHECK(x == 5);
                CHECK(y == 6);

                // -----------------------------------

                GlobalMan.Add(10, 30);
                CHECK(GlobalMan.GetX() == 15);
                CHECK(GlobalMan.GetY() == 36);

                // -----------------------------------

                GlobalMan.Sub(5, 6);
                CHECK(GlobalMan.GetX() == 10);
                CHECK(GlobalMan.GetY() == 30);

            }
            else
            {
                IGNORE();
            }
        }

    }

}

// --- End of File ---

