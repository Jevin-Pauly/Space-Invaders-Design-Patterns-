//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class SpaceInvaders : Azul.Game
    {
        Sprite pRedBird;
        Sprite pWhiteBird;
        Sprite pYellowBird;
        Sprite pGreenBird;

        float redSpeed = 2.0f;
        float yellowSpeedX = 2.0f;
        float yellowSpeedY = 2.0f;
        float greenBirdSpeedX = 2.0f;
        float greenBirdSpeedY = 2.0f;
        float whiteBirdSpeed = 0.02f;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("w3(14) Game - Singleton Image");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //-----------------------------------
            // Load Managers
            //-----------------------------------

            ImageMan.Create(5, 1);

            //-----------------------------------
            // Load the Textures
            //-----------------------------------

            TextureMan pTextureMan = new TextureMan(new DLinkMan(), new DLinkMan(), 0, 1);
            Debug.Assert(pTextureMan != null);

            Texture pBirdsTexture = pTextureMan.Add(Texture.Name.Birds, "Birds.t.azul");
            Debug.Assert(pBirdsTexture != null);

            Texture pHotPinkTexture = pTextureMan.Add(Texture.Name.HotPink, "HotPink.t.azul");
            Debug.Assert(pHotPinkTexture != null);

            //-----------------------------------
            // Create Images
            //-----------------------------------

            // --- Birds ---

            Image pImageRedBird = ImageMan.Add(Image.Name.RedBird, pBirdsTexture, new Azul.Rect(47, 41, 48, 46));
            Image pImageYellowBird = ImageMan.Add(Image.Name.YellowBird, pBirdsTexture, new Azul.Rect(124, 34, 60, 56));
            Image pImageGreenBird = ImageMan.Add(Image.Name.GreenBird, pBirdsTexture, new Azul.Rect(246, 135, 99, 72));
            Image pImageWhiteBird = ImageMan.Add(Image.Name.WhiteBird, pBirdsTexture, new Azul.Rect(139, 131, 84, 97));

            // --- Hot Pink ---

            Image pHotPink = ImageMan.Add(Image.Name.HotPink, pHotPinkTexture, new Azul.Rect(0, 0, 128, 128));

            //--------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            SpriteMan pSpriteMan = new SpriteMan(new DLinkMan(), new DLinkMan(), 0, 1);
            Debug.Assert(pSpriteMan != null);

            pRedBird = pSpriteMan.Add(Sprite.Name.RedBird, pImageRedBird, new Azul.Rect(50, 500, 50, 50));
            Debug.Assert(pRedBird != null);

            pYellowBird = pSpriteMan.Add(Sprite.Name.YellowBird, pImageYellowBird, new Azul.Rect(300, 400, 100, 100));
            Debug.Assert(pYellowBird != null);

            pGreenBird = pSpriteMan.Add(Sprite.Name.GreenBird, pImageGreenBird, new Azul.Rect(400, 200, 75, 75));
            Debug.Assert(pGreenBird != null);

            pWhiteBird = pSpriteMan.Add(Sprite.Name.WhiteBird, pImageWhiteBird, new Azul.Rect(600, 200, 50, 50));
            Debug.Assert(pWhiteBird != null);

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Add your update below this line: ----------------------------


            //--------------------------------------------------------
            // Red Bird
            //--------------------------------------------------------
            if (pRedBird.x > this.GetScreenWidth() || pRedBird.x < 0.0f)
            {
                redSpeed *= -1.0f;
            }
            pRedBird.x += redSpeed;
            pRedBird.Update();

            //--------------------------------------------------------
            // Yellow Bird
            //--------------------------------------------------------
            if (pYellowBird.x > this.GetScreenWidth() || pYellowBird.x < 0.0f)
            {
                yellowSpeedX *= -1.0f;
            }
            if (pYellowBird.y > this.GetScreenHeight() || pYellowBird.y < 0.0f)
            {
                yellowSpeedY *= -1;
            }
            pYellowBird.x += yellowSpeedX;
            pYellowBird.y += yellowSpeedY;

            pYellowBird.Update();

            //--------------------------------------------------------
            // Green Bird
            //--------------------------------------------------------
            if (pGreenBird.x > this.GetScreenWidth() || pGreenBird.x < 0.0f)
            {
                greenBirdSpeedX *= -1.0f;
            }
            if (pGreenBird.y > this.GetScreenHeight() || pGreenBird.y < 0.0f)
            {
                greenBirdSpeedY *= -1.0f;
            }
            pGreenBird.x += greenBirdSpeedX;
            pGreenBird.y += greenBirdSpeedY;
            pGreenBird.angle += 0.05f;

            pGreenBird.Update();

            //--------------------------------------------------------
            // White Bird
            //--------------------------------------------------------
            if (pWhiteBird.sx > 5.0f || pWhiteBird.sy < 1.0f)
            {
                whiteBirdSpeed *= -1.0f;
            }
            pWhiteBird.sx += whiteBirdSpeed;
            pWhiteBird.sy += whiteBirdSpeed;

            pWhiteBird.Update();



        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // draw all objects
            pGreenBird.Render();
            pRedBird.Render();
            pWhiteBird.Render();
            pYellowBird.Render();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }


        public override void DisplayHeader()
        {
            Console.Write(this.Header());
        }

        public override void DisplayFooter()
        {
            Console.Write(this.Footer());
        }

    }
}

// --- End of File ---
