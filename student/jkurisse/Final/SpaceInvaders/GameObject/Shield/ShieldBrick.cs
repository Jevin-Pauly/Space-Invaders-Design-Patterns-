//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ShieldBrick : ShieldCategory
    {
        public ShieldBrick(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName, posX, posY, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        public void Resurrect(float posX, float posY, SpriteGame.Name name)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
            base.Resurrect(name);
            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        ~ShieldBrick()
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
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(Missile m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Shield
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
            m.x = 0;
            m.y = 0;
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
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }
        public override void Update()
        {
            base.Update();
        }

        // ---------------------------------
        // Data: 
        // ---------------------------------


    }
}

// --- End of File ---
