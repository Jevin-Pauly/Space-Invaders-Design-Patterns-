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
    public class MailBox_StandardVisitor
    {
        public enum Status
        {
            EMPTY,
            TRUCK_VISIT_CAR,
            TRUCK_VISIT_PLANE,
            TRUCK_VISIT_TRUCK,
            TRUCK_ELEMENT_ERROR,
            CAR_VISIT_CAR,
            CAR_VISIT_PLANE,
            CAR_VISIT_TRUCK,
            CAR_ELEMENT_ERROR,
            PLANE_VISIT_CAR,
            PLANE_VISIT_PLANE,
            PLANE_VISIT_TRUCK,
            PLANE_ELEMENT_ERROR
        }
        public static void Register( Status s )
        {
            MailBox_StandardVisitor.status[WriteIndex++] = s;       
        }

        // ---------------------------
        // Used for testing
        // ---------------------------
        public static Status TestValue()
        {
            Status s = MailBox_StandardVisitor.status[ReadIndex++];
            return s;
        }

        private static Status[] status = new Status[40];
        private static int WriteIndex = 0;
        private static int ReadIndex = 0;
    }
}

// --- End of File ---

