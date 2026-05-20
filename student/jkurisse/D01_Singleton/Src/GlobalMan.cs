//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class GlobalMan : GlobalMan_Base
    {
        // ------------------------------------------------------------------
        // Rules:
        //   1) ADD additional methods and/or data to this Class
        //   2) Leave the supplied signatures
        //         of the constructor and methods - alone
        // ------------------------------------------------------------------

        // ------------------------------------------------------------------
        // Note: default constructor needs to be private
        //       initialized x to 5, y to 6
        // ------------------------------------------------------------------
        
        //Constructor for initialization
        private GlobalMan() : base(5, 6)
        {
            // ---------------------------------------------------------
            // Do not change signature (leave this contructor alone)
            // ---------------------------------------------------------
        }

        static public void Add(int _x, int _y)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            GetInstance().proAdd(_x, _y);
        }
        static public void Sub(int _x, int _y)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            GetInstance().proSub(_x, _y);
        }

        static public int GetX()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return GetInstance().proGetX();
        }
        static public int GetY()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return GetInstance().proGetY();
        }

        //Create/Call Instance
        public static GlobalMan GetInstance()
        {
            //If no instance create instance using constructor above
            if (instance == null)
            {
                instance = new GlobalMan();
            }
            return instance;
        }

        //Single Instance
        public static GlobalMan instance;
        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------

    }
}

// --- End of File ---

