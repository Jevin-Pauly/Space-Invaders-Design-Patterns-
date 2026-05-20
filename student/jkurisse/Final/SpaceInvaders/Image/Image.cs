//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class Image : SLink
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
            BlueBird,

            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,
            MsPacMan,
            PowerUpGhost,
            Prezel,

            UFO,

            Missile,
            Ship,
            Shield,

            OctopusA,
            CrabA,
            SquidA,

            OctopusB,
            CrabB,
            SquidB,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_LeftBottom,
            Brick_RightBottom,

            NullObject,
            HotPink,
            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public Image()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect = new Azul.Rect();
        }

        //------------------------------------
        // Methods
        //------------------------------------
        public void Set(Name name, Texture pSrcTexture, float x, float y, float w, float h)
        {
            Debug.Assert(pSrcTexture != null);
            this.pTexture = pSrcTexture;

            // Remember the allocation was already made in constructor
            // so don't remove... replace the data
            this.poRect.Set(x,y,w,h);

            this.name = name;
        }
        private void privClear()
        {
            Debug.Assert(this.poRect != null);
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect.Clear();
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.pTexture.GetAzulTexture();
        }

        public Azul.Rect GetAzulRect()
        {
            return this.poRect;
        }

        //------------------------------------
        // Override
        //------------------------------------
        public override System.Enum GetName()
        {
            return this.name;
        }
        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            if (this.pTexture == null)
            {
                Debug.WriteLine("      Texture: null");
            }
            else
            {
                Debug.WriteLine("      Texture: {0}", this.pTexture.name);
            }
            Debug.WriteLine("      Rect: [{0} {1} {2} {3}] ", this.poRect.x, this.poRect.y, this.poRect.width, this.poRect.height);

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public Name name;
        public Azul.Rect poRect;
        public Texture pTexture;
    }
}

// --- End of File ---
