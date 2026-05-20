//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create the instance
            SpaceInvaders pGame = new SpaceInvaders();
            Debug.Assert(pGame != null);

            // Start the game
            pGame.Run();

            // 1) Look at the Tests directory for the test
            //    Enable/Disable Unit tests in Flags
            // 2) If you fail a test, it generates an exception
            //    UnitTest.DummyException
            //    Disable - Break on Exception in the dialog window
            //    (This way the unit completes and reports the pass/fail)
            // 3) Ouput window, turn off all messages except for Program Output
            // 4) Double click failure message, jumps to error

            //  GOOD LUCK

            UnitTest.Framework.runMe();



        }
    }

}

// --- End of File ---
