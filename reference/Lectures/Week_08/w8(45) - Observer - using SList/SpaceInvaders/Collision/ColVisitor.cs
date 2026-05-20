//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class ColVisitor : DLink
    {

        public virtual void VisitGroup(BirdGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BirdGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitColumn(BirdColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BirdColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitRedBird(BirdRed b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RedBird not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitYellowBird(BirdYellow b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by YellowBird not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitGreenBird(BirdGreen b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }


        public virtual void VisitWhiteBird(BirdWhite b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissile(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissileGroup(MissileGroup m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }
       
        public virtual void VisitNullGameObject(GameObjectNull n)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallGroup(WallGroup w)
        {
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallLeft(WallLeft w)
        {
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }

        abstract public void Accept(ColVisitor other);
    }

}

// --- End of File ---
