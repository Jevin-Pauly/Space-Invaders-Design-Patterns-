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
    public class Amazon_Forward_Iterator_Tests : UnitTestBase
    {
        public void Amazon_Forward_Iterator()
        {
            if (Tests_Flags.Amazon_Forward_Iterator_Enable)
            {
                Amazon pAmazon = new Amazon();
                CHECK(pAmazon != null);

                Box pA = pAmazon.Add(Box.Name.WineGlass, 11);
                CHECK(pA != null);
                Box pB = pAmazon.Add(Box.Name.Parachute, 22);
                CHECK(pB != null);
                Box pC = pAmazon.Add(Box.Name.Vitamins, 33);
                CHECK(pC != null);
                Box pD = pAmazon.Add(Box.Name.Coffee, 44);
                CHECK(pD != null);

                Box pE = pAmazon.Add(Box.Name.Book, 55);
                CHECK(pE != null);
                Box pF = pAmazon.Add(Box.Name.BirdSeed, 66);
                CHECK(pF != null);
                Box pG = pAmazon.Add(Box.Name.AcientAlienPoster, 77);
                CHECK(pG != null);
                Box pH = pAmazon.Add(Box.Name.BirdSeed, 88);
                CHECK(pH != null);

                Box pI = pAmazon.Add(Box.Name.Corkscrew, 99);
                CHECK(pI != null);
                Box pJ = pAmazon.Add(Box.Name.Masks, 111);
                CHECK(pJ != null);
                Box pK = pAmazon.Add(Box.Name.Dogfood, 222);
                CHECK(pK != null);

                // Deliveries
                pF.Delivered();
                pA.Delivered();

                // ------------------------------------

                // iterator test
                Box_ForwardIterator pIt = new Box_ForwardIterator(pAmazon);
                CHECK(pIt != null);

                // ------------------------------------
                // Test should verify this loop
                // ------------------------------------
                //for (pIt.First(); !pIt.IsDone(); pIt.Next())
                //{
                //    Box p = pIt.Current();
                //    p.Print();
                //}

                // -----------------------------------

                Box pTmp = pIt.First();
                CHECK(pTmp == pI);

                bool flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pI);

                pTmp = pIt.Next();
                CHECK(pTmp == pJ);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pJ);

                pTmp = pIt.Next();
                CHECK(pTmp == pK);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pK);

                pTmp = pIt.Next();
                CHECK(pTmp == pE);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                pTmp = pIt.Next();
                CHECK(pTmp == pG);

                // ----- Take 2 - reset first --------

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pI);

                pTmp = pIt.Next();
                CHECK(pTmp == pJ);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pJ);

                pTmp = pIt.Next();
                CHECK(pTmp == pK);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pK);

                pTmp = pIt.Next();
                CHECK(pTmp == pE);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                pTmp = pIt.Next();
                CHECK(pTmp == pG);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pG);

                pTmp = pIt.Next();
                CHECK(pTmp == pH);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pH);

                pTmp = pIt.Next();
                CHECK(pTmp == pB);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pB);

                pTmp = pIt.Next();
                CHECK(pTmp == pC);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pC);

                pTmp = pIt.Next();
                CHECK(pTmp == pD);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.Current();
                CHECK(pTmp == pD);

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                // -----------------------------------

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                pTmp = pIt.Next();
                CHECK(pTmp == null);
            }
                else
            {
                IGNORE();
            }
        }
       
    }

}

// --- End of File ---

