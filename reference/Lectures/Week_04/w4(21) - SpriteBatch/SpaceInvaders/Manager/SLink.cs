//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class SLink : NodeBase
{

        protected SLink()
            : base()
    {
            this.baseClear();
        }

        public void Clear()
        {
            this.baseClear();
        }

        protected void baseClear()
        {
            this.pNext = null;
        }

        // Becomes optional with a virtual with default implementation
        override public object GetName()
        {
            return null;
        }

        protected void baseDump()
        {
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                NodeBase pTmp = (NodeBase)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }
        }

        // Data: -----------------------------
        public SLink pNext;

    }
}

// --- End of File ---