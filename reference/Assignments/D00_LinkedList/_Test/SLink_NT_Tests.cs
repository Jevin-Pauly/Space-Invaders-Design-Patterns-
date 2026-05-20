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
    public class SLink_NT_Tests : UnitTestBase
    {
        public void SLink_NT_Shakeout()
        {
            if (Tests_Flags.SLink_NT_Test_Enable)
            {
                Flower pA0 = new Flower(Flower.Name.Daisy, 77);
                Flower pA1 = new Flower(Flower.Name.Iris, 22);
                Flower pA2 = new Flower(Flower.Name.Lily, 11);
                Flower pA3 = new Flower(Flower.Name.Orchid, 44);

                SLink_NT_Manager pMan = new SLink_NT_Manager();

                // ---------------------------
                // Add to the front --> check
                // ---------------------------

                pMan.AddToFront(pA3);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pNext == null);

                pMan.AddToFront(pA2);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pNext == null);

                pMan.AddToFront(pA1);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pNext == null);

                pMan.AddToFront(pA0);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pNext == null);

                // ---------------------------
                // Remove --> check
                // ---------------------------

                pMan.Remove(pA2);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pNext == pA3);

                CHECK(pA3.pNext == null);

                pMan.Remove(pA3);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pNext == null);

                pMan.Remove(pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pNext == null);

                pMan.Remove(pA1);

                CHECK(pMan.poHead == null);

                // ---------------------------
                // Add to the End --> check
                // ---------------------------

                pMan.AddToEnd(pA0);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == null);

                pMan.AddToEnd(pA1);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pNext == null);

                pMan.AddToEnd(pA2);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pNext == null);

                pMan.AddToEnd(pA3);

                CHECK(pMan.poHead == pA0);

                CHECK(pA0.pNext == pA1);

                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pNext == null);

                // ---------------------------
                // Remove from Front --> check
                // ---------------------------

                Flower pTmp;

                pTmp = (Flower)pMan.RemoveFromFront();

                CHECK(pTmp == pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pNext == null);

                pTmp = (Flower)pMan.RemoveFromFront();

                CHECK(pTmp == pA1);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pNext == null);

                pTmp = (Flower)pMan.RemoveFromFront();

                CHECK(pTmp == pA2);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pNext == null);

                pTmp = (Flower)pMan.RemoveFromFront();

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

