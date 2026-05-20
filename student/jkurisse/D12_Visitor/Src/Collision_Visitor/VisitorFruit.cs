//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    abstract public class VisitorFruit : ElementFruit
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here - add Visitor contracts here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_CollisionVisitor.Register(...);
        // -----------------------------------------------------------

        public virtual void Visit(Apple apple)
        {
            Debug.WriteLine("Visited Apple");
        }

        public virtual void Visit(Orange orange)
        {
            Debug.WriteLine("Visited Orange");
        }

        public virtual void Visit(Banana banana)
        {
            Debug.WriteLine("Visited Banana");
        }

    }
}

// --- End of File ---

