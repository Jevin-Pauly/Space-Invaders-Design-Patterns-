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
    public class State_Tests : UnitTestBase
    {
        public void State_Shakeout()
        {
            if (Tests_Flags.Shakeout_Enable)
            {
                Context pContext = new Context();
                CHECK(pContext != null);

                State pA = new SittingState();
                CHECK(pA != null);

                State pB = new StandingState();
                CHECK(pB != null);

                State pC = new WalkingState();
                CHECK(pC != null);

                // Attach by pushing to front
                pContext.Attach(pA);
                pContext.Attach(pB);
                pContext.Attach(pC);

                pContext.SetState(State.Name.SittingState);
                CHECK(pContext.GetState() == State.Name.SittingState);

                pContext.Sit();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.SITTING_SIT);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.SITTING_NO_TRANSITION);

                pContext.Walk();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.SITTING_WALK);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.SITTING_NO_TRANSITION);

                pContext.Stop();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.SITTING_STOP);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.SITTING_NO_TRANSITION);

                pContext.Stand();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.SITTING_STAND);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.SITTING_TRANSITION_TO_STANDING);

                CHECK(pContext.GetState() == State.Name.StandingState);

                pContext.Stand();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.STANDING_STAND);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.STANDING_NO_TRANSITION);

                pContext.Stop();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.STANDING_STOP);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.STANDING_NO_TRANSITION);

                pContext.Walk();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.STANDING_WALK);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.STANDING_TRANSITION_TO_WALKING);

                CHECK(pContext.GetState() == State.Name.WalkingState);

                pContext.Sit();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.WALKING_SIT);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.WALKING_NO_TRANSITION);

                pContext.Stand();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.WALKING_STAND);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.WALKING_NO_TRANSITION);

                pContext.Walk();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.WALKING_WALK);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.WALKING_NO_TRANSITION);

                pContext.Stop();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.WALKING_STOP);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.WALKING_TRANSITION_TO_STANDING);

                CHECK(pContext.GetState() == State.Name.StandingState);

                pContext.Sit();
                CHECK(MailBox_StateMethod.TestValue() == MailBox_StateMethod.Status.STANDING_SIT);
                CHECK(MailBox_StateTransition.TestValue() == MailBox_StateTransition.Status.STANDING_TRANSITION_TO_SITTING);

                CHECK(pContext.GetState() == State.Name.SittingState);

            }
            else
            {
                IGNORE();
            }
        }

    }
}

// --- End of File ---

