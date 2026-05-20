//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class Image
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
        public Image(Name name, Texture pSrcTexture, Azul.Rect pSubRect)
        {
            Debug.Assert(pSrcTexture != null);
            Debug.Assert(pSubRect != null);
            this.pTexture = pSrcTexture;
            this.poRect = new Azul.Rect(pSubRect);
        }

        public Image()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect = new Azul.Rect();
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
