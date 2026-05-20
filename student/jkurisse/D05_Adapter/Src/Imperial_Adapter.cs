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
            pounds = pounds * 0.453592f;
            poMetric.SetWeight(pounds);
        }
        public override void SetLength(float feet)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            feet = feet * 0.3048f;
            poMetric.SetLength(feet);
        }
        public override void SetVolume(float gallons)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            gallons = gallons * 3.78541f;
            poMetric.SetVolume(gallons);
        }

        public override float GetWeight()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poMetric.GetWeight() * 2.20462f;
        }
        public override float GetLength()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poMetric.GetLength() * 3.28084f;
        }
        public override float GetVolume()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return poMetric.GetVolume() * 0.264172f;
        }


        // -------------------------------------------------
        // NO Extra Data - allowed in this class     
        // -------------------------------------------------
        private MetricMachine poMetric;

    }
}

// --- End of File ---

