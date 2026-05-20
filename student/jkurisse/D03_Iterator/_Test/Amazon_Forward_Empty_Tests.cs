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
    public class Amazon_Forward_Empty_Iterator_Tests : UnitTestBase
    {
        public void Amazon_Forward_Empty_Iterator()
        {
            if (Tests_Flags.Amazon_Forward_Iterator_Empty_Enable)
            {
                Amazon pAmazon = new Amazon();
                CHECK(pAmazon != null);

                // ------------------------------------

                // iterator test
                Box_ForwardIterator pIt = new Box_ForwardIterator(pAmazon);
                CHECK(pIt != null);

                // -----------------------------------

                Box pTmp = pIt.First();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                bool flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                // ------------------------------------

                // iterator test
                Box_ForwardIterator pIt2 = new Box_ForwardIterator(null);
                CHECK(pIt2 != null);

                // -----------------------------------

                pTmp = pIt2.First();
                CHECK(pTmp == null);

                pTmp = pIt2.Current();
                CHECK(pTmp == null);

                flag = pIt2.IsDone();
                CHECK(flag == true);

                pTmp = pIt2.Next();
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

