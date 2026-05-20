//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace PA
{
    class Golf : Vehicle
    {
        // ---------------------------------------------------------------
        // Add specialized constructor it must take Doors, Color, Engine
        // ---------------------------------------------------------------
        public Golf(Doors _d, Color _c, Engine _e)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            d = _d;
            c = _c; 
            e = _e;
            this.poStyle = new Hatchback();
            this.poDrive = new TwoWheelDrive();
        }

        public override void Drive()
        {
            // Do Not Change Method - unique Drive behavior for this model
        }
        public override void Honk()
        {
            // Do Not Change Method - unique Honk behavior for this model
        }
        public override void Park()
        {
            // Do Not Change Method - unique parking behavior for this model
        }

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        //    pass these enum into constructor
        //    other types use a default constructor to initalize
        // ----------------------------------------------------------
        public Doors d;
        public Color c;
        public Engine e;
        public Hatchback     poStyle;
        public TwoWheelDrive poDrive;
  
    }
}

// --- End of File ---
