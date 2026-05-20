//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class SpaceInvaders : Azul.Game
    {
        float flyingbirdspeed = 3.0f;
        float runnerSpeed = 3.0f;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Sprint2 - sprites");
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

            ImageMan.Create(0, 1);
            TextureMan.Create(0, 1);
            SpriteMan.Create(0, 1);

            //-----------------------------------
            // Load the Textures
            //-----------------------------------

            TextureMan.Add(Texture.Name.HotPink,    "HotPink.t.azul");
            TextureMan.Add(Texture.Name.Peashooter, "PeaShooter2.t.azul");
            TextureMan.Add(Texture.Name.Skeleton,   "Skeleton2.t.azul");
            TextureMan.Add(Texture.Name.FlyingBird, "Flying2.t.azul");
            TextureMan.Add(Texture.Name.Runner,     "Running2.t.azul");

            //-----------------------------------
            // Create Images
            //-----------------------------------

            //Peashooter
            ImageMan.Add(Image.Name.Peashooter,  Texture.Name.Peashooter,   0, 0, 1518, 1550);
            //Skeleton
            ImageMan.Add(Image.Name.Skeleton,    Texture.Name.Skeleton,     0, 0, 600, 500);
            //Flying Bird
            ImageMan.Add(Image.Name.FlyingBird,  Texture.Name.FlyingBird,   200, 190, 175, 170);
            //Runner
            ImageMan.Add(Image.Name.Runner,      Texture.Name.Runner,       0, 0, 250, 260);

            // --- Hot Pink ---

            //Image pHotPink = ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);
            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);
            //--------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            SpriteMan.Add(Sprite.Name.Peashooter,   ImageMan.Find(Image.Name.Peashooter),   150, 400, 200, 200);
            SpriteMan.Add(Sprite.Name.Skeleton,     ImageMan.Find(Image.Name.Skeleton),     600, 400, 300, 200);
            SpriteMan.Add(Sprite.Name.FlyingBird,   ImageMan.Find(Image.Name.FlyingBird),   400, 500, 180, 180);
            SpriteMan.Add(Sprite.Name.Runner,       ImageMan.Find(Image.Name.Runner),       300, 150, 200, 200);

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
            // Flying Bird
            //--------------------------------------------------------
            Sprite FlyingBird = SpriteMan.Find(Sprite.Name.FlyingBird);
            Debug.Assert(FlyingBird != null);
            if (FlyingBird.y > this.GetScreenHeight() - 75.0f || FlyingBird.y < 75.0f)
            {
                flyingbirdspeed *= -1.0f;
            }
            FlyingBird.y += flyingbirdspeed;
            FlyingBird.Update();


            //--------------------------------------------------------
            // Runner
            //--------------------------------------------------------
            Sprite pRunner = SpriteMan.Find(Sprite.Name.Runner);
            Debug.Assert(pRunner != null);
            if (pRunner.x > this.GetScreenWidth() - 75.0f || pRunner.x < 75.0f)
            {
                runnerSpeed *= -1.0f;
            }
            pRunner.x += runnerSpeed;
            pRunner.Update();

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
            SpriteMan.Find(Sprite.Name.Peashooter).Render();
            SpriteMan.Find(Sprite.Name.Skeleton).Render();
            SpriteMan.Find(Sprite.Name.FlyingBird).Render();
            SpriteMan.Find(Sprite.Name.Runner).Render();
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
