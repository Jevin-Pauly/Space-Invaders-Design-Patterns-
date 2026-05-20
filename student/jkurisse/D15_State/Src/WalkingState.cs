//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class WalkingState : State
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_StateMethod.Register(...);
        //          MailBox_StateTransition.Register(...);
        // -----------------------------------------------------------
        public WalkingState()
            : base(Name.WalkingState)
        {
        }

        public override void Stand()
        {
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_STAND);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_NO_TRANSITION);
        }

        public override void Sit()
        {
            //cannot sit while walking
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_SIT);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_NO_TRANSITION);

        }
        public override void Walk()
        {
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_WALK);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_NO_TRANSITION);
        }

        public override void Stop()
        {
            this.pContext.SetState(Name.StandingState);
            MailBox_StateMethod.Register(MailBox_StateMethod.Status.WALKING_STOP);
            MailBox_StateTransition.Register(MailBox_StateTransition.Status.WALKING_TRANSITION_TO_STANDING);
        }
    }
}

// --- End of File ---
