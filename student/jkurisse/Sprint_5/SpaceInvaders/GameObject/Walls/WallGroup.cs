//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class WallGroup : Composite
    {
        public WallGroup(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(1, 1, 1);

            this.name = name;
        }

        ~WallGroup()
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
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public override void Visit(AlienGrid a)
        {
            // BirdGroup vs WallGroup
            // Debug.WriteLine("collide: {0} with {1}", a, this);

            // BirdGroup vs WallGroup
            //              go down a level in Wall Group.
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(a, pGameObj);
        }



        // Data: ---------------


    }
}

// --- End of File ---
