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
    public class DLink_EndPtr_Tests : UnitTestBase
    {
        public void DLink_EndPtr_Shakeout()
        {
            if (Tests_Flags.DLink_EndPtr_Test_Enable)
            {
                Fruit pA0 = new Fruit(Fruit.Name.Apple, 77);
                Fruit pA1 = new Fruit(Fruit.Name.Banana, 22);
                Fruit pA2 = new Fruit(Fruit.Name.Cranberry, 11);
                Fruit pA3 = new Fruit(Fruit.Name.Lime, 44);

                DLink_EndPtr_Manager pMan = new DLink_EndPtr_Manager();

                // ---------------------------
                // Add to the front --> check
                // ---------------------------

                pMan.AddToFront(pA3);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pPrev == null);
                CHECK(pA3.pNext == null);

                pMan.AddToFront(pA2);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pPrev == null);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                pMan.AddToFront(pA1);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == null);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                pMan.AddToFront(pA0);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                // ---------------------------
                // Remove --> check
                // ---------------------------

                pMan.Remove(pA2);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA3);

                CHECK(pA3.pPrev == pA1);
                CHECK(pA3.pNext == null);

                pMan.Remove(pA3);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == null);

                pMan.Remove(pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == null);
                CHECK(pA1.pNext == null);

                pMan.Remove(pA1);

                CHECK(pMan.poHead == null);

                // ---------------------------
                // Add to the End --> check
                // ---------------------------

                pMan.AddToEnd(pA0);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == null);

                pMan.AddToEnd(pA1);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == null);

                pMan.AddToEnd(pA2);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == null);

                pMan.AddToEnd(pA3);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pPrev == null);
                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pPrev == pA0);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                // ---------------------------
                // Remove from Front --> check
                // ---------------------------

                Fruit pTmp;

                pTmp = (Fruit)pMan.RemoveFromFront();

                CHECK(pTmp == pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == null);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                pTmp = (Fruit)pMan.RemoveFromFront();

                CHECK(pTmp == pA1);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pPrev == null);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                pTmp = (Fruit)pMan.RemoveFromFront();

                CHECK(pTmp == pA2);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pPrev == null);
                CHECK(pA3.pNext == null);

                pTmp = (Fruit)pMan.RemoveFromFront();

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

