//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Context
    {

        public Context()
        {
            this.currName = State.Name.Uninitialized;
            this.pState = null;
            this.poHead = null;
        }

        public void Sit()
        {
            this.pState.Sit();
        }

        public void Stand()
        {
            this.pState.Stand();
        }

        public void Walk()
        {
            this.pState.Walk();
        }

        public void Stop()
        {
            this.pState.Stop();
        }

        public State.Name GetState()
        {
            return this.currName;
        }

        public void Detach(State pState)
        {
            Debug.Assert(pState != null);
            Debug.Assert(this.poHead != null);

            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
            State current = this.poHead;
            State previous = null;

            while (current != null)
            {
                if (current == pState)
                {
                    if (previous == null)
                    {
                        this.poHead = (State)current.pNext;
                    }
                    else
                    {
                        previous.pNext = current.pNext;
                    }
                    // Removing the states link
                    current.pNext = null;
                    break;
                }
                previous = current;
                current = (State)current.pNext;
            }
        }

        public void Attach(State pState)
        {
            Debug.Assert(pState != null);

            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
            if (this.poHead == null)
            {
                this.poHead = pState;
                this.pState = pState;
            }
            else
            {
                pState.pNext = this.poHead;
                this.poHead = pState;
            }
            pState.SetContext(this);
        }

        public void SetState( State.Name name)
        {
            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
            if(pState.name != name)
            {
                pState = poHead;
                while (pState != null)
                {
                    if (pState.name == name)
                    {
                        break;
                    }
                    pState = (State)pState.pNext;
                }
            }



            //switch (name)
            //{
            //    case State.Name.SittingState:
            //        this.Sit();
            //        break;
            //    case State.Name.StandingState:
            //        this.Stand();
            //        break;
            //    case State.Name.WalkingState:
            //        this.Walk();
            //        break;
            //    default:
            //        Debug.WriteLine("Invalid state name.");
            //        break;
            //}
            this.pState.SetContext(this);
            this.currName = name;
        }



        // -------------------------------
        //   DO NOT change data members
        // -------------------------------
        private State       pState;
        private State       poHead;
        private State.Name  currName;
    }
}

// --- End of File ---
