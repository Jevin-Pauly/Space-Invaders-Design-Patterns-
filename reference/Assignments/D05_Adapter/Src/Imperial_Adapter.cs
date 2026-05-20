//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Imperial_Adapter : Imperial
    {
        private Imperial_Adapter()
        {
            // prevent default constructor
        }
        public Imperial_Adapter(MetricMachine _pMetric)
        {
            Debug.Assert(_pMetric != null);

            poMetric = _pMetric;
            Debug.Assert(poMetric != null);
        }

        
        public override void SetWeight(float pounds)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
        }
        public override void SetLength(float feet)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
        }
        public override void SetVolume(float gallons)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
        }

        public override float GetWeight()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return -1.0f;
        }
        public override float GetLength()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return -1.0f;
        }
        public override float GetVolume()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return -1.0f;
        }


        // -------------------------------------------------
        // NO Extra Data - allowed in this class     
        // -------------------------------------------------
        private MetricMachine poMetric;

    }
}

// --- End of File ---

