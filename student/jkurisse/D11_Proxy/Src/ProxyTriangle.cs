//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    // -----------------------------------------------
    // Add CODE/REFACTOR here
    // -----------------------------------------------
    //    Fill in methods
    //    Add additional methods if desired
    //    Add additional data if desired
    // -----------------------------------------------
    public class ProxyTriangle : Shape
    {
        public ProxyTriangle(RealTriangle _pRealTriangle, float _x, float _y)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            proxy = _pRealTriangle;
            //proxy.Ax = _pRealTriangle.Ax;
            //proxy.Ay = _pRealTriangle.Ay;
            //proxy.Bx = _pRealTriangle.Bx;
            //proxy.By = _pRealTriangle.By;
            //proxy.Cx = _pRealTriangle.Cx;
            //proxy.Cy = _pRealTriangle.Cy;

            proxy.CenterX = _x;
            proxy.CenterY = _y;

        }
        public override void Draw()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            //Hardware pHardware = Hardware.GetInstance();
            proxy.Draw();
        }

        // ------------------------------
        //    Data
        // ------------------------------

        private RealTriangle proxy;
    }



}

// --- End of File ---
