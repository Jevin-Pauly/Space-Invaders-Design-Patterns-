//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Singleton : Singleton_Base
    {
        // -------------------------------------------------------------------
        // GetInstance() - responsible for creating its class
        //         Return unique instance 
        //         Create if first time... Create Instance
        // -------------------------------------------------------------------
        static public Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        // ------------------------------------------------------------------
        // Note: default constructor needs to be private
        //       initialized x to 5, y to 6
        // ------------------------------------------------------------------
        private Singleton() : base(5,6)
        {
           
        }

        static private Singleton instance;
        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------

    }
}

// --- End of File ---

