//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class RemoveAlienObserver : Observer
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_Observer.Register(...);
        // -----------------------------------------------------------

        public override void Notify()
        {
            MailBox_Observer.Register(MailBox_Observer.Status.REMOVE_ALIEN_OBSERVER);
        }
    }
}

// --- End of File ---

