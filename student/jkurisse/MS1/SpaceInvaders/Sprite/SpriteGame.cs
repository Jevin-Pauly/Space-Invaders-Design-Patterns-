//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class SpriteGame : SpriteBase
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
            FlyingBird,
            Runner,
            Peashooter,
            Skeleton,

            Null_Object,
            Compare,


            Octopus,
            Crab,
            Squid,

            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------

        public SpriteGame()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            this.name = Name.Uninitialized;
            this.pImage = null;

            // LTN - SpriteGame
            this.poColor = new Azul.Color();
            Debug.Assert(this.poColor != null);

            // LTN - SpriteGame
            this.poAzulSprite = new Azul.Sprite();
            Debug.Assert(this.poAzulSprite != null);

            // Temp instead of dynamically calling each time
            // LTN - SpriteGame
            this.poRect = new Azul.Rect();
            Debug.Assert(this.poRect != null);

        }


        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(Name name, Image pImage, float x, float y, float w, float h)
        {
            Debug.Assert(pImage != null);
            //Debug.Assert(pScreenRect != null);
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(this.poColor != null);

            this.pImage = pImage;
            this.name = name;
            this.poRect.Set(x, y, w, h);

            this.poColor.Set(1.0f, 1.0f, 1.0f, 1.0f);
            this.poAzulSprite.Swap(pImage.pTexture.poAzulTexture, pImage.poRect, poRect, poColor);
            this.poAzulSprite.Update();

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }
        private void privClear()
        {
            Debug.Assert(this.poColor != null);
            Debug.Assert(this.poAzulSprite != null);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            this.name = Name.Uninitialized;
            this.pImage = null;

            this.poColor.Set(1.0f, 1.0f, 1.0f, 1.0f);

            Image pImage = ImageMan.Find(Image.Name.HotPink);
            Debug.Assert(pImage != null);

            this.poRect.Set(0.0f, 0.0f, 1.0f, 1.0f);
            this.poAzulSprite.Swap(pImage.pTexture.poAzulTexture, pImage.poRect, poRect, poColor);
            this.poAzulSprite.Update();
        }



        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            Debug.Assert(this.poColor != null);
            Debug.Assert(this.poAzulSprite != null);
            this.poColor.Set(_pColor);
            this.poAzulSprite.SwapColor(_pColor);
        }
        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poColor != null);
            Debug.Assert(this.poAzulSprite != null);
            this.poColor.Set(red, green, blue, alpha);
            this.poAzulSprite.SwapColor(this.poColor);
        }
        public void SwapImage(Image pNewImage)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(pNewImage != null);
            this.pImage = pNewImage;

            this.poAzulSprite.SwapTexture(this.pImage.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImage.GetAzulRect());


        }

        public Azul.Rect GetRect()
        {
            Debug.Assert(this.poRect != null);
            return this.poRect;
        }

        //------------------------------------
        // Override
        //------------------------------------


        public override void Draw()
        {
            this.poAzulSprite.Render();
        }

        public override void Render()
        {
            this.poAzulSprite.Render();
        }

        public override void Update()
        {
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }

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
            Debug.WriteLine("             Image: {0} ({1})", this.pImage.name, this.pImage.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.poAzulSprite.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);
        
            // Let the base print its contribution
            this.baseDump();
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
        public Azul.Color poColor;
        private Azul.Sprite poAzulSprite;
        private Azul.Rect poRect;
    }
}

// --- End of File ---

