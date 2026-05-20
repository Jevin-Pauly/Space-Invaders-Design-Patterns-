//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class GridObserver : ColObserver
    {
        public GridObserver()
        {

        }
        override public void Notify()
        {
            //Debug.WriteLine(" Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // OK do some magic
            AlienRoot pAlienRoot = (AlienRoot)this.pSubject.pObjA;
            AlienGrid pGrid = pAlienRoot.GetAlienGrid();

            WallCategory pWall = (WallCategory)this.pSubject.pObjB;
            if (pWall.GetCategoryType() == WallCategory.Type.Right)
            {
                pGrid.SetDelta(-4.0f);
            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                pGrid.SetDelta(4.0f);
            }
            else
            {
                Debug.Assert(false);
            }

        }

        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.GridObserver;
        }


    }
}

// --- End of File ---
