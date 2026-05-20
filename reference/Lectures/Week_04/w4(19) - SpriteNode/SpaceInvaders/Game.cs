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
            this.SetWindowName("W4");
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

            TextureMan.Create(0, 1);
            ImageMan.Create(0, 1);
            SpriteMan.Create(0, 1);
            SpriteNodeMan.Create(0,1);

            //-----------------------------------
            // Load the Textures
            //-----------------------------------

            TextureMan.Add(Texture.Name.HotPink, "HotPink.t.azul");
            TextureMan.Add(Texture.Name.Birds, "Birds.t.azul");
            TextureMan.Add(Texture.Name.PacMan, "PacMan.t.azul");

            //-----------------------------------
            // Create Images
            //-----------------------------------

            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);

            // --- Birds ---

            Image pImageRedBird = ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            Image pImageYellowBird = ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            Image pImageGreenBird = ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            Image pImageWhiteBird = ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);

            // --- Pacman ---

            ImageMan.Add(Image.Name.RedGhost, Texture.Name.PacMan, 616, 148, 33, 33);
            ImageMan.Add(Image.Name.PinkGhost, Texture.Name.PacMan, 663, 148, 33, 33);
            ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);
            ImageMan.Add(Image.Name.OrangeGhost, Texture.Name.PacMan, 757, 148, 33, 33);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------

            // --- Birds ---

            SpriteMan.Add(Sprite.Name.RedBird, Image.Name.RedBird, 700, 500, 50, 50);
            SpriteMan.Add(Sprite.Name.YellowBird, Image.Name.YellowBird, 300, 400, 100, 100);
            SpriteMan.Add(Sprite.Name.GreenBird, Image.Name.GreenBird, 500, 200, 75, 75);
            SpriteMan.Add(Sprite.Name.WhiteBird, Image.Name.WhiteBird, 100, 300, 50, 50);

            // --- Pacman ---

            SpriteMan.Add(Sprite.Name.RedGhost, Image.Name.RedGhost, 100, 300, 100, 100);
            SpriteMan.Add(Sprite.Name.PinkGhost, Image.Name.PinkGhost, 300, 300, 100, 100);
            SpriteMan.Add(Sprite.Name.BlueGhost, Image.Name.BlueGhost, 500, 300, 100, 100);
            SpriteMan.Add(Sprite.Name.OrangeGhost, Image.Name.OrangeGhost, 700, 300, 100, 100);

            //-------------------------------------------------------
            // Attach to SpriteNode
            //-------------------------------------------------------

            SpriteNodeMan.Attach(Sprite.Name.RedGhost);
            SpriteNodeMan.Attach(Sprite.Name.PinkGhost);
            SpriteNodeMan.Attach(Sprite.Name.BlueGhost);
            SpriteNodeMan.Attach(Sprite.Name.OrangeGhost);

            SpriteNodeMan.Attach(Sprite.Name.RedBird);
            SpriteNodeMan.Attach(Sprite.Name.YellowBird);
            SpriteNodeMan.Attach(Sprite.Name.GreenBird);
            SpriteNodeMan.Attach(Sprite.Name.WhiteBird);

            // TextureMan.Dump();
            // ImageMan.Dump();
            // SpriteMan.Dump();
            SpriteNodeMan.Dump();
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        float FlySpeed = 2.0f;
        public override void Update()
        {
            Sprite pRedGhost = SpriteMan.Find(Sprite.Name.RedGhost);
            Sprite pPinkGhost = SpriteMan.Find(Sprite.Name.PinkGhost);
            Sprite pBlueGhost = SpriteMan.Find(Sprite.Name.BlueGhost);
            Sprite pOrangeGhost = SpriteMan.Find(Sprite.Name.OrangeGhost);

            Sprite pRedBird = SpriteMan.Find(Sprite.Name.RedBird);
            Sprite pYellowBird = SpriteMan.Find(Sprite.Name.YellowBird);
            Sprite pGreenBird = SpriteMan.Find(Sprite.Name.GreenBird);
            Sprite pWhiteBird = SpriteMan.Find(Sprite.Name.WhiteBird);

            if (pRedGhost.y > (this.GetScreenHeight()) || pRedGhost.y < (0.0f))
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

            }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            //Sprite pRedGhost = SpriteMan.Find(Sprite.Name.RedGhost);
            //Sprite pPinkGhost = SpriteMan.Find(Sprite.Name.PinkGhost);
            //Sprite pBlueGhost = SpriteMan.Find(Sprite.Name.BlueGhost);
            //Sprite pOrangeGhost = SpriteMan.Find(Sprite.Name.OrangeGhost);

            //Sprite pRedBird = SpriteMan.Find(Sprite.Name.RedBird);
            //Sprite pYellowBird = SpriteMan.Find(Sprite.Name.YellowBird);
            //Sprite pGreenBird = SpriteMan.Find(Sprite.Name.GreenBird);
            //Sprite pWhiteBird = SpriteMan.Find(Sprite.Name.WhiteBird);

            //pRedGhost.Render();
            //pPinkGhost.Render();
            //pBlueGhost.Render();
            //pOrangeGhost.Render();

            //pRedBird.Render();
            //pYellowBird.Render();
            //pGreenBird.Render();
            //pWhiteBird.Render();

            SpriteNodeMan.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            SpriteNodeMan.Destroy();
            SpriteMan.Destroy();
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
