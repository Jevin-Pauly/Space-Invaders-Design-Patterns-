//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using UnitTest;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Adapter_Tests : UnitTestBase
    {
        public void Adapter_Shakeout()
        {
            if (Tests_Flags.Adapter_Test_Enable)
            {
                MetricMachine pMetric = new MetricMachine();
                CHECK(pMetric != null);

                Imperial pImperial = new Imperial_Adapter(pMetric);
                CHECK(pImperial != null);

                // ------------------------------------
                
                CHECK(pMetric.GetLength() == 0.0f);
                CHECK(pMetric.GetVolume() == 0.0f);
                CHECK(pMetric.GetWeight() == 0.0f);

                CHECK(pImperial.GetLength() == 0.0f);
                CHECK(pImperial.GetVolume() == 0.0f);
                CHECK(pImperial.GetWeight() == 0.0f);

                // -----------------------------------

                // Gallons
                pImperial.SetVolume(555.5f);
                CHECK(Utility.AreEqual(pImperial.GetVolume(),555.5f,0.1f));
                CHECK(Utility.AreEqual(pMetric.GetVolume(), 2102.796f, 0.1f));

                // Pounds
                pImperial.SetWeight(222.2f);
                CHECK(Utility.AreEqual(pImperial.GetWeight(), 222.2f, 0.1f));
                CHECK(Utility.AreEqual(pMetric.GetWeight(), 100.788f, 0.1f));

                // Feet
                pImperial.SetLength(3333.3f);
                CHECK(Utility.AreEqual(pImperial.GetLength(), 3333.3f, 0.1f));
                CHECK(Utility.AreEqual(pMetric.GetLength(), 1015.989f, 0.1f));

                // -----------------------------------

                pMetric.ExternalUpdate();

                // Gallons
                CHECK(Utility.AreEqual(pImperial.GetVolume(), 683.238f, 0.1f));
                CHECK(Utility.AreEqual(pMetric.GetVolume(), 2586.3396f, 0.1f));

                // Pounds
                CHECK(Utility.AreEqual(pImperial.GetWeight(), 2222.022f, 0.1f));
                CHECK(Utility.AreEqual(pMetric.GetWeight(), 1007.852f, 0.1f));

                // Feet
                CHECK(Utility.AreEqual(pImperial.GetLength(), 76665.904f, 0.1f));
                CHECK(Utility.AreEqual(pMetric.GetLength(), 23367.7676f, 0.1f));

            }
            else
            {
                IGNORE();
            }
        }


    }

}

// --- End of File ---

