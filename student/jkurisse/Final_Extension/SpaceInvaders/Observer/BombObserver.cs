//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    class BombObserver : ColObserver
    {
        public BombObserver()
        {
            this.pBomb = null;

        }
        public BombObserver(BombObserver b)
        {
            this.pBomb = b.pBomb;
            //this.pBombRoot = (BombRoot)GameObjectNodeMan.Find(GameObject.Name.BombRoot);
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveBombObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pBomb = (Bomb)this.pSubject.pObjA;
            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                BombObserver pObserver = new BombObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pBomb.Remove();
            this.pBombRoot.bombCount--;
        }

        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.BombObserver;
        }

        // --------------------------------------
        // data:
        // --------------------------------------

        private GameObject pBomb;
        private BombRoot pBombRoot = (BombRoot)GameObjectNodeMan.Find(GameObject.Name.BombRoot);
    }
}

// --- End of File ---
