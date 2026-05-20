//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using UnitTest;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Visitor_Tests : UnitTestBase
    {
        public void Visitor_Shakeout()
        {
            if (Tests_Flags.Shakeout_Enable)
            {

                // Compile polymorphism
                Vehicle pA = new Vehicle();
                CHECK(pA != null);

                Element pEA = new ElementTruck();
                CHECK(pEA != null);

                Element pEB = new ElementCar();
                CHECK(pEB != null);

                Element pEC = new ElementPlane();
                CHECK(pEC != null);

                // Attach by pushing to front
                pA.Attach(pEC);
                pA.Attach(pEB);
                pA.Attach(pEA);

                VisitorTruck pVisitTruck = new VisitorTruck();
                CHECK(pVisitTruck != null);

                pA.Accept(pVisitTruck);

                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.TRUCK_VISIT_TRUCK);
                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.TRUCK_VISIT_CAR);
                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.TRUCK_VISIT_PLANE);

                pA.Detach(pEC);

                pA.Accept(pVisitTruck);

                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.TRUCK_VISIT_TRUCK);
                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.TRUCK_VISIT_CAR);

                pA.Detach(pEA);

                pA.Accept(pVisitTruck);

                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.TRUCK_VISIT_CAR);

                pA.Detach(pEB);

                pA.Accept(pVisitTruck);

                VisitorCar pVisitCar = new VisitorCar();
                Vehicle pB = new Vehicle();
                CHECK(pB != null);

                pB.Attach(pEC);
                pB.Accept(pVisitCar);

                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.CAR_VISIT_PLANE);

                VisitorPlane pVisitPlane = new VisitorPlane();
                Vehicle pC = new Vehicle();
                CHECK(pC != null);

                pC.Attach(pEB);
                pC.Accept(pVisitPlane);

                CHECK(MailBox_StandardVisitor.TestValue() == MailBox_StandardVisitor.Status.CAR_ELEMENT_ERROR);

            }
            else
            {
                IGNORE();
            }
        }

        public void Collision_Visitor_Shakeout()
        {
            if (Tests_Flags.Collision_Shakeout_Enable)
            {
                // Compile-Time polymorphism
                VisitorFruit pA = new Apple();
                CHECK(pA != null);

                VisitorFruit pO = new Orange();
                CHECK(pO != null);

                VisitorFruit pB = new Banana();
                CHECK(pB != null);

                pA.Accept(pB);
                CHECK(MailBox_CollisionVisitor.TestValue() == MailBox_CollisionVisitor.Status.BANANA_VISIT_APPLE);

                pB.Accept(pB);
                CHECK(MailBox_CollisionVisitor.TestValue() == MailBox_CollisionVisitor.Status.BANANA_VISIT_BANANA);

                pO.Accept(pB);
                CHECK(MailBox_CollisionVisitor.TestValue() == MailBox_CollisionVisitor.Status.BANANA_VISIT_ORANGE);

                pO.Accept(pA);
                CHECK(MailBox_CollisionVisitor.TestValue() == MailBox_CollisionVisitor.Status.APPLE_VISIT_ORANGE);

                pB.Accept(pO);
                CHECK(MailBox_CollisionVisitor.TestValue() == MailBox_CollisionVisitor.Status.BANANA_ELEMENT_ERROR);

            }
            else
            {
                IGNORE();
            }
        }
    }
}

// --- End of File ---

