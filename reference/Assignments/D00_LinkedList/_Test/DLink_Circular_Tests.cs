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
    public class DLink_Circular_Tests : UnitTestBase
    {
        public void DLink_Circular_Shakeout()
        {
            if (Tests_Flags.DLink_Circular_Test_Enable)
            {
                Car pA0 = new Car(Car.Name.Golf, 77);
                Car pA1 = new Car(Car.Name.Jetta, 22);
                Car pA2 = new Car(Car.Name.Polo, 11);
                Car pA3 = new Car(Car.Name.Rabbit, 44);

                DLink_Circular_Manager pMan = new DLink_Circular_Manager();

                // ---------------------------
                // Add to the front --> check
                // ---------------------------

                pMan.AddToFront(pA3);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pPrev == pA3);
                CHECK(pA3.pNext == pA3);

                pMan.AddToFront(pA2);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pPrev == pA3);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == pA2);

                pMan.AddToFront(pA1);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == pA3);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == pA1);

                pMan.AddToFront(pA0);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA3);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == pA0);

                // ---------------------------
                // Remove --> check
                // ---------------------------

                pMan.Remove(pA2);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA3);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA3);

                CHECK(pA3.pPrev == pA1);
                CHECK(pA3.pNext == pA0);

                pMan.Remove(pA3);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA1);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA0);

                pMan.Remove(pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == pA1);
                CHECK(pA1.pNext == pA1);

                pMan.Remove(pA1);

                CHECK(pMan.poHead == null);

                // ---------------------------
                // Add to the End --> check
                // ---------------------------

                pMan.AddToEnd(pA0);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA0);
                CHECK(pA0.pNext == pA0);

                pMan.AddToEnd(pA1);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA1);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA0);

                pMan.AddToEnd(pA2);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA2);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA0);

                pMan.AddToEnd(pA3);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == pA3);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == pA0);

                // ---------------------------
                // Remove from Front --> check
                // ---------------------------

                Car pTmp;

                pTmp = (Car)pMan.RemoveFromFront();

                CHECK(pTmp == pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == pA3);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == pA1);

                pTmp = (Car)pMan.RemoveFromFront();

                CHECK(pTmp == pA1);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pPrev == pA3);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == pA2);

                pTmp = (Car)pMan.RemoveFromFront();

                CHECK(pTmp == pA2);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pPrev == pA3);
                CHECK(pA3.pNext == pA3);

                pTmp = (Car)pMan.RemoveFromFront();

                CHECK(pTmp == pA3);

                CHECK(pMan.poHead == null);

            }
            else
            {
                IGNORE();
            }
        }


    }

}

// --- End of File ---

