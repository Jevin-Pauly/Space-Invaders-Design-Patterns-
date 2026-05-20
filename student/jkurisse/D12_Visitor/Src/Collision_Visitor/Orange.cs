//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Orange : VisitorFruit
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_CollisionVisitor.Register(...);
        // -----------------------------------------------------------

        public override void Visit(Apple apple)
        {
            MailBox_CollisionVisitor.Register(MailBox_CollisionVisitor.Status.ORANGE_VISIT_APPLE);
        }

        public override void Visit(Orange orange)
        {
            MailBox_CollisionVisitor.Register(MailBox_CollisionVisitor.Status.ORANGE_VISIT_ORANGE);
        }

        public override void Visit(Banana banana)
        {
            MailBox_CollisionVisitor.Register(MailBox_CollisionVisitor.Status.BANANA_ELEMENT_ERROR);
        }

        public override void Accept(VisitorFruit visitor)
        {
            visitor.Visit(this);
        }
    }
}

// --- End of File ---

