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
    public class MetricMachine
    {
        public MetricMachine()
        {
            this.kilograms = 0.0f;
            this.liters = 0.0f;
            this.meters = 0.0f;
        }
        public void SetWeight(float _weight)
        {
            this.kilograms = _weight;
        }
        public void SetLength(float _length)
        {
            this.meters = _length;
        }
        public void SetVolume(float _volume)
        {
            this.liters = _volume;
        }

        public void ExternalUpdate()
        {
            this.kilograms *= 10.0f;
            this.meters *= 23.0f;
            this.liters += 483.55f;
        }

        public float GetWeight()
        {
            return this.kilograms;
        }
        public float GetLength()
        {
            return this.meters;
        }
        public float GetVolume()
        {
            return this.liters;
        }



        private float kilograms;
        private float meters;
        private float liters;

    }
}

// --- End of File ---

