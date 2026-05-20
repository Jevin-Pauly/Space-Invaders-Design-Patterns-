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
    public class MailBox_StateMethod
    {
        public enum Status
        {
            EMPTY,
            SITTING_SIT,
            SITTING_STAND,
            SITTING_WALK,
            SITTING_STOP,
            WALKING_SIT,
            WALKING_STAND,
            WALKING_WALK,
            WALKING_STOP,
            STANDING_SIT,
            STANDING_STAND,
            STANDING_WALK,
            STANDING_STOP
        }
        public static void Register(Status s)
        {
            MailBox_StateMethod.status[WriteIndex++] = s;
        }

        // ---------------------------
        // Used for testing
        // ---------------------------
        public static Status TestValue()
        {
            Status s = MailBox_StateMethod.status[ReadIndex++];
            return s;
        }

        private static Status[] status = new Status[40];
        private static int WriteIndex = 0;
        private static int ReadIndex = 0;
    }
}

// --- End of File ---

