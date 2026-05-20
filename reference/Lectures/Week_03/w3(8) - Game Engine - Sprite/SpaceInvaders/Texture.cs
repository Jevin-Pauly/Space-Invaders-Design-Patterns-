//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class Texture
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            Aliens,
            Stitch,
            Birds,

            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public Texture(Name name, string pTextureName)
        {
            Debug.Assert(pTextureName != null);

            // Do the create and load
            this.poAzulTexture = new Azul.Texture(pTextureName);
            Debug.Assert(this.poAzulTexture != null);

            this.name = name;
        }

        //------------------------------------
        // Data
        //------------------------------------
        public Name name;
        public Azul.Texture poAzulTexture;
    }
}

// --- End of File ---
