//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SE456
{
    public class TimerEventMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public TimerEventMan(int reserveNum = 1, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   
        {
            // initialize derived data here
            this.poNodeCompare = new TimerEvent();
            this.mCurrTime = 0.0f;
            this.move = true;
            TimerEventMan.psActiveTimerMan = null;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new TimerEventMan(reserveNum, reserveGrow);
            }

        }
        public static void Destroy(bool bPrintEnable = false)
        {
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                TimerEventMan.DumpStats();
            }
        }

        public static TimerEvent Add(TimerEvent.Name timeName, Command pCommand, float deltaTimeToTrigger)
        {
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            TimerEvent pNode = (TimerEvent)pMan.basePartialAdd(TimerEventMan.GetCurrTime() + deltaTimeToTrigger);
            Debug.Assert(pNode != null);
            Debug.Assert(pCommand != null);
            Debug.Assert(deltaTimeToTrigger >= 0.0f);

            pNode.Set(timeName, pCommand, deltaTimeToTrigger);
            pNode.priority = pNode.triggerTime;
            return pNode;
        }


        public static void SetActive(TimerEventMan pTimerMan)
        {
            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pTimerMan != null);
            TimerEventMan.psActiveTimerMan = pTimerMan;
        }

        public static TimerEvent Find(TimerEvent.Name name)
        {
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            TimerEvent pData = (TimerEvent)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(TimerEvent pImage)
        {
            Debug.Assert(pImage != null);

            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            pMan.baseRemove(pImage);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ TimerEvent Man: ------");

            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            pMan.baseDump();

        }
        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ TimerEvent Man: ------");

            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }

        public static void PauseUpdate(float delta)
        {
            // Get the instance
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            // walk the list
            Iterator pIt = pMan.baseGetIterator();
            Debug.Assert(pIt != null);

            // Update the times
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                TimerEvent pEvent = (TimerEvent)pIt.Current();
                pEvent.triggerTime += delta;
                pEvent.priority += delta;
            }

        }

        public static void Update(float totalTime)
        {
           // Debug.WriteLine("Time: {0}", totalTime);
            // Get the instance
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            // squirrel away
            pMan.mCurrTime = totalTime;

            // walk through the list and execute
            Iterator pIt = pMan.baseGetIterator();
            Debug.Assert(pIt != null);

            TimerEvent pNode = null;

            // Walk the list until there is no more list OR currTime is greater than timeEvent 
            // ToDo Fix: List needs to be sorted then its an early out
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                pNode = (TimerEvent)pIt.Current();
                if (pMan.mCurrTime >= pNode.triggerTime)
                {
                    // call it
                    pNode.Process();

                    // remove from list
                    pIt.Erase(pMan);
                }
                else
                {
                    //Debug.WriteLine("Curr Time: {0}     Trigger Timer: {1}",pMan.mCurrTime, pNode.triggerTime);
                    break;
                }
            }

        }



        public static void ResetAnimation()
        {
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            Iterator pIt = pMan.baseGetIterator();
            Debug.Assert(pIt != null);

            TimerEvent pNode = null;

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                pNode = (TimerEvent)pIt.Current();
                if (pNode.name == TimerEvent.Name.Animation)
                {
                    pNode.Reset();
                }
            }
        }

        public static float GetCurrTime()
        {
            // Get the instance
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            // return time
            return pMan.mCurrTime;
        }

        public static bool GetMove()
        {
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            return pMan.move;
        }

        public static void SwitchMove()
        {
            TimerEventMan pMan = TimerEventMan.psActiveTimerMan;
            Debug.Assert(pMan != null);

            if(pMan.move)
            {
                pMan.move = false;
            }
            else
            {
                pMan.move = true;
            }
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static TimerEventMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new TimerEvent();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private static TimerEventMan psActiveTimerMan;
        private readonly TimerEvent poNodeCompare;
        private static TimerEventMan pInstance = null;
        protected float mCurrTime;
        public bool move;
    }
}

// --- End of File ---

