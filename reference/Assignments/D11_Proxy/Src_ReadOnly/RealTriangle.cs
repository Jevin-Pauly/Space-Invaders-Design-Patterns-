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
    public class RealTriangle : Shape
    {
        public RealTriangle()
        {
            this.CenterX = 12.0f;
            this.CenterY = 13.0f;
            this.Ax = 55.0f;
            this.Ay = 56.0f;
            this.Bx = 155.0f;
            this.By = 156.0f;
            this.Cx = 255.0f;
            this.Cy = 256.0f;
        }
        public override void Draw()
        {
            Hardware pHardware = Hardware.GetInstance();
            pHardware.Draw(this);
        }

        public void SetCenter(float x, float y)
        {
            this.CenterX = x;
            this.CenterY = y;
        }

        // center point
        public float CenterX;
        public float CenterY;

        // three vertices
        public float Ax;
        public float Ay;
        public float Bx;
        public float By;
        public float Cx;
        public float Cy;
    }

}

// --- End of File ---
