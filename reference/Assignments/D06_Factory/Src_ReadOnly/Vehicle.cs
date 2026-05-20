//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public abstract class Vehicle
    {
        public enum Model
        {
            Jetta,
            Golf,
            Atlas,
            Tiguan
        }
        public enum Color
        {
            Red,
            Blue,
            Yellow,
            White,
            Black
        };
        public enum Engine
        {
            Petrol,
            Diesel,
            Electric
        }
        public enum Doors
        {
            Two,
            Four
        }
        public abstract void Drive();
        public abstract void Honk();
        public abstract void Park();
        
    }
}

// --- End of File ---
