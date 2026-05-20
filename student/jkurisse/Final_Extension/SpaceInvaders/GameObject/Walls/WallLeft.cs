//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class WallLeft : WallCategory
    {
        public WallLeft(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Left)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }

        ~WallLeft()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.Visit(this);
        }
        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        public override void Visit(AlienRoot a)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }



        public override void Visit(AlienGrid a)
        {
            // BirdGroup vs WallRight
            //Debug.WriteLine("\ncollide: {0} with {1}", this, a);
            //Debug.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }


        public override void Visit(UFORoot u)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(u);
            ColPair.Collide(pGameObj, this);
        }
        public override void Visit(UFO u)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();

            pColPair.SetCollision(u, this);
            pColPair.NotifyListeners();

            u.x = 0;
            u.y = 0;
        }


        // Data: ---------------


    }
}

// --- End of File ---
