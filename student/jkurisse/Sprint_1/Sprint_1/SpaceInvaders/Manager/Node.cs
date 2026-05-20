//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Node : SLink
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

        // ------------------------------
        // Add CODE/REFACTOR here
        // ------------------------------

        // Class should only initialize variables that it owns
        // Delegate the initialization to other classes
        public Node(Name name, int val)
        : base()  // <-- default constructor called
        {
            this.Set(name, val);
        }
        public void Set(Name name, int val)
        {
            this.name = name;
            this.x = val;
        }
        public void Wash()
        {
            this.name = Name.Unitialized;
            this.x = 0;
        }
        public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            //if (this.pPrev == null)
            //{
            //    Debug.WriteLine("      prev: null");
            //}
            //else
            //{
            //    Node pTmp = (Node)this.pPrev;
            //    Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            //}
        
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

        // ------------------------------
        // Data:
        // ------------------------------
        public Name name;
        public int x;

    }
}

// --- End of File ---
