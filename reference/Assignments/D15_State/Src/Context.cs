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
        }

        public void Attach(State pState)
        {
            Debug.Assert(pState != null);

            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
        }

        public void SetState( State.Name name)
        {
            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
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
