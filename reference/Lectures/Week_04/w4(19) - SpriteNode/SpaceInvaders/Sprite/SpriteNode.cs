//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class SpriteNode : DLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,
            MsPacMan,
            PowerUpGhost,
            Prezel,

            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------

        public SpriteNode()
        : base()
        {
            this.pSprite = null;
        }

        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(Sprite.Name name)
        {
            // Go find it
            this.pSprite = SpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }
        private void privClear()
        {
            this.pSprite = null;
        }

        //------------------------------------
        // Override
        //------------------------------------

        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   ({0}) node", this.GetHashCode());

            // Data:
            Debug.WriteLine("   pSprite: {0} ({1})", this.pSprite.name, this.pSprite.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public Sprite pSprite;
    }
}

// --- End of File ---

