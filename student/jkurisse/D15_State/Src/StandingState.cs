//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class StandingState : State
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_StateMethod.Register(...);
        //          MailBox_StateTransition.Register(...);
        // -----------------------------------------------------------
        public StandingState() 
            : base(Name.StandingState)
        {
        }

        public override void Stand()
        {
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_STAND);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_NO_TRANSITION);
        }

        public override void Sit()
        {
            this.pContext.SetState(Name.SittingState);
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_SIT);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_TRANSITION_TO_SITTING);
        }

        public override void Walk()
        {
            this.pContext.SetState(Name.WalkingState);
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_WALK);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_TRANSITION_TO_WALKING);
        }

        public override void Stop()
        {
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.STANDING_STOP);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.STANDING_NO_TRANSITION);
        }
    }
}

// --- End of File ---
