//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    class Car
    {
        public Position pos;
        public int d;

        public Car()
        {
            this.d = 0;
            this.pos.x = 0;
            this.pos.y = 0;
        }

        public Car(int valD, int vX, int vY)
        {
            this.d = valD;
            this.pos.x = vX;
            this.pos.y = vY;
        }

        static public void AddHundred(Car pCar)
        {
            pCar.d += 100;
            pCar.pos.x += 100;
            pCar.pos.y += 100;
        }

        public void PrintMe()
        {
            Debug.WriteLine("  Pos x:{0} y:{1} ", this.pos.x, this.pos.y);
            Debug.WriteLine("  d:{0}", this.d);
        }

        public void GetPos(out Position position)
        {
            position.x = this.pos.x;
            position.y = this.pos.y;
        }

        static public void Presto(ref Car pCar)
        {
            pCar = new Car(111, 222, 333);

        }
    }
}

// --- End of File ---
