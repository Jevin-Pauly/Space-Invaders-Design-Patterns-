//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class BirdYellow : AlienCategory
    {
        public BirdYellow(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.YellowBird, spriteName, posX, posY, AlienCategory.Type.Aliens)
        {
       
        }


        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an YellowBird
            // Call the appropriate collision reaction            
            other.Visit(this);
        }

        public override void Visit(MissileGroup m)
        {
            // Bird vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Bird
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void Update()
        {
            //  Debug.WriteLine("update: {0}", this);
            base.Update();
        }

        // Data
     

    }
}

// --- End of File ---
