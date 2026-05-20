//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class VisitorPlane : Visitor 
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_StandardVisitor.Register(...);
        // -----------------------------------------------------------
        public override void Visit(ElementTruck element)
        {
            MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.PLANE_VISIT_TRUCK);
        }

        public override void Visit(ElementCar element)
        {
            MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.CAR_ELEMENT_ERROR);
        }

        public override void Visit(ElementPlane element)
        {
            MailBox_StandardVisitor.Register(MailBox_StandardVisitor.Status.PLANE_VISIT_PLANE);
        }
    }
}

// --- End of File ---

