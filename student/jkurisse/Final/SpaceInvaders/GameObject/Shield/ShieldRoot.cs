//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ShieldRoot : Composite
    {
        public ShieldRoot(GameObject.Name name, SpriteGame.Name spriteName)
            : base(name, spriteName)
        {
        }
        ~ShieldRoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.Visit(this);
        }
        public override void Visit(MissileGroup m)
        {
            // MissileRoot vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void Visit(Missile m)
        {
            // Missile vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Visit(AlienRoot a)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(a);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(AlienGrid a)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(a);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(AlienColumn a)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(a);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(Aliens a)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            if (pGameObj != null)
            {
                ColPair.Collide(a, pGameObj);
            }
        }

        public ShieldGrid GetShieldGrid()
        {
            return (ShieldGrid)IteratorForwardComposite.GetChild(this);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------


    }
}

// --- End of File ---
