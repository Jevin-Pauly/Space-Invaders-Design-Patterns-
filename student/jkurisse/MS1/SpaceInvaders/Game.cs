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
            this.SetWindowName("Milestone 1");
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


            TextureMan.Create();
            ImageMan.Create();
            SpriteGameMan.Create();
            SpriteBatchMan.Create();
            SpriteBoxMan.Create();
            TimerEventMan.Create();
            SpriteGameProxyMan.Create(55, 1);
            GameObjectNodeMan.Create();

            //-----------------------------------
            // Load the Textures
            //-----------------------------------

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

            //--------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            // --- Invaders ---

            SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabA, 0, 0, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 0, 0, 24, 25);


            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Invaders = SpriteBatchMan.Add(SpriteBatch.Name.Invaders);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);

            // STN - Used to create all the Sprites and Boxes we need right at the start (None of them are perma removed so Factory is not used again)
            AlienFactory AF = new AlienFactory(SpriteBatch.Name.Invaders, SpriteBatch.Name.Boxes);

            AlienGrid pGrid = (AlienGrid)AF.Create(GameObject.Name.AlienGrid);
            GameObjectNodeMan.Attach((GameObject)pGrid);

            //Debug.WriteLine("colA {0}", pColA.GetHashCode());
            //-------------------------------------------------------
            // Attach to SpriteNode
            //-------------------------------------------------------

            for (int i = 0; i < 11; i++)
            {
                float X = 86.0f + (50.0f * i); ;
            
                AlienColumn pCol = (AlienColumn)AF.Create(GameObject.Name.AlienColumn);
                pGrid.Add(pCol);
            
                pCol.Add(AF.Create(GameObject.Name.Octopus, X, 400.0f));
                pCol.Add(AF.Create(GameObject.Name.Octopus, X, 400.0f + 50.0f));
            
                pCol.Add(AF.Create(GameObject.Name.Crab, X, 500.0f));
                pCol.Add(AF.Create(GameObject.Name.Crab, X, 500.0f + 50.0f));
            
                pCol.Add(AF.Create(GameObject.Name.Squid, X, 600.0f));
                
            }
            //IteratorComposite pIt = new IteratorComposite(pGrid);

            GameObjectNodeMan.Dump();

            //Timer and Sprite Animation and Movement command

            // LTN - Sits in TimerEvents
            MoveGridCommand moveGridCommand = new MoveGridCommand(pGrid);

            // LTN - Sits in TimerEvents
            SpriteAnimationCommand pAnimationCrab = new SpriteAnimationCommand(SpriteGame.Name.Crab);
            pAnimationCrab.Attach(Image.Name.CrabA);
            pAnimationCrab.Attach(Image.Name.CrabB);

            // LTN - Sits in TimerEvents
            SpriteAnimationCommand pAnimationOctopus = new SpriteAnimationCommand(SpriteGame.Name.Octopus);
            pAnimationOctopus.Attach(Image.Name.OctopusA);
            pAnimationOctopus.Attach(Image.Name.OctopusB);

            // LTN - Sits in TimerEvents
            SpriteAnimationCommand pAnimationSquid = new SpriteAnimationCommand(SpriteGame.Name.Squid);
            pAnimationSquid.Attach(Image.Name.SquidA);
            pAnimationSquid.Attach(Image.Name.SquidB);

            // LTN - Sits in TimerEvents (This one is not necessary, just created to have one timer event for the same deltaTime entities)
            SpriteAnimationManager animationManager = new SpriteAnimationManager(pAnimationSquid, pAnimationCrab, pAnimationOctopus, moveGridCommand);
            TimerEventMan.Add(TimerEvent.Name.Animation, animationManager, 0.5f);

            //TimerEventMan.Add(TimerEvent.Name.Animation, pAnimationCrab, 0.5f);
            //TimerEventMan.Add(TimerEvent.Name.Animation, pAnimationOctopus, 0.5f);
            //TimerEventMan.Add(TimerEvent.Name.Animation, pAnimationSquid, 0.5f);
            //TimerEventMan.Add(TimerEvent.Name.GridMovement, moveGridCommand, 0.5f);

            //SampleCommand pCmd1 = new SampleCommand(" -- LATE COMMAND  -- ");
            //SampleCommand pCmd2 = new SampleCommand(" -- LATE COMMAND  -- ");
            //SampleCommand pCmd3 = new SampleCommand(" -- LATE COMMAND  -- ");
            //SampleCommand pCmd4 = new SampleCommand(" -- LATE COMMAND  -- ");
            //SampleCommand pCmd5 = new SampleCommand(" -- LATE COMMAND  -- ");
            //
            //TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd1, 500.0f);
            //TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd2, 510.0f);
            //TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd3, 520.0f);
            //TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd4, 530.0f);
            //TimerEventMan.Add(TimerEvent.Name.Sample1, pCmd5, 540.0f);

            //TimerEventMan.Dump();
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

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_B))
            {
                SpriteBatch pBoxSprite = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                pBoxSprite.Enable();
            }
            
            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_U))
            {
                SpriteBatch pBoxSprite = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                pBoxSprite.Disable();
            }

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
