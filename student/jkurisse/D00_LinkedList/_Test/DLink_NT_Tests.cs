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
    public class DLink_NT_Tests : UnitTestBase
    {
        public void DLink_NT_Shakeout()
        {
            if (Tests_Flags.DLink_NT_Test_Enable)
            {
                Animal pA0 = new Animal(Animal.Name.Bird, 77);
                Animal pA1 = new Animal(Animal.Name.Cat, 22);
                Animal pA2 = new Animal(Animal.Name.Dog, 11);
                Animal pA3 = new Animal(Animal.Name.Fish, 44);

                DLink_NT_Manager pMan = new DLink_NT_Manager();

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

                Animal pTmp;

                pTmp = (Animal)pMan.RemoveFromFront();

                CHECK(pTmp == pA0);

                CHECK(pMan.poHead == pA1);

                CHECK(pA1.pPrev == null);
                CHECK(pA1.pNext == pA2);

                CHECK(pA2.pPrev == pA1);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                pTmp = (Animal)pMan.RemoveFromFront();

                CHECK(pTmp == pA1);

                CHECK(pMan.poHead == pA2);

                CHECK(pA2.pPrev == null);
                CHECK(pA2.pNext == pA3);

                CHECK(pA3.pPrev == pA2);
                CHECK(pA3.pNext == null);

                pTmp = (Animal)pMan.RemoveFromFront();

                CHECK(pTmp == pA2);

                CHECK(pMan.poHead == pA3);

                CHECK(pA3.pPrev == null);
                CHECK(pA3.pNext == null);

                pTmp = (Animal)pMan.RemoveFromFront();

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

