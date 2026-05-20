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
    public class MailBox_StateTransition
    {
        public enum Status
        {
            EMPTY,
            SITTING_NO_TRANSITION,
            SITTING_TRANSITION_TO_SITTING,
            SITTING_TRANSITION_TO_STANDING,
            SITTING_TRANSITION_TO_WALKING,
            WALKING_NO_TRANSITION,
            WALKING_TRANSITION_TO_SITTING,
            WALKING_TRANSITION_TO_STANDING,
            WALKING_TRANSITION_TO_WALKING,
            STANDING_NO_TRANSITION,
            STANDING_TRANSITION_TO_SITTING,
            STANDING_TRANSITION_TO_STANDING,
            STANDING_TRANSITION_TO_WALKING,
        }
        public static void Register(Status s)
        {
            MailBox_StateTransition.status[WriteIndex++] = s;
        }

        // ---------------------------
        // Used for testing
        // ---------------------------
        public static Status TestValue()
        {
            Status s = MailBox_StateTransition.status[ReadIndex++];
            return s;
        }

        private static Status[] status = new Status[40];
        private static int WriteIndex = 0;
        private static int ReadIndex = 0;
    }
}

// --- End of File ---

