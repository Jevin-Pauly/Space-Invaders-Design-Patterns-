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
    public class MailBox_CollisionVisitor
    {
        public enum Status
        {
            EMPTY,
            APPLE_VISIT_APPLE,
            APPLE_VISIT_ORANGE,
            APPLE_VISIT_BANANA,
            APPLE_ELEMENT_ERROR,
            ORANGE_VISIT_APPLE,
            ORANGE_VISIT_ORANGE,
            ORANGE_VISIT_BANANA,
            ORANGE_ELEMENT_ERROR,
            BANANA_VISIT_APPLE,
            BANANA_VISIT_ORANGE,
            BANANA_VISIT_BANANA,
            BANANA_ELEMENT_ERROR
        }
        public static void Register(Status s)
        {
            MailBox_CollisionVisitor.status[WriteIndex++] = s;
        }

        // ---------------------------
        // Used for testing
        // ---------------------------
        public static Status TestValue()
        {
            Status s = MailBox_CollisionVisitor.status[ReadIndex++];
            return s;
        }

        private static Status[] status = new Status[40];
        private static int WriteIndex = 0;
        private static int ReadIndex = 0;
    }
}

// --- End of File ---

