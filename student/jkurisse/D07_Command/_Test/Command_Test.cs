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
    public class Command_Tests : UnitTestBase
    {
        public void Command_Shakeout()
        {
            if (Tests_Flags.Command_Shakeout_Enable)
            {
                // Test individual components
                {
                    Score pScore = new Score();
                    CHECK(pScore.GetPoints() == 0);

                    Command pCmd = new Squid(pScore);

                    pScore.Reset();
                    CHECK(pScore.GetPoints() == 0);
                    pCmd.Execute();
                    CHECK(pScore.GetPoints() == 30);
                }

                {
                    Score pScore = new Score();
                    CHECK(pScore.GetPoints() == 0);

                    Command pCmd = new Crab(pScore);

                    pScore.Reset();
                    CHECK(pScore.GetPoints() == 0);
                    pCmd.Execute();
                    CHECK(pScore.GetPoints() == 20);
                }

                {
                    Score pScore = new Score();
                    CHECK(pScore.GetPoints() == 0);

                    Command pCmd = new Octopus(pScore);
     
                    pScore.Reset();
                    CHECK(pScore.GetPoints() == 0);
                    pCmd.Execute();
                    CHECK(pScore.GetPoints() == 10);
                }

                // test hidden
                {
                    Game pGame = new Game();
                    CHECK(pGame.GetScore() == 0);

                    pGame.AlienKilled(Game.Alien.Crab);
                    CHECK(pGame.GetScore() == 20);

                    pGame.AlienKilled(Game.Alien.Crab);
                    CHECK(pGame.GetScore() == 40);

                    pGame.AlienKilled(Game.Alien.Crab);
                    CHECK(pGame.GetScore() == 60);

                    pGame.AlienKilled(Game.Alien.Squid);
                    CHECK(pGame.GetScore() == 90);

                    pGame.AlienKilled(Game.Alien.Octopus);
                    CHECK(pGame.GetScore() == 100);

                    pGame.AlienKilled(Game.Alien.Octopus);
                    CHECK(pGame.GetScore() == 110);

                    pGame.AlienKilled(Game.Alien.Octopus);
                    CHECK(pGame.GetScore() == 120);
                }
            }
            else
            {
                IGNORE();
            }
        }
    }
}

// --- End of File ---

