//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class AlienCategory : Leaf
    {
        public enum Type
        {
            Red,
            Yellow,
            Green,
            White,

            Octopus,
            Crab,
            Squid,
            
            Column,
            Grid,
            Root,

            Aliens,

            Unitialized
        }

        protected AlienCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y, AlienCategory.Type typename)
            : base(gameName,spriteName,_x,_y)
        {
            this.AlienType = typename;
        }

        ~AlienCategory()
        {
        }

        public override void Visit(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void Visit(Missile m)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();

            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();

            m.x = 0;
            m.y = 0;
        }


        public AlienCategory.Type GetCategoryType()
        {
            return this.AlienType;
        }

        protected AlienCategory.Type AlienType;
    }
}

// --- End of File ---
