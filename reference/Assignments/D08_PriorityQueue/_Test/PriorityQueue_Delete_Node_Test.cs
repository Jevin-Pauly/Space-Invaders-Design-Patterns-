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
    public class PriorityQueue_Delete_Node_Tests : UnitTestBase
    {
        public void PriorityQueue_Delete_Node()
        {
            if (Tests_Flags.DeleteNode_Enable)
            {
                PriorityQueue pQueue = new PriorityQueue();
                CHECK(pQueue != null);

                Node pA = new Node(33, "A");
                CHECK(pA != null);
                CHECK(pA.key == 33);
                CHECK(pA.name == "A");

                Node pB = new Node(34, "B");
                CHECK(pB != null);
                CHECK(pB.key == 34);
                CHECK(pB.name == "B");

                Node pC = new Node(32, "C");
                CHECK(pC != null);
                CHECK(pC.key == 32);
                CHECK(pC.name == "C");

                Node pD = new Node(36, "D");
                CHECK(pD != null);
                CHECK(pD.key == 36);
                CHECK(pD.name == "D");

                Node pE = new Node(37, "E");
                CHECK(pE != null);
                CHECK(pE.key == 37);
                CHECK(pE.name == "E");

                Node pF = new Node(35, "F");
                CHECK(pF != null);
                CHECK(pF.key == 35);
                CHECK(pF.name == "F");

                //---------------------

                pQueue.Insert(pA);
                pQueue.Insert(pB);
                pQueue.Insert(pC);
                pQueue.Insert(pD);
                pQueue.Insert(pE);
                pQueue.Insert(pF);

                Node pTmp = null;

                pTmp = pQueue.GetHead();

                CHECK(pTmp != null);
                CHECK(pTmp == pC);
                CHECK(pTmp.GetNext() == pA);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "C");
                CHECK(pTmp.key == 32);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pA);
                CHECK(pTmp.GetNext() == pB);
                CHECK(pTmp.GetPrev() == pC);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "A");
                CHECK(pTmp.key == 33);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pB);
                CHECK(pTmp.GetNext() == pF);
                CHECK(pTmp.GetPrev() == pA);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "B");
                CHECK(pTmp.key == 34);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pF);
                CHECK(pTmp.GetNext() == pD);
                CHECK(pTmp.GetPrev() == pB);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "F");
                CHECK(pTmp.key == 35);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pD);
                CHECK(pTmp.GetNext() == pE);
                CHECK(pTmp.GetPrev() == pF);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "D");
                CHECK(pTmp.key == 36);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pE);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pD);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "E");
                CHECK(pTmp.key == 37);

                // ----------------------

                // remove last
                pQueue.Remove(pE);

                pTmp = pQueue.GetHead();

                CHECK(pTmp != null);
                CHECK(pTmp == pC);
                CHECK(pTmp.GetNext() == pA);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "C");
                CHECK(pTmp.key == 32);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pA);
                CHECK(pTmp.GetNext() == pB);
                CHECK(pTmp.GetPrev() == pC);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "A");
                CHECK(pTmp.key == 33);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pB);
                CHECK(pTmp.GetNext() == pF);
                CHECK(pTmp.GetPrev() == pA);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "B");
                CHECK(pTmp.key == 34);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pF);
                CHECK(pTmp.GetNext() == pD);
                CHECK(pTmp.GetPrev() == pB);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "F");
                CHECK(pTmp.key == 35);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pD);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pF);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "D");
                CHECK(pTmp.key == 36);

                // ----------------------

                // remove Middle
                pQueue.Remove(pB);

                pTmp = pQueue.GetHead();

                CHECK(pTmp != null);
                CHECK(pTmp == pC);
                CHECK(pTmp.GetNext() == pA);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "C");
                CHECK(pTmp.key == 32);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pA);
                CHECK(pTmp.GetNext() == pF);
                CHECK(pTmp.GetPrev() == pC);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "A");
                CHECK(pTmp.key == 33);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pF);
                CHECK(pTmp.GetNext() == pD);
                CHECK(pTmp.GetPrev() == pA);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "F");
                CHECK(pTmp.key == 35);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pD);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pF);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "D");
                CHECK(pTmp.key == 36);

                // ----------------------

                // remove First
                pQueue.Remove(pC);

                pTmp = pQueue.GetHead();

                CHECK(pTmp != null);
                CHECK(pTmp == pA);
                CHECK(pTmp.GetNext() == pF);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "A");
                CHECK(pTmp.key == 33);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pF);
                CHECK(pTmp.GetNext() == pD);
                CHECK(pTmp.GetPrev() == pA);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "F");
                CHECK(pTmp.key == 35);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pD);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pF);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "D");
                CHECK(pTmp.key == 36);

                // ----------------------

                // remove last
                pQueue.Remove(pD);

                pTmp = pQueue.GetHead();

                CHECK(pTmp != null);
                CHECK(pTmp == pA);
                CHECK(pTmp.GetNext() == pF);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "A");
                CHECK(pTmp.key == 33);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pF);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pA);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "F");
                CHECK(pTmp.key == 35);

                // ----------------------

                // remove Last
                pQueue.Remove(pF);

                pTmp = pQueue.GetHead();

                CHECK(pTmp != null);
                CHECK(pTmp == pA);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetType().Name == "Node");

                CHECK(pTmp.name == "A");
                CHECK(pTmp.key == 33);

                // ----------------------

                // remove Last
                pQueue.Remove(pA);

                pTmp = pQueue.GetHead();

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

