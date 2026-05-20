//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Animal : DLink
    {
        public enum Name
        {
            Cat,
            Dog,
            Bird,
            Fish,
            Rabbit,
            Worm,
            Unitialized
        }

        // Class should only initialize variables that it owns
        // Delegate the initialization to other classes
        public Animal(Name name, int val)
        : base()  // <-- default constructor called
        {
            this.Set(name, val);
        }

        public void Set(Name name, int val)
        {
            this.name = name;
            this.x = val;
        }



        public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                Animal pTmp = (Animal)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Animal pTmp = (Animal)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            // Data:
            Debug.WriteLine("      x: {0}", this.x);

        }

        // Data: --------------------------------
        public Name name;
        public int x;

    }
}


// --- End of File ---
