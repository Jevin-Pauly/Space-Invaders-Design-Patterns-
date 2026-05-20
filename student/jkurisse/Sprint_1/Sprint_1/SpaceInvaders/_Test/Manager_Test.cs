//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using UnitTest;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace SpaceInvaders
{
    public class Manager_Test : UnitTestBase
    {
        public void Manager_AddToFront_Test()
        {
            if (Tests_Flags.Manager_AddToFront_Test_Enable)
            {
                Manager pMan = new Manager(0, 2);

                CHECK(pMan.GetActiveHead() == null);
                CHECK(pMan.GetReserveHead() == null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 0);
                CHECK(pMan.GetNumReserved() == 0);
                CHECK(pMan.GetNumActive() == 0);

                Node pBird = pMan.Add(Node.Name.Bird, 55);

                CHECK(pMan.GetActiveHead() == pBird);
                CHECK(pMan.GetReserveHead() != null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 2);
                CHECK(pMan.GetNumReserved() == 1);
                CHECK(pMan.GetNumActive() == 1);

                Node pCat = pMan.Add(Node.Name.Cat, 66);

                CHECK(pMan.GetActiveHead() == pCat);
                CHECK(pMan.GetReserveHead() == null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 2);
                CHECK(pMan.GetNumReserved() == 0);
                CHECK(pMan.GetNumActive() == 2);

                Node pDog = pMan.Add(Node.Name.Dog, 77);

                CHECK(pMan.GetActiveHead() == pDog);
                CHECK(pMan.GetReserveHead() != null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 1);
                CHECK(pMan.GetNumActive() == 3);

                Node pFish = pMan.Add(Node.Name.Fish, 88);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() == null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 0);
                CHECK(pMan.GetNumActive() == 4);

            }
            else
            {
                IGNORE();
            }
        }


        public void Manager_Remove_Test()
        {
            if (Tests_Flags.Manager_Remove_Test_Enable)
            {

                Manager pMan = new Manager(0, 2);

                CHECK(pMan.GetActiveHead() == null);
                CHECK(pMan.GetReserveHead() == null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 0);
                CHECK(pMan.GetNumReserved() == 0);
                CHECK(pMan.GetNumActive() == 0);

                Node pBird = pMan.Add(Node.Name.Bird, 55);
                Node pCat = pMan.Add(Node.Name.Cat, 66);
                Node pDog = pMan.Add(Node.Name.Dog, 77);
                Node pFish = pMan.Add(Node.Name.Fish, 88);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() == null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 0);
                CHECK(pMan.GetNumActive() == 4);

                pMan.Remove(pDog);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() == pDog);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 1);
                CHECK(pMan.GetNumActive() == 3);

                pMan.Remove(pBird);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() == pBird);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 2);
                CHECK(pMan.GetNumActive() == 2);

                pMan.Remove(pFish);

                CHECK(pMan.GetActiveHead() == pCat);
                CHECK(pMan.GetReserveHead() == pFish);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 3);
                CHECK(pMan.GetNumActive() == 1);

                pMan.Remove(pCat);

                CHECK(pMan.GetActiveHead() == null);
                CHECK(pMan.GetReserveHead() == pCat);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 4);
                CHECK(pMan.GetNumReserved() == 4);
                CHECK(pMan.GetNumActive() == 0);
            }
            else
            {
                IGNORE();
            }
        }

        public void Manager_Pooling_Test()
        {
            if (Tests_Flags.Manager_Pooling_Test_Enable)
            {
                Manager pMan = new Manager(3, 2);

                CHECK(pMan.GetActiveHead() == null);
                CHECK(pMan.GetReserveHead() != null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 3);
                CHECK(pMan.GetNumReserved() == 3);
                CHECK(pMan.GetNumActive() == 0);

                Node pBird = pMan.Add(Node.Name.Bird, 55);

                CHECK(pMan.GetActiveHead() == pBird);
                CHECK(pMan.GetReserveHead() != null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 3);
                CHECK(pMan.GetNumReserved() == 2);
                CHECK(pMan.GetNumActive() == 1);

                Node pCat = pMan.Add(Node.Name.Cat, 66);

                CHECK(pMan.GetActiveHead() == pCat);
                CHECK(pMan.GetReserveHead() != null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 3);
                CHECK(pMan.GetNumReserved() == 1);
                CHECK(pMan.GetNumActive() == 2);

                Node pDog = pMan.Add(Node.Name.Dog, 77);

                CHECK(pMan.GetActiveHead() == pDog);
                CHECK(pMan.GetReserveHead() == null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 3);
                CHECK(pMan.GetNumReserved() == 0);
                CHECK(pMan.GetNumActive() == 3);

                Node pFish = pMan.Add(Node.Name.Fish, 88);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() != null);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 5);
                CHECK(pMan.GetNumReserved() == 1);
                CHECK(pMan.GetNumActive() == 4);

                pMan.Remove(pCat);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() == pCat);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 5);
                CHECK(pMan.GetNumReserved() == 2);
                CHECK(pMan.GetNumActive() == 3);

                pMan.Remove(pBird);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() == pBird);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 5);
                CHECK(pMan.GetNumReserved() == 3);
                CHECK(pMan.GetNumActive() == 2);

                Node pWorm = pMan.Add(Node.Name.Worm, 123);

                CHECK(pMan.GetActiveHead() == pWorm);
                CHECK(pMan.GetReserveHead() == pCat);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 5);
                CHECK(pMan.GetNumReserved() == 2);
                CHECK(pMan.GetNumActive() == 3);
            }
            else
            {
                IGNORE();
            }
        }

        public void Manager_Find_Test()
        {
            if (Tests_Flags.Manager_Find_Test_Enable)
            {
                Manager pMan = new Manager(3, 2);

                Node pBird = pMan.Add(Node.Name.Bird, 55);
                Node pCat = pMan.Add(Node.Name.Cat, 66);
                Node pDog = pMan.Add(Node.Name.Dog, 77);
                Node pFish = pMan.Add(Node.Name.Fish, 88);

                CHECK(pMan.GetActiveHead() == pFish);
                CHECK(pMan.GetReserveHead() != pCat);
                CHECK(pMan.GetDeltaGrow() == 2);
                CHECK(pMan.GetTotalNumNodes() == 5);
                CHECK(pMan.GetNumReserved() == 1);
                CHECK(pMan.GetNumActive() == 4);

                Node pNode = pMan.Find(Node.Name.Dog);
                CHECK(pNode == pDog);

                Node pNode2 = pMan.Find(Node.Name.Fish);
                CHECK(pNode2 == pFish);

                Node pNode3 = pMan.Find(Node.Name.Worm);
                CHECK(pNode3 == null);


            }
            else
            {
                IGNORE();
            }
        }

    }
}

// --- End of File ---

