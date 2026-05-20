using SE456;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    abstract public class SLink : NodeBase
    {
        // ------------------------------
        // Add CODE/REFACTOR here
        // ------------------------------
        protected SLink()
            : base()
        {
            this.baseClear();
        }
        public void Clear()
        {
            this.baseClear();
            //this.pNext = null;
        }

        protected void baseClear()
        {
            this.pNext = null;
            //this.pPrev = null;
        }

        override public object GetName()
        {
            return null;
        }

        protected void baseDump()
        {
            //if (this.pPrev == null)
            //{
            //    Debug.WriteLine("      prev: null");
            //}
            //else
            //{
            //    NodeBase pTmp = (NodeBase)this.pPrev;
            //    Debug.WriteLine("      prev: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            //}

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

        // ------------------------------
        // Data:
        // ------------------------------
        public SLink pNext;

    }
}
