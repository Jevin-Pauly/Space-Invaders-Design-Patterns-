//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class ColVisitor : DLink
    {
        // --- Alien Grouped Visits ---
        public virtual void Visit(AlienRoot b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(AlienGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienGrid not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(AlienColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }

        // --- Bird Visits (Not Used) ---

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

        // --- Missile Visits ---

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

        // --- Wall Visits ---

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

        public virtual void Visit(WallTop w)
        {
            Debug.WriteLine("Visit by WallTop not implemented");
            Debug.Assert(false);
        }
        public virtual void Visit(WallBottom w)
        {
            Debug.WriteLine("Visit by WallBottom not implemented");
            Debug.Assert(false);
        }
        public virtual void Visit(BumperLeft w)
        {
            Debug.WriteLine("Visit by BumperLeft not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(BumperRight w)
        {
            Debug.WriteLine("Visit by BumperRight not implemented");
            Debug.Assert(false);
        }


        // --- Alien Visits ---

        public virtual void Visit(Squid a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Squid not implemented");
            Debug.Assert(false);
        }
        public virtual void Visit(Crab a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(Octopus a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(Aliens a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Aliens not implemented");
            Debug.Assert(false);
        }

        // --- Ship Visits ---

        public virtual void Visit(Ship s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Ship not implemented");
            Debug.Assert(false);
        }

        public virtual void Visit(ShipRoot s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShipRoot not implemented");
            Debug.Assert(false);
        }


        abstract public void Accept(ColVisitor other);
    }

}

// --- End of File ---
