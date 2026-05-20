//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    // -----------------------------------------------
    // Add CODE/REFACTOR here
    // -----------------------------------------------
    //    Fill in methods
    //    Add additional methods if desired
    //    Add additional data if desired
    // -----------------------------------------------
    public class Octopus : Command
    {
        public Octopus(Score _score)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            this.pScore = _score;

        }
        override public void Execute()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            this.pScore.AddPoints(10);
        }

        // ------------------------------
        //    Data
        // ------------------------------
    }
}

// --- End of File ---
