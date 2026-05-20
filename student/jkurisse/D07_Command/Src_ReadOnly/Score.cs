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
    public class Score
    {
        public Score()
        {
            this.Reset();
        }

        public void AddPoints(int val)
        {
            Debug.Assert(val >= 0);
            this.score += val;
        }

        public void SubPoints(int val)
        {
            Debug.Assert(val >= 0);
            this.score -= val;
        }

        public int GetPoints()
        {
            return this.score;
        }

        public void Reset()
        {
            this.score = 0;
        }

        private int score;
    }
}

// --- End of File ---
