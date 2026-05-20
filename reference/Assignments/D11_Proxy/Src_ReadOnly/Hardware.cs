//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Hardware
    {
        public Hardware()
        {

        }
        public void Draw(RealTriangle pTriangle)
        {
            this.cacheCenterX = pTriangle.CenterX;
            this.cacheCenterY = pTriangle.CenterY;
            this.cacheAx = pTriangle.Ax;
            this.cacheAy = pTriangle.Ay;
            this.cacheBx = pTriangle.Bx;
            this.cacheBy = pTriangle.By;
            this.cacheCx = pTriangle.Cx;
            this.cacheCy = pTriangle.Cy;
        }

        static public Hardware GetInstance()
        {
            if (Hardware.pInstance == null)
            {
                Hardware.pInstance = new Hardware();
            }

            return Hardware.pInstance;
        }

        private static Hardware pInstance = null;

        public float cacheCenterX;
        public float cacheCenterY;
        public float cacheAx;
        public float cacheAy;
        public float cacheBx;
        public float cacheBy;
        public float cacheCx;
        public float cacheCy;
    }

}

// --- End of File ---
