//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{

    abstract public class ColObserver : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            SoundObserver,
            GridObserver,
            ShipReadyObserver,
            ShipRemoveMissileObserver,
            RemoveAlienObserver,

            ShipBumpLeftObserver,
            ShipBumpRightObserver,
            RemoveBrickObserver,
            RemoveUFOObserver,

            Uninitialized
        }
        public abstract void Notify();

        public virtual void Execute()
        {
            // default implementation
        }
        override public void Wash()
        {
            Debug.Assert(false);
        }

        public ColSubject pSubject;
    }

    //override public void Dump()
    //{
    //    Debug.Assert(false);
    //}
    //override public System.Enum GetName()
    //{
    //    Debug.Assert(false);
    //}
}

// --- End of File ---
