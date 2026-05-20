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
    public class Flyweight_Tests : UnitTestBase
    {
        public void Flyweight_Shakeout()
        {
            if (Tests_Flags.Shakeout_Enable)
            {

                Flyweight pFlyweight = new Flyweight();
                CHECK(pFlyweight != null);

                Letter p2 = pFlyweight.GetLetter("2");
                CHECK(p2 != null);
                CHECK(p2.mString == "2");

                Letter p0 = pFlyweight.GetLetter("0");
                CHECK(p0 != null);
                CHECK(p0.mString == "0");

                Letter p1 = pFlyweight.GetLetter("1");
                CHECK(p1 != null);
                CHECK(p1.mString == "1");

                Letter pA = pFlyweight.GetLetter("A");
                CHECK(pA != null);
                CHECK(pA.mString == "A");

                Letter pB = pFlyweight.GetLetter("B");
                CHECK(pB != null);
                CHECK(pB.mString == "B");

                Letter pC = pFlyweight.GetLetter("C");
                CHECK(pC != null);
                CHECK(pC.mString == "C");

                // remove an entry
                pFlyweight.Remove("C");
              
                Letter pTmp = null;

                pTmp = pFlyweight.GetLetter("1");
                CHECK(pTmp != null);
                CHECK(pTmp.mString == "1");
                CHECK(pTmp == p1);

                pTmp = pFlyweight.GetLetter("A");
                CHECK(pTmp != null);
                CHECK(pTmp.mString == "A");
                CHECK(pTmp == pA);

                pTmp = pFlyweight.GetLetter("B");
                CHECK(pTmp != null);
                CHECK(pTmp.mString == "B");
                CHECK(pTmp == pB);

                pTmp = pFlyweight.GetLetter("C");
                CHECK(pTmp != null);
                CHECK(pTmp.mString == "C");
                CHECK(pTmp != pC);

            }
            else
            {
                IGNORE();
            }
        }

    }
}

// --- End of File ---

