//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using Azul;
using System;
using System.Diagnostics;
using System.Windows;

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
            this.SetWindowName("Sprint3 - sprites");
            this.SetWidthHeight(672, 768);
            this.SetClearColor(0, 0, 0, 1.0f);
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
            SpriteGameMan.Create(0, 1);
            SpriteBatchMan.Create(0, 1);
            SpriteGameProxyMan.Create(55, 1);
            GameObjectNodeMan.Create();
            TimerEventMan.Create();
            //SpriteBoxMan.Create(0, 1);

            //-----------------------------------
            // Load the Textures
            //-----------------------------------

            TextureMan.Add(Texture.Name.HotPink,    "HotPink.t.azul");
            TextureMan.Add(Texture.Name.Invaders, "SpaceInvaders_ROM.t.azul");

            //-----------------------------------
            // Create Images
            //-----------------------------------


            // --- Invaders ---
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.Invaders, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.Invaders, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidA, Texture.Name.Invaders, 61, 3, 8, 8);

            ImageMan.Add(Image.Name.OctopusB, Texture.Name.Invaders, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.Invaders, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.Invaders, 72, 3, 8, 8);

            // --- Hot Pink ---

            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);
            //--------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            // --- Invaders ---

            SpriteGameMan.Add(SpriteGame.Name.Octopus, ImageMan.Find(Image.Name.OctopusA), 80, 400, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, ImageMan.Find(Image.Name.CrabA), 80, 500, 32, 25);
            SpriteGameMan.Add(SpriteGame.Name.Squid, ImageMan.Find(Image.Name.SquidA), 80, 600, 24, 25);


            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Invaders = SpriteBatchMan.Add(SpriteBatch.Name.Invaders, 1);

            AlienFactory AF = new AlienFactory(SpriteBatch.Name.Invaders);


            //-------------------------------------------------------
            // Attach to SpriteNode
            //-------------------------------------------------------

            for (int i = 0; i < 11; i++)
            {
                float X = 80.0f + (50.0f * i);
                AF.Create(AlienBase.Type.Squid, X, 600.0f);
            }

            for (int j = 0; j < 2; j++)
            {
                float Y = 400.0f + (50.0f * j);
                for (int i = 0; i < 11; i++)
                {
                    float X = 80.0f + (50.0f * i);
                    AF.Create(AlienBase.Type.Octopus, X, Y);
                    // Y + 100 because too layers up
                    AF.Create(AlienBase.Type.Crab, X, Y + 100.0f);
                }
            }


            //Timer and Sprite Animation

            SpriteAnimationCommand pAnimationCrab = new SpriteAnimationCommand(SpriteGame.Name.Crab);
            pAnimationCrab.Attach(Image.Name.CrabB);
            pAnimationCrab.Attach(Image.Name.CrabA);

            SpriteAnimationCommand pAnimationOctopus = new SpriteAnimationCommand(SpriteGame.Name.Octopus);
            pAnimationOctopus.Attach(Image.Name.OctopusB);
            pAnimationOctopus.Attach(Image.Name.OctopusA);

            SpriteAnimationCommand pAnimationSquid = new SpriteAnimationCommand(SpriteGame.Name.Squid);
            pAnimationSquid.Attach(Image.Name.SquidB);
            pAnimationSquid.Attach(Image.Name.SquidA);

            TimerEventMan.Add(TimerEvent.Name.Animation, pAnimationCrab, 0.5f);
            TimerEventMan.Add(TimerEvent.Name.Animation, pAnimationOctopus, 1.0f);
            TimerEventMan.Add(TimerEvent.Name.Animation, pAnimationSquid, 0.25f);

            SampleCommand pCmd1 = new SampleCommand(" -- LATE COMMAND  -- ");
            SampleCommand pCmd2 = new SampleCommand(" -- LATE COMMAND  -- ");
            SampleCommand pCmd3 = new SampleCommand(" -- LATE COMMAND  -- ");
            SampleCommand pCmd4 = new SampleCommand(" -- LATE COMMAND  -- ");
            SampleCommand pCmd5 = new SampleCommand(" -- LATE COMMAND  -- ");

            TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd1, 500.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd2, 510.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd3, 520.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd4, 530.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd5, 540.0f);

            TimerEventMan.Dump();

            this.ResetTime();

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

            TimerEventMan.Update(this.GetTime());
            GameObjectNodeMan.Update();
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // Draw the Batches
            SpriteBatchMan.Draw();

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
