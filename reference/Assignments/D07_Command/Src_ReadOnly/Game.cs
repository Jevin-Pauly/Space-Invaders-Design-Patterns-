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
    public class Game
    {
        public enum Alien
        {
            Crab,
            Octopus,
            Squid
        }
        public Game()
        {
            this.poScore = new Score();
            this.poCrab = new Crab(this.poScore);
            this.poSquid = new Squid(this.poScore);
            this.poOctopus = new Octopus(this.poScore);
            this.poScore.Reset();
        }


        public void AlienKilled(Alien type)
        {
            Command pCmd = null;
            switch (type)
            {
                case Alien.Crab:
                    pCmd = this.poCrab;
                    break;

                case Alien.Octopus:
                    pCmd = this.poOctopus;
                    break;

                case Alien.Squid:
                    pCmd = this.poSquid;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }
            pCmd.Execute();
        }

        public int GetScore()
        {
            return this.poScore.GetPoints();
        }

        private Crab poCrab;
        private Squid poSquid;
        private Octopus poOctopus;
        private Score poScore;
    }
 
}

// --- End of File ---
