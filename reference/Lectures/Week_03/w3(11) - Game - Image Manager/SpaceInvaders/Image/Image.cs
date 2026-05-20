//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class Image : DLink
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

            Uninitialized
        }

        //------------------------------------
        // Constructor
        //------------------------------------

        public Image()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect = new Azul.Rect();
        }

        public Image(Name name, Texture pSrcTexture, Azul.Rect pSubRect)
            : base()
        {
            Debug.Assert(pSrcTexture != null);
            Debug.Assert(pSubRect != null);
            this.pTexture = pSrcTexture;
            this.poRect = new Azul.Rect(pSubRect);
        }

        public void Set(Name name, Texture pSrcTexture, Azul.Rect pSubRect)
        {
            Debug.Assert(pSrcTexture != null);
            Debug.Assert(pSubRect != null);
            this.pTexture = pSrcTexture;

            // Remember the allocation was already made in constructor
            // so don't remove... replace the data
            this.poRect.Set(pSubRect);

            this.name = name;
        }

        //------------------------------------
        // Override
        //------------------------------------

        public override object GetName()
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

        private void privClear()
        {
            Debug.Assert(this.poRect != null);
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect.Clear();
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
