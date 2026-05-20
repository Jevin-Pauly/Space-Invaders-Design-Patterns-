//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ShieldColumn : Composite
    {
        public ShieldColumn(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
            base.Resurrect(SpriteGame.Name.def);
        }

        ~ShieldColumn()
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
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Visit(Missile m)
        {
            // Missile vs ShieldColumn
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

        public override void Visit(Bomb b)
        {
            // Bomb vs WallRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(b, pGameObj);
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ---------------------------------------------
        // Data: 
        // ---------------------------------------------


    }
}

// --- End of File ---
