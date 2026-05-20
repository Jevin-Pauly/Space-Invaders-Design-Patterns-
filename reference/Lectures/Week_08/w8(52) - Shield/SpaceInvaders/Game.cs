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
            this.SetWindowName("----Simulator Demo: S, D, G, H keys----");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.6f, 0.6f, 0.6f, 1.0f);
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

            Simulation.Create();
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
            sndEngine = new IrrKlang.ISoundEngine(IrrKlang.SoundOutputDriver.DirectSound8, IrrKlang.SoundEngineOptionFlag.PrintDebugInfoIntoDebugger);
            IrrKlang.ISoundSource pSndVader0 = sndEngine.AddSoundSourceFromFile("fastinvader1.wav");
            pSndVader0.DefaultVolume = 0.0f;
            IrrKlang.ISound pSnd = sndEngine.Play2D(pSndVader0, false, false, false);
            pSndVader0.DefaultVolume = 1.0f;

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
            TextureMan.Add(Texture.Name.Birds, "Birds_N_Shield.t.azul");
            //-------------------------------------------------------
            // Create Images
            //-------------------------------------------------------

            ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);
            ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.Name.BlueBird, Texture.Name.Birds, 301, 49, 33, 33);
            ImageMan.Add(Image.Name.Missile, Texture.Name.Birds, 73, 53, 5, 4);
            ImageMan.Add(Image.Name.Ship, Texture.Name.Birds, 10, 93, 30, 18);
            ImageMan.Add(Image.Name.Wall, Texture.Name.Birds, 40, 185, 20, 10);
            ImageMan.Add(Image.Name.BombStraight, Texture.Name.Birds, 111, 101, 5, 49);
            ImageMan.Add(Image.Name.BombZigZag, Texture.Name.Birds, 132, 100, 20, 50);
            ImageMan.Add(Image.Name.BombCross, Texture.Name.Birds, 219, 103, 19, 47);
            ImageMan.Add(Image.Name.Brick, Texture.Name.Birds, 20, 210, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Birds, 15, 180, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Top1, Texture.Name.Birds, 15, 185, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Birds, 35, 215, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Birds, 75, 180, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Top1, Texture.Name.Birds, 75, 185, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Birds, 55, 215, 10, 5);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------

            SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 50, 500, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.GreenBird, Image.Name.GreenBird, 400, 200, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 600, 300, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.BlueBird, Image.Name.BlueBird, 50, 50, 50, 50);
            SpriteGameMan.Add(SpriteGame.Name.Missile, Image.Name.Missile, 0, 0, 5, 20);
            SpriteGameMan.Add(SpriteGame.Name.Ship, Image.Name.Ship, 500, 100, 80, 28);
            SpriteGameMan.Add(SpriteGame.Name.Wall, Image.Name.Wall, 448, 900, 850, 30);

            SpriteGameMan.Add(SpriteGame.Name.BombZigZag, Image.Name.BombZigZag, 200, 200, 20, 60);
            SpriteGameMan.Add(SpriteGame.Name.BombStraight, Image.Name.BombStraight, 100, 100, 10, 60);
            SpriteGameMan.Add(SpriteGame.Name.BombDagger, Image.Name.BombCross, 100, 100, 20, 60);

            SpriteGameMan.Add(SpriteGame.Name.Brick, Image.Name.Brick, 50, 25, 40, 20);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, 40, 20);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, 40, 20);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, 40, 20);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, 40, 20);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, 40, 20);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, 40, 20);

            //---------------------------------------------------------------------------------------------------------
            // Create BoxSprite
            //---------------------------------------------------------------------------------------------------------

            SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.Birds);
            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatch pSB_Shields = SpriteBatchMan.Add(SpriteBatch.Name.Shields);

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------

            InputSubject pInputSubject;
            pInputSubject = InputMan.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver());

            pInputSubject = InputMan.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver());

            pInputSubject = InputMan.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver());

            Simulation.SetState(Simulation.State.Realtime);

            //---------------------------------------------------------------------------------------------------------
            // Bomb
            //---------------------------------------------------------------------------------------------------------


            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pSB_Box);

            //Bomb pBombDagger = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombDagger, new FallDagger(), 700, 700);
            //pBombDagger.ActivateCollisionSprite(pSB_Box);
            //pBombDagger.ActivateSprite(pSB_Birds);

            //Bomb pBombStraight = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombStraight, new FallStraight(), 600, 700);
            //pBombStraight.ActivateCollisionSprite(pSB_Box);
            //pBombStraight.ActivateSprite(pSB_Birds);

            //Bomb pBombZigZag = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombZigZag, new FallDagger(), 500, 700);
            //pBombZigZag.ActivateCollisionSprite(pSB_Box);
            //pBombZigZag.ActivateSprite(pSB_Birds);

            //pBombRoot.Add(pBombStraight);
            //pBombRoot.Add(pBombDagger);
            //pBombRoot.Add(pBombZigZag);

            GameObjectNodeMan.Attach(pBombRoot);

            //---------------------------------------------------------------------------------------------------------
            // Walls
            //---------------------------------------------------------------------------------------------------------

            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Birds);

            //WallTop pWallTop = new WallTop(GameObject.Name.WallTop, SpriteGame.Name.NullObject, 400, 770, 700, 30);
            //pWallTop.ActivateCollisionSprite(pSB_Birds);

            //WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, SpriteGame.Name.Wall, 448, 50, 850, 30);
            //pWallBottom.ActivateCollisionSprite(pSB_Box);
            //pWallBottom.ActivateSprite(pSB_Birds);

            //// Add to the composite the children
            //pWallGroup.Add(pWallTop);
            //pWallGroup.Add(pWallBottom);

            GameObjectNodeMan.Attach(pWallGroup);

            //---------------------------------------------------------------------------------------------------------
            // Missile
            //---------------------------------------------------------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(pSB_Birds);
            pMissileGroup.ActivateCollisionSprite(pSB_Box);

            GameObjectNodeMan.Attach(pMissileGroup);

            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);

            GameObjectNodeMan.Attach(pShipRoot);

            ShipMan.Create();

            //---------------------------------------------------------------------------------------------------------
            // Shield 
            //---------------------------------------------------------------------------------------------------------

            // Create the factory ... prototype
            Composite pShieldRoot = (Composite)new ShieldRoot(GameObject.Name.ShieldRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            GameObjectNodeMan.Attach(pShieldRoot);

            ShieldFactory SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);

            // load by column
            {
                int j = 0;

                GameObject pColumn;

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                float start_x = 400.0f;
                float start_y = 300.0f;
                float off_x = 0;
                float brickWidth = 40.0f;
                float brickHeight = 20.0f;

                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x, start_y + 9 * brickHeight);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            }



            //Debug.WriteLine("-------------------");

            IteratorForwardComposite pIt = new IteratorForwardComposite(pShieldRoot);

            for(pIt.First();!pIt.IsDone(); pIt.Next())
            {
                Component pNode = pIt.Curr();
            //    pNode.Print();
            }




            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            Debug.Assert(pColPair != null);

            // Missile Wall a collision pair
            pColPair.Attach(new ShipReadyObserver());
            pColPair.Attach(new ShipRemoveMissileObserver());

            // Bomb vs Bottom
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            pColPair.Attach(new BombObserver());

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Snd update - keeps everything moving and updating smoothly
            sndEngine.Update();

            // Input
            InputMan.Update();

            // Single Step, Free running...
            Simulation.Update(this.GetTime());

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
            // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

            // walk through all objects and push to proxy
            GameObjectNodeMan.Update();

            // Do the collision checks
            ColPairMan.Process();

            // Delete any objects here...
            DelayedObjectMan.Process();
        }

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
