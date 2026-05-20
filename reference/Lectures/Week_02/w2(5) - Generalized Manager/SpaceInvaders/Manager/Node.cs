//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class Node : DLink
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


        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------
        public Node()
        : base()   // <--- Delegate (kick the can)
        {
        // Class should only initialize variables that it owns
        // Delegate the initialization to other classes
            this.privClear();
        }
        public Node(Name name, int val)
            : base()   // <--- base class do your thing
        {
            this.Set(name, val);
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void Set(Name name, int val)
        {
            // Set - Node data  (only Node level)
            this.name = name;
            this.x = val;
        }
        public void Wash()
        {
            this.privClear();
        }
        private void privClear()
        {
            // Clear - Node data  (only Node level)
            this.name = Name.Unitialized;
            this.x = 0;
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
                Node pTmp = (Node)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Node pTmp = (Node)this.pNext;
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
