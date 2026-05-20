//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class Sprite
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
        public Sprite(Name name, Image pImage, Azul.Rect pScreenRect)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(pImage.pTexture != null);
            Debug.Assert(pScreenRect != null);

            this.pImage = pImage;
            this.name = name;

            this.pAzulSprite = new Azul.Sprite(pImage.pTexture.poAzulTexture, pImage.poRect, pScreenRect);
            Debug.Assert(this.pAzulSprite != null);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
        }

        //------------------------------------
        // Methods
        //------------------------------------
        public void Update()
        {
            this.pAzulSprite.x = this.x;
            this.pAzulSprite.y = this.y;
            this.pAzulSprite.sx = this.sx;
            this.pAzulSprite.sy = this.sy;
            this.pAzulSprite.angle = this.angle;

            this.pAzulSprite.Update();
        }

        public void Render()
        {
            this.pAzulSprite.Render();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public Name name;
        public Image pImage;
        private Azul.Sprite pAzulSprite;
    }
}

// --- End of File ---

