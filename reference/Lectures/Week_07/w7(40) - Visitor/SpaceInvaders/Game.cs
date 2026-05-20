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
            this.SetWindowName("W7");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.84f, 0.84f, 0.8f, 1.0f);
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
            SpriteGameProxyMan.Create();
            GameObjectNodeMan.Create(); 
            ColPairMan.Create();

            //-------------------------------------------------------
            // Load the Textures
            //-------------------------------------------------------

            TextureMan.Add(Texture.Name.Birds, "Birds.t.azul");
            TextureMan.Add(Texture.Name.PacMan, "PacMan.t.azul");

            //-------------------------------------------------------
            // Create Images
            //-------------------------------------------------------

            // --- Birds ---

            ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);
            ImageMan.Add(Image.Name.BlueBird, Texture.Name.Birds, 301, 49, 33, 33);


            // --- Pacman ---

            ImageMan.Add(Image.Name.RedGhost, Texture.Name.PacMan, 616, 148, 33, 33);
            ImageMan.Add(Image.Name.PinkGhost, Texture.Name.PacMan, 663, 148, 33, 33);
            ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);
            ImageMan.Add(Image.Name.OrangeGhost, Texture.Name.PacMan, 757, 148, 33, 33);
            ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------

            // --- BoxSprites ---
            //SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            //SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            // --- Birds ---

            SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 50, 500, 70,70);
            SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 80,80);
            SpriteGameMan.Add(SpriteGame.Name.GreenBird, Image.Name.GreenBird, 400, 200, 100,100);
            SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 600, 300, 100,100);
            SpriteGameMan.Add(SpriteGame.Name.BlueBird, Image.Name.BlueBird, 50, 50, 50, 50);

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


            //---------------------------------------------------------------------------------------------------------
            // Create Missile
            //---------------------------------------------------------------------------------------------------------

                MissileGroup pMissileGroup = new MissileGroup();
                pMissileGroup.ActivateSprite(pSB_Birds);
                pMissileGroup.ActivateCollisionSprite(pSB_Birds);

                Missile pMissile = new Missile(SpriteGame.Name.BlueBird, 405, 100);
                pMissile.ActivateSprite(pSB_Birds);
                pMissile.ActivateCollisionSprite(pSB_Birds);

                pMissileGroup.Add(pMissile);

                GameObjectNodeMan.Attach(pMissileGroup);

                Debug.WriteLine("-------------------");

            //  pMissileGroup.Print();


            //---------------------------------------------------------------------------------------------------------
            // Create Birds
            //---------------------------------------------------------------------------------------------------------

            // create the factory 
            BirdFactory BF = new BirdFactory(SpriteBatch.Name.AngryBirds);

            BirdGrid pGrid = (BirdGrid)BF.Create(GameObject.Name.BirdGrid);

            // Column A
            BirdColumn pColA = (BirdColumn)BF.Create(GameObject.Name.BirdColumn);
            pGrid.Add(pColA);

            pColA.Add(BF.Create(GameObject.Name.RedBird,    350.0f + 50.0f, 520.0f));
            pColA.Add(BF.Create(GameObject.Name.YellowBird, 350.0f + 50.0f, 410.0f));
            pColA.Add(BF.Create(GameObject.Name.GreenBird,  350.0f + 50.0f, 300.0f));



            Debug.WriteLine("\n");
            Debug.WriteLine("Forward Iterator...\n");
            IteratorForwardComposite pIt = new IteratorForwardComposite(pGrid);

            for(pIt.First();!pIt.IsDone(); pIt.Next())
            {
                Component pNode = pIt.Curr();
                pNode.Dump();
            }

            GameObjectNodeMan.Attach(pGrid);


            //Debug.WriteLine("\n");
            //Debug.WriteLine("Forward Iterator...\n");
            //IteratorForwardComposite pIt = new IteratorForwardComposite(pGrid);

            //for(pIt.First();!pIt.IsDone(); pIt.Next())
            //{
            //    Component pNode = pIt.Curr();
            //    pNode.Dump();
            //}

            //Debug.WriteLine("\n");
            //Debug.WriteLine("Reverse Iterator...\n");
            ////IteratorReverseComposite pItRev = new IteratorReverseComposite(pGrid);

            //for (pItRev.First(); !pItRev.IsDone(); pItRev.Next())
            //{
            //    Component pNode = pItRev.Curr();
            //   pNode.Dump();
            //}

            GameObjectNodeMan.Dump();
            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPairMan.Add(ColPair.Name.Bird_Missile, pMissileGroup, pGrid);
            ColPairMan.Dump();

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

            // walk through all objects and push to proxy
            GameObjectNodeMan.Update();

            // Do the collision checks
            Debug.WriteLine("\n------------------------------------");
            ColPairMan.Process();

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
            ColPairMan.Destroy();
            GameObjectNodeMan.Destroy();
            SpriteGameProxyMan.Destroy();
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
