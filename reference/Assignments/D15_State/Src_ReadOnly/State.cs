//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    abstract public class State : SLink
    {
        public enum Name
        {
            SittingState,
            StandingState,
            WalkingState,
            Uninitialized
        };
        public State()
        {
            this.name = Name.Uninitialized;
            this.pContext = null;
        }

        // Hint - this might be useful in initializing derived class
        public State(Name _name)
        {
            this.name = _name;
            this.pContext = null;
        }

        public void SetContext(Context _pContext)
        {
            Debug.Assert(_pContext != null);
            this.pContext = _pContext;
        }

        public Context GetContext()
        {
            return this.pContext;
        }

        public virtual void Stand()
        {
            // NORMALLY this is an abstract method...
            //    Its virtual and implemented for unit testing purposes
            //    Treat this method "as if" it is abstract...so override in derived
            Debug.Assert(false);
        }
        public virtual void Sit()
        {
            // NORMALLY this is an abstract method...
            //    Its virtual and implemented for unit testing purposes
            //    Treat this method "as if" it is abstract...so override in derived
            Debug.Assert(false);
        }
        public virtual void Walk()
        {
            // NORMALLY this is an abstract method...
            //    Its virtual and implemented for unit testing purposes
            //    Treat this method "as if" it is abstract...so override in derived
            Debug.Assert(false);
        }
        public virtual void Stop()
        {
            // NORMALLY this is an abstract method...
            //    Its virtual and implemented for unit testing purposes
            //    Treat this method "as if" it is abstract...so override in derived
            Debug.Assert(false);
        }

        // Do not modify anything in this class
        public Context pContext;
        public Name name;
    }
}

// --- End of File ---
