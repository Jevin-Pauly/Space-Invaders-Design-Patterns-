//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class ColVisitor : DLink
    {

        public virtual void Visit(AlienGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BirdGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(AlienColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BirdColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(BirdRed b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RedBird not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(BirdYellow b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by YellowBird not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(BirdGreen b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }


        public virtual void Visit(BirdWhite b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(MissileGroup m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }
       
        public virtual void Visit(GameObjectNull n)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(WallGroup w)
        {
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void Visit(WallRight w)
        {
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }
        public virtual void Visit(WallLeft w)
        {
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }



        public virtual void Visit(Squid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Squid not implemented");
            Debug.Assert(false);
        }
        public virtual void Visit(Crab b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(Octopus b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }



        abstract public void Accept(ColVisitor other);
    }

}

// --- End of File ---
