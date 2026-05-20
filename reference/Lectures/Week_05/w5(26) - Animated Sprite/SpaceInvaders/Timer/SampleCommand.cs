//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class SampleCommand : Command
    {
        public SampleCommand(String txt)
        {
            // string only for testing
            this.pString = txt;
        }

        public override void Execute(float deltaTime)
        {
            Debug.WriteLine(" {0} time:{1} ", this.pString, TimerEventMan.GetCurrTime());
        }

        private String pString;
    }
}

// --- End of File ---
