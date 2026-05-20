//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    public class SpaceInvaders : Azul.Game
    {

        IrrKlang.ISoundEngine sndEngine = null;

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
            this.SetClearColor(0.484f, 0.484f, 0.48f, 1.0f);
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
            GlyphMan.Create();
            FontMan.Create();

            //------------------------------------------------------
            // Sound Experiment
            //------------------------------------------------------

            // start up the engine
            sndEngine = new IrrKlang.ISoundEngine();

            //---------------------------------------------------------------------------------------------------------
            // Font Experiment
            //---------------------------------------------------------------------------------------------------------

            TextureMan.Add(Texture.Name.Consolas36pt, "consolas36pt.t.azul");
            GlyphMan.AddXml("Consolas36pt.xml", Glyph.Name.Consolas36pt, Texture.Name.Consolas36pt);


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

            SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 50, 500, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.GreenBird, Image.Name.GreenBird, 400, 200, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 600, 300, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.BlueBird, Image.Name.BlueBird, 50, 50, 50, 50);

            // --- Pacman ---

            SpriteGameMan.Add(SpriteGame.Name.RedGhost, Image.Name.RedGhost, 100, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.PinkGhost, Image.Name.PinkGhost, 300, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.BlueGhost, Image.Name.BlueGhost, 500, 300, 100, 100);
            SpriteGameMan.Add(SpriteGame.Name.OrangeGhost, Image.Name.OrangeGhost, 700, 300, 100, 100);

            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatch pSB_PacMan = SpriteBatchMan.Add(SpriteBatch.Name.PacMan);
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.AngryBirds);
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);



            //-------------------------------------------------------------------
            // Create Missile
            //-------------------------------------------------------------------

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
            // Create Walls
            //---------------------------------------------------------------------------------------------------------

            // Wall Root
            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Birds);
            pWallGroup.ActivateCollisionSprite(pSB_Box);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 700, 300, 50, 500);
            pWallRight.ActivateCollisionSprite(pSB_Box);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, 50, 300, 50, 500);
            pWallLeft.ActivateCollisionSprite(pSB_Box);

            // Add to the composite the children
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);

            GameObjectNodeMan.Attach(pWallGroup);

            //---------------------------------------------------------------------------------------------------------
            // Create Birds
            //---------------------------------------------------------------------------------------------------------

            GameObject pGameObj = null;

            // create the factory - needs reworking
            BirdFactory BF = new BirdFactory(SpriteBatch.Name.AngryBirds, SpriteBatch.Name.Boxes);

            GameObject pGrid = BF.Create(GameObject.Name.BirdGrid, BirdCategory.Type.Grid);

            for (int i = 0; i < 3; i++)
            {
                GameObject pCol = BF.Create(GameObject.Name.BirdColumn_0 + i, BirdCategory.Type.Column);
                pCol.ActivateCollisionSprite(pSB_Birds);

                pGameObj = BF.Create(GameObject.Name.RedBird, BirdCategory.Type.Red, 200.0f + i * 75.0f, 300.0f);
                pCol.Add(pGameObj);

                pGameObj = BF.Create(GameObject.Name.YellowBird, BirdCategory.Type.Yellow, 200.0f + i * 75.0f, 375.0f);
                pCol.Add(pGameObj);

                pGameObj = BF.Create(GameObject.Name.GreenBird, BirdCategory.Type.Green, 200.0f + i * 75.0f, 450.0f);
                pCol.Add(pGameObj);

                pGrid.Add(pCol);
            }

            GameObjectNodeMan.Attach(pGrid);


            //-----------------------------------------------------------------
            // Print Test
            //-----------------------------------------------------------------

            Debug.WriteLine("-------------------");

            IteratorForwardComposite pFor = new IteratorForwardComposite(pGrid);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                pNode.DumpNode();

                pNode = pFor.Next();
            }

            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPairMan.Add(ColPair.Name.Alien_Wall, pGrid, pWallGroup);

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
            BirdGrid pGrid = (BirdGrid)GameObjectNodeMan.Find(GameObject.Name.BirdGrid);
            pGrid.MoveGrid();


            // Snd update - keeps everything moving and updating smoothly
            sndEngine.Update();

            // Fire off the timer events
            TimerEventMan.Update(this.GetTime());

            // walk through all objects and push to proxy
            GameObjectNodeMan.Update();

            // Do the collision checks
            //Debug.WriteLine("\n------------------------------------");
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
            FontMan.Destroy();
            GlyphMan.Destroy();
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
