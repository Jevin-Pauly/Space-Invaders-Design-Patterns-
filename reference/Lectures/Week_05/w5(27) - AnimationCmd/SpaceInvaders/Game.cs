//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class SpaceInvaders : Azul.Game
    {
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("W5 Timer");
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
            //-------------------------------------------------------
            // Load Managers
            //-------------------------------------------------------

            TextureMan.Create();
            ImageMan.Create();
            SpriteGameMan.Create();
            SpriteBatchMan.Create();
            SpriteBoxMan.Create();
            TimerEventMan.Create();

            //-------------------------------------------------------
            // Load the Textures
            //-------------------------------------------------------


            TextureMan.Add(Texture.Name.HotPink, "HotPink.t.azul");
            TextureMan.Add(Texture.Name.Birds, "Birds.t.azul");
            TextureMan.Add(Texture.Name.PacMan, "PacMan.t.azul");

            //-------------------------------------------------------
            // Create Images
            //-------------------------------------------------------

            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);

            // --- Birds ---

            ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);

            // --- Pacman ---

            ImageMan.Add(Image.Name.RedGhost, Texture.Name.PacMan, 616, 148, 33, 33);
            ImageMan.Add(Image.Name.PinkGhost, Texture.Name.PacMan, 663, 148, 33, 33);
            ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);
            ImageMan.Add(Image.Name.OrangeGhost, Texture.Name.PacMan, 757, 148, 33, 33);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------

            // --- BoxSprites ---
            SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            // --- Birds ---

            SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 700, 500, 50, 50);
            SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.GreenBird, Image.Name.GreenBird, 500, 200, 75, 75);
            SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 100, 300, 50, 50);

            // --- Pacman ---

            SpriteGameMan.Add(SpriteGame.Name.RedGhost, Image.Name.RedGhost, 100, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.PinkGhost, Image.Name.PinkGhost, 300, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.BlueGhost, Image.Name.BlueGhost, 500, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.OrangeGhost, Image.Name.OrangeGhost, 700, 300, 100, 100);

            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_PacMan = SpriteBatchMan.Add(SpriteBatch.Name.PacMan);
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.AngryBirds);

            //-------------------------------------------------------
            // Attach to SpriteBatch
            //-------------------------------------------------------

            pSB_PacMan.Attach(SpriteGame.Name.BlueGhost);

            //---------------------------------------------------------------------------------------------------------
            // Timer
            //---------------------------------------------------------------------------------------------------------

            // Create an animation sprite
            AnimationCmd pAnimCmd = new AnimationCmd(SpriteGame.Name.BlueGhost);

            // attach several images to cycle
            pAnimCmd.Attach(Image.Name.WhiteBird);
            pAnimCmd.Attach(Image.Name.PinkGhost);
            pAnimCmd.Attach(Image.Name.GreenBird);
            pAnimCmd.Attach(Image.Name.BlueGhost);

            // add AnimationSprite to timer
            TimerEventMan.Add(TimerEvent.Name.Animation, pAnimCmd, 0.5f);
            TimerEventMan.Dump();

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Fire off the timer events
            TimerEventMan.Update(this.GetTime());

            // Find the sprite and update it
            SpriteGame pSprite = SpriteGameMan.Find(SpriteGame.Name.PinkGhost);
            Debug.Assert(pSprite != null);

            pSprite.Update();
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SpriteBatchMan.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            TimerEventMan.Destroy();
            SpriteBoxMan.Destroy();
            SpriteBatchMan.Destroy();
            SpriteGameMan.Destroy();
            ImageMan.Destroy();
            TextureMan.Destroy();
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
