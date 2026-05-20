//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    abstract public class Visitor 
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here - add Visitor contracts here
        // -----------------------------------------------------------
        //      Remember to add the mailbox registration in method
        //          MailBox_StandardVisitor.Register(...);
        // -----------------------------------------------------------

        public virtual void Visit(ElementTruck element)
        {
            Debug.WriteLine("Visited Truck");
        }
        public virtual void Visit(ElementCar element)
        {
            Debug.WriteLine("Visited Car");
        }
        public virtual void Visit(ElementPlane element)
        {
            Debug.WriteLine("Visited Plane");
        }
    }
}

// --- End of File ---

