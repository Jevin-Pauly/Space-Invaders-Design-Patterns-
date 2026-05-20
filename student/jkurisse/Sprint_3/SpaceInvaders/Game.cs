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
        float flyingbirdspeed = 3.0f;
        float runnerSpeed = 3.0f;
        float FlySpeed = 2;
        int count = 0;

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
            SpriteGameMan.Create(0, 1);
            SpriteBatchMan.Create(0, 1);
            SpriteBoxMan.Create(0, 1);

            //-----------------------------------
            // Load the Textures
            //-----------------------------------

            TextureMan.Add(Texture.Name.HotPink,    "HotPink.t.azul");
            TextureMan.Add(Texture.Name.Birds,      "Birds.t.azul");
            TextureMan.Add(Texture.Name.PacMan,     "PacMan.t.azul");

            TextureMan.Add(Texture.Name.Peashooter, "PeaShooter2.t.azul");
            TextureMan.Add(Texture.Name.Skeleton,   "Skeleton2.t.azul");
            TextureMan.Add(Texture.Name.FlyingBird, "Flying2.t.azul");
            TextureMan.Add(Texture.Name.Runner,     "Running2.t.azul");

            //-----------------------------------
            // Create Images
            //-----------------------------------

            // --- Birds ---

            ImageMan.Add(Image.Name.RedBird,        Texture.Name.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.Name.YellowBird,     Texture.Name.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.Name.GreenBird,      Texture.Name.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.Name.WhiteBird,      Texture.Name.Birds, 139, 131, 84, 97);

            // --- Pacman ---

            ImageMan.Add(Image.Name.RedGhost,       Texture.Name.PacMan, 616, 148, 33, 33);
            ImageMan.Add(Image.Name.PinkGhost,      Texture.Name.PacMan, 663, 148, 33, 33);
            ImageMan.Add(Image.Name.BlueGhost,      Texture.Name.PacMan, 710, 148, 33, 33);
            ImageMan.Add(Image.Name.OrangeGhost,    Texture.Name.PacMan, 757, 148, 33, 33);

            //Peashooter
            ImageMan.Add(Image.Name.Peashooter,     Texture.Name.Peashooter, 0, 0, 1518, 1550);
            //Skeleton
            ImageMan.Add(Image.Name.Skeleton,       Texture.Name.Skeleton, 0, 0, 600, 500);
            //Flying Bird
            ImageMan.Add(Image.Name.FlyingBird,     Texture.Name.FlyingBird, 200, 190, 175, 170);
            //Runner
            ImageMan.Add(Image.Name.Runner,         Texture.Name.Runner, 0, 0, 250, 260);



            // --- Hot Pink ---

            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);
            //--------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            // --- BoxSprites ---

            SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, 1.0f, 1.0f, 1.0f, 1.0f);
            SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);


            // --- Birds ---

            SpriteGameMan.Add(SpriteGame.Name.RedBird,      ImageMan.Find(Image.Name.RedBird), 700, 500, 50, 50);
            SpriteGameMan.Add(SpriteGame.Name.YellowBird,   ImageMan.Find(Image.Name.YellowBird), 300, 400, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.GreenBird,    ImageMan.Find(Image.Name.GreenBird), 500, 200, 75, 75);
            SpriteGameMan.Add(SpriteGame.Name.WhiteBird,    ImageMan.Find(Image.Name.WhiteBird), 100, 300, 50, 50);

            // --- Pacman ---

            SpriteGameMan.Add(SpriteGame.Name.RedGhost,     ImageMan.Find(Image.Name.RedGhost), 100, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.PinkGhost,    ImageMan.Find(Image.Name.PinkGhost), 300, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.BlueGhost,    ImageMan.Find(Image.Name.BlueGhost), 500, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.OrangeGhost,  ImageMan.Find(Image.Name.OrangeGhost), 700, 300, 100, 100);

            // --- Misc ---
            SpriteGameMan.Add(SpriteGame.Name.Peashooter,   ImageMan.Find(Image.Name.Peashooter), 150, 400, 200, 200);
            SpriteGameMan.Add(SpriteGame.Name.Skeleton,     ImageMan.Find(Image.Name.Skeleton), 600, 400, 300, 200);
            SpriteGameMan.Add(SpriteGame.Name.FlyingBird,   ImageMan.Find(Image.Name.FlyingBird), 400, 500, 180, 180);
            SpriteGameMan.Add(SpriteGame.Name.Runner,       ImageMan.Find(Image.Name.Runner), 300, 150, 200, 200);



            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_PacMan  = SpriteBatchMan.Add(SpriteBatch.Name.PacMan, 200);
            SpriteBatch pSB_Birds   = SpriteBatchMan.Add(SpriteBatch.Name.AngryBirds, 50);
            SpriteBatch pSB_Box     = SpriteBatchMan.Add(SpriteBatch.Name.Boxes, 100);
            SpriteBatch pSB_Misc    = SpriteBatchMan.Add(SpriteBatch.Name.Misc,  10);

            //-------------------------------------------------------
            // Attach to SpriteNode
            //-------------------------------------------------------

            pSB_PacMan.Attach(SpriteGame.Name.RedGhost);
            pSB_PacMan.Attach(SpriteGame.Name.PinkGhost);
            pSB_PacMan.Attach(SpriteGame.Name.BlueGhost);
            pSB_PacMan.Attach(SpriteGame.Name.OrangeGhost);

            pSB_Birds.Attach(SpriteGame.Name.RedBird);
            pSB_Birds.Attach(SpriteGame.Name.YellowBird);
            pSB_Birds.Attach(SpriteGame.Name.GreenBird);
            pSB_Birds.Attach(SpriteGame.Name.WhiteBird);

            pSB_Misc.Attach(SpriteGame.Name.FlyingBird);
            pSB_Misc.Attach(SpriteGame.Name.Skeleton);
            pSB_Misc.Attach(SpriteGame.Name.Peashooter);
            pSB_Misc.Attach(SpriteGame.Name.Runner);


            pSB_Box.Attach(SpriteBox.Name.Box1);
            pSB_Box.Attach(SpriteBox.Name.Box2);

            // TextureMan.Dump();
            // ImageMan.Dump();
            // SpriteMan.Dump();
            // SpriteBatchMan.Dump();
            // SpriteBoxMan.Dump();


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
            // Boxes & PacMan priority swap
            //--------------------------------------------------------
            count++;
            SpriteBox pSpriteBox1 = SpriteBoxMan.Find(SpriteBox.Name.Box1);
            SpriteBatch pSB_PacMan = SpriteBatchMan.Find(SpriteBatch.Name.PacMan);
            if (count == 100)
            {
                pSpriteBox1.SwapColor(1.0f, 0.0f, 0.0f, 1.0f);
                SpriteBatchMan.UpdatePriority(SpriteBatch.Name.PacMan, 50);
                SpriteBatchMan.UpdatePriority(SpriteBatch.Name.Misc, 500);

            }
            else if (count == 200)
            {
                pSpriteBox1.SwapColor(0.0f, 1.0f, 0.0f, 1.0f);
            }
            else if (count == 300)
            {
                SpriteBatchMan.UpdatePriority(SpriteBatch.Name.PacMan, 200);
                SpriteBatchMan.UpdatePriority(SpriteBatch.Name.Misc, 50);
                pSpriteBox1.SwapColor(0.0f, 0.0f, 1.0f, 1.0f);
                count = 0;
            }
            pSpriteBox1.Update();

            SpriteBox pSpriteBox2 = SpriteBoxMan.Find(SpriteBox.Name.Box2);
            pSpriteBox2.Update();


            SpriteGame pRedGhost    = SpriteGameMan.Find(SpriteGame.Name.RedGhost);
            SpriteGame pPinkGhost   = SpriteGameMan.Find(SpriteGame.Name.PinkGhost);
            SpriteGame pBlueGhost   = SpriteGameMan.Find(SpriteGame.Name.BlueGhost);
            SpriteGame pOrangeGhost = SpriteGameMan.Find(SpriteGame.Name.OrangeGhost);

            SpriteGame pRedBird     = SpriteGameMan.Find(SpriteGame.Name.RedBird);
            SpriteGame pYellowBird  = SpriteGameMan.Find(SpriteGame.Name.YellowBird);
            SpriteGame pGreenBird   = SpriteGameMan.Find(SpriteGame.Name.GreenBird);
            SpriteGame pWhiteBird   = SpriteGameMan.Find(SpriteGame.Name.WhiteBird);

            if (pRedGhost.y > (this.GetScreenHeight() - 50) || pRedGhost.y < (0.0f) + 50)
            {
                FlySpeed *= -1.0f;
            }
            pRedGhost.y += FlySpeed;
            pPinkGhost.y += FlySpeed;
            pBlueGhost.y += FlySpeed;
            pOrangeGhost.y += FlySpeed;

            pRedGhost.Update();
            pPinkGhost.Update();
            pBlueGhost.Update();
            pOrangeGhost.Update();

            pRedBird.Update();
            pYellowBird.Update();
            pGreenBird.Update();
            pWhiteBird.Update();


            //--------------------------------------------------------
            // Flying Bird
            //--------------------------------------------------------
            SpriteGame FlyingBird = SpriteGameMan.Find(SpriteGame.Name.FlyingBird);
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
            SpriteGame pRunner = SpriteGameMan.Find(SpriteGame.Name.Runner);
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
            //SpriteGameMan.Find(SpriteGame.Name.Peashooter).Render();
            //SpriteGameMan.Find(SpriteGame.Name.Skeleton).Render();
            //SpriteGameMan.Find(SpriteGame.Name.FlyingBird).Render();
            //SpriteGameMan.Find(SpriteGame.Name.Runner).Render();
            SpriteBatchMan.Draw();

        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            //SpriteBoxMan.Destroy();
            //SpriteBatchMan.Destroy();
            //SpriteGameMan.Destroy();
            //ImageMan.Destroy();
            //TextureMan.Destroy();

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
