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
    public class Proxy_Tests : UnitTestBase
    {
        public void Command_Shakeout()
        {
            if (Tests_Flags.Proxy_Shakeout_Enable)
            {
                Hardware pHardware = Hardware.GetInstance();

                RealTriangle pRealTriangle = new RealTriangle();
                pRealTriangle.Draw();

                CHECK(pHardware.cacheCenterX == 12.0f);
                CHECK(pHardware.cacheCenterY == 13.0f);
                CHECK(pHardware.cacheAx == 55.0f);
                CHECK(pHardware.cacheAy == 56.0f);
                CHECK(pHardware.cacheBx == 155.0f);
                CHECK(pHardware.cacheBy == 156.0f);
                CHECK(pHardware.cacheCx == 255.0f);
                CHECK(pHardware.cacheCy == 256.0f);

                ProxyTriangle pA = new ProxyTriangle(pRealTriangle, 10, 100);
                pA.Draw();

                CHECK(pHardware.cacheCenterX == 10.0f);
                CHECK(pHardware.cacheCenterY == 100.0f);
                CHECK(pHardware.cacheAx == 55.0f);
                CHECK(pHardware.cacheAy == 56.0f);
                CHECK(pHardware.cacheBx == 155.0f);
                CHECK(pHardware.cacheBy == 156.0f);
                CHECK(pHardware.cacheCx == 255.0f);
                CHECK(pHardware.cacheCy == 256.0f);

                ProxyTriangle pB = new ProxyTriangle(pRealTriangle, 50, 200);
                pB.Draw();

                CHECK(pHardware.cacheCenterX == 50.0f);
                CHECK(pHardware.cacheCenterY == 200.0f);
                CHECK(pHardware.cacheAx == 55.0f);
                CHECK(pHardware.cacheAy == 56.0f);
                CHECK(pHardware.cacheBx == 155.0f);
                CHECK(pHardware.cacheBy == 156.0f);
                CHECK(pHardware.cacheCx == 255.0f);
                CHECK(pHardware.cacheCy == 256.0f);

                ProxyTriangle pC = new ProxyTriangle(pRealTriangle, 100, 300);
                pC.Draw();

                CHECK(pHardware.cacheCenterX == 100.0f);
                CHECK(pHardware.cacheCenterY == 300.0f);
                CHECK(pHardware.cacheAx == 55.0f);
                CHECK(pHardware.cacheAy == 56.0f);
                CHECK(pHardware.cacheBx == 155.0f);
                CHECK(pHardware.cacheBy == 156.0f);
                CHECK(pHardware.cacheCx == 255.0f);
                CHECK(pHardware.cacheCy == 256.0f);

                ProxyTriangle pD = new ProxyTriangle(pRealTriangle, 150, 400);
                pD.Draw();

                CHECK(pHardware.cacheCenterX == 150.0f);
                CHECK(pHardware.cacheCenterY == 400.0f);
                CHECK(pHardware.cacheAx == 55.0f);
                CHECK(pHardware.cacheAy == 56.0f);
                CHECK(pHardware.cacheBx == 155.0f);
                CHECK(pHardware.cacheBy == 156.0f);
                CHECK(pHardware.cacheCx == 255.0f);
                CHECK(pHardware.cacheCy == 256.0f);

                ProxyTriangle pE = new ProxyTriangle(pRealTriangle, 200, 500);
                pE.Draw();

                CHECK(pHardware.cacheCenterX == 200.0f);
                CHECK(pHardware.cacheCenterY == 500.0f);
                CHECK(pHardware.cacheAx == 55.0f);
                CHECK(pHardware.cacheAy == 56.0f);
                CHECK(pHardware.cacheBx == 155.0f);
                CHECK(pHardware.cacheBy == 156.0f);
                CHECK(pHardware.cacheCx == 255.0f);
                CHECK(pHardware.cacheCy == 256.0f);

                pA.Draw();

            }
            else
            {
                IGNORE();
            }
        }
    }
}

// --- End of File ---

