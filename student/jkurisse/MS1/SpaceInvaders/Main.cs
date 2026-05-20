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
            // LTN - Main
            SpaceInvaders pGame = new SpaceInvaders();
            Debug.Assert(pGame != null);

            // Start the game
            pGame.Run();
        }
    }

}

// --- End of File ---
