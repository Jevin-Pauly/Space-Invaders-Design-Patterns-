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
    abstract public class Imperial
    {
        public Imperial()
        {
            // do nothing
        }

        // Leave this function alone
        public abstract void SetWeight(float pounds);
        public abstract void SetLength(float feet);
        public abstract void SetVolume(float gallons);

        public abstract float GetWeight();
        public abstract float GetLength();
        public abstract float GetVolume();

    }
}

// --- End of File ---

