//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public abstract class Command
    {
        public Command()
        {
        }
        public Command( Score _pScore )
        {
            this.pScore = _pScore;
        }
        abstract public void Execute();

        protected Score pScore;
    }

}

// --- End of File ---
