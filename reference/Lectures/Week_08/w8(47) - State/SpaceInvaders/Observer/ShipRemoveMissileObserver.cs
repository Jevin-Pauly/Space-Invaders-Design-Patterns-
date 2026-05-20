//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ShipRemoveMissileObserver : ColObserver
    {
        public ShipRemoveMissileObserver()
        {
            this.pMissile = null;
        }

        public ShipRemoveMissileObserver(ShipRemoveMissileObserver m)
        {
            this.pMissile = m.pMissile;
        }

        public override void Notify()
        {
            // Delete missile
            // Debug.WriteLine("ShipRemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // At this point we have two game objects
            // Actually we can control the objects in the visitor
            // Alphabetical ordering... A is missile,  B is wall

            // This cast will throw an exception if I'm wrong
            Missile pMissile = (Missile)this.pSubject.pObjA;

            // Debug.WriteLine("MissileRemoveObserver: --> delete missile {0}", pMissile);


        }

        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pMissile.Remove();
        }


        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.ShipRemoveMissileObserver;
        }

        // data
        private GameObject pMissile;


    }
}

// --- End of File ---
