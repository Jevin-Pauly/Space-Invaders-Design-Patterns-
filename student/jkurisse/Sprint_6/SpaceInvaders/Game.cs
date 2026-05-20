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
        string score1 = "S C O R E < 1 >";
        string score2 = "S C O R E < 2 >";
        string hiscore = "H I - S C O R E";
        string wavenum = "0 - W A V";
        string year = "S P R I N T 6";
        string animcount = "0";
        string lives = "3";
        string credit = "C R E D I T";
        string creditnum = "0 0";

        float playerLifeStart = 88.0f;

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
            //-------------------------------------------------------
            // Load Managers
            //-------------------------------------------------------

            TextureMan.Create();
            ImageMan.Create();
            SpriteGameMan.Create();
            SpriteBatchMan.Create();
            SpriteBoxMan.Create();
            TimerEventMan.Create();
            SpriteGameProxyMan.Create(55, 1);
            GameObjectNodeMan.Create(); 
            ColPairMan.Create();
            GlyphMan.Create();
            FontMan.Create();

            //------------------------------------------------------
            // Sound Experiment
            //------------------------------------------------------

            // start up the engine
            sndEngine = new IrrKlang.ISoundEngine();
            IrrKlang.ISoundSource pSndVader0 = sndEngine.AddSoundSourceFromFile("fastinvader1.wav");
            pSndVader0.DefaultVolume = 0.0f;
            IrrKlang.ISound pSnd = sndEngine.Play2D(pSndVader0, false, false, false);
            pSndVader0.DefaultVolume = 1.0f;

            //-------------------------------------------------------
            // Load the Textures
            //-------------------------------------------------------

            TextureMan.Add(Texture.Name.Aliens, "SpaceInvaders_ROM.t.azul");
            TextureMan.Add(Texture.Name.Birds, "Birds.t.azul");
            //TextureMan.Add(Texture.Name.PacMan, "PacMan.t.azul");


            //---------------------------------------------------------------------------------------------------------
            // Font Experiment
            //---------------------------------------------------------------------------------------------------------

            //TextureMan.Add(Texture.Name.Consolas36pt, "consolas36pt.t.azul");
            //GlyphMan.AddXml("Consolas36pt.xml", Glyph.Name.Consolas36pt, Texture.Name.Consolas36pt);
            GlyphMan.Add(Glyph.Name.Aliens, 65, Texture.Name.Aliens, 3, 36, 5, 8); // .A
            GlyphMan.Add(Glyph.Name.Aliens, 66, Texture.Name.Aliens, 11, 36, 5, 8); // .B
            GlyphMan.Add(Glyph.Name.Aliens, 67, Texture.Name.Aliens, 19, 36, 5, 8); // .C
            GlyphMan.Add(Glyph.Name.Aliens, 68, Texture.Name.Aliens, 27, 36, 5, 8); // .D
            GlyphMan.Add(Glyph.Name.Aliens, 69, Texture.Name.Aliens, 35, 36, 5, 8); // .E
            GlyphMan.Add(Glyph.Name.Aliens, 70, Texture.Name.Aliens, 43, 36, 5, 8); // .F
            GlyphMan.Add(Glyph.Name.Aliens, 71, Texture.Name.Aliens, 51, 36, 5, 8); // .G
            GlyphMan.Add(Glyph.Name.Aliens, 72, Texture.Name.Aliens, 59, 36, 5, 8); // .H
            GlyphMan.Add(Glyph.Name.Aliens, 73, Texture.Name.Aliens, 67, 36, 5, 8); // .I
            GlyphMan.Add(Glyph.Name.Aliens, 74, Texture.Name.Aliens, 75, 36, 5, 8); // .J
            GlyphMan.Add(Glyph.Name.Aliens, 75, Texture.Name.Aliens, 83, 36, 5, 8); // .K
            GlyphMan.Add(Glyph.Name.Aliens, 76, Texture.Name.Aliens, 91, 36, 5, 8); // .L
            GlyphMan.Add(Glyph.Name.Aliens, 77, Texture.Name.Aliens, 99, 36, 5, 8); // .M
            GlyphMan.Add(Glyph.Name.Aliens, 78, Texture.Name.Aliens, 3, 46, 5, 8); // .N
            GlyphMan.Add(Glyph.Name.Aliens, 79, Texture.Name.Aliens, 11, 46, 5, 8); // .O
            GlyphMan.Add(Glyph.Name.Aliens, 80, Texture.Name.Aliens, 19, 46, 5, 8); // .P
            GlyphMan.Add(Glyph.Name.Aliens, 81, Texture.Name.Aliens, 27, 46, 5, 8); // .Q
            GlyphMan.Add(Glyph.Name.Aliens, 82, Texture.Name.Aliens, 35, 46, 5, 8); // .R
            GlyphMan.Add(Glyph.Name.Aliens, 83, Texture.Name.Aliens, 43, 46, 5, 8); // .S
            GlyphMan.Add(Glyph.Name.Aliens, 84, Texture.Name.Aliens, 51, 46, 5, 8); // .T
            GlyphMan.Add(Glyph.Name.Aliens, 85, Texture.Name.Aliens, 59, 46, 5, 8); // .U
            GlyphMan.Add(Glyph.Name.Aliens, 86, Texture.Name.Aliens, 67, 46, 5, 8); // .V
            GlyphMan.Add(Glyph.Name.Aliens, 87, Texture.Name.Aliens, 75, 46, 5, 8); // .W
            GlyphMan.Add(Glyph.Name.Aliens, 88, Texture.Name.Aliens, 83, 46, 5, 8); // .X
            GlyphMan.Add(Glyph.Name.Aliens, 89, Texture.Name.Aliens, 91, 46, 5, 8); // .Y
            GlyphMan.Add(Glyph.Name.Aliens, 90, Texture.Name.Aliens, 99, 46, 5, 8); // .Z
            GlyphMan.Add(Glyph.Name.Aliens, 48, Texture.Name.Aliens, 3, 56, 5, 8); // 0
            GlyphMan.Add(Glyph.Name.Aliens, 49, Texture.Name.Aliens, 11, 56, 5, 8); // 1
            GlyphMan.Add(Glyph.Name.Aliens, 50, Texture.Name.Aliens, 19, 56, 5, 8); // 2
            GlyphMan.Add(Glyph.Name.Aliens, 51, Texture.Name.Aliens, 27, 56, 5, 8); // 3
            GlyphMan.Add(Glyph.Name.Aliens, 52, Texture.Name.Aliens, 35, 56, 5, 8); // 4
            GlyphMan.Add(Glyph.Name.Aliens, 53, Texture.Name.Aliens, 43, 56, 5, 8); // 5
            GlyphMan.Add(Glyph.Name.Aliens, 54, Texture.Name.Aliens, 51, 56, 5, 8); // 6
            GlyphMan.Add(Glyph.Name.Aliens, 55, Texture.Name.Aliens, 59, 56, 5, 8); // 7
            GlyphMan.Add(Glyph.Name.Aliens, 56, Texture.Name.Aliens, 67, 56, 5, 8); // 8
            GlyphMan.Add(Glyph.Name.Aliens, 57, Texture.Name.Aliens, 75, 56, 5, 8); // 9
            GlyphMan.Add(Glyph.Name.Aliens, 60, Texture.Name.Aliens, 83, 56, 5, 8); // <
            GlyphMan.Add(Glyph.Name.Aliens, 62, Texture.Name.Aliens, 91, 56, 5, 8); // >
            GlyphMan.Add(Glyph.Name.Aliens, 32, Texture.Name.Aliens, 99, 56, 1, 8); // Space
            GlyphMan.Add(Glyph.Name.Aliens, 61, Texture.Name.Aliens, 107, 56, 5, 8); // =
            GlyphMan.Add(Glyph.Name.Aliens, 42, Texture.Name.Aliens, 115, 56, 5, 8); // *
            GlyphMan.Add(Glyph.Name.Aliens, 63, Texture.Name.Aliens, 123, 56, 5, 8); // ?
            GlyphMan.Add(Glyph.Name.Aliens, 45, Texture.Name.Aliens, 131, 56, 5, 8); // - 



            //-------------------------------------------------------
            // Create Images
            //-------------------------------------------------------


            // --- Invaders ---
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.Aliens, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.Aliens, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidA, Texture.Name.Aliens, 61, 3, 8, 8);

            ImageMan.Add(Image.Name.OctopusB, Texture.Name.Aliens, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.Aliens, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.Aliens, 72, 3, 8, 8);

            // --- Ship Stuff ---
            ImageMan.Add(Image.Name.Missile, Texture.Name.Aliens, 3, 29, 1, 4);
            ImageMan.Add(Image.Name.Ship, Texture.Name.Aliens, 3, 14, 13, 8);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------


            // --- Invaders ---

            SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabA, 0, 0, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 0, 0, 24, 25);

            // --- Ship Stuff ---
            SpriteGameMan.Add(SpriteGame.Name.Missile, Image.Name.Missile, 0, 0, 3, 12);
            SpriteGameMan.Add(SpriteGame.Name.Ship, Image.Name.Ship, 0, 0, 39, 24, new Azul.Color(0.0f, 1.0f, 0.0f, 1.0f));


            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatch pSB_Invaders = SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);
            SpriteBatch pSB_Lives = SpriteBatchMan.Add(SpriteBatch.Name.PlayerLives);
            SpriteBatch pSB_Missiles = SpriteBatchMan.Add(SpriteBatch.Name.Missiles);
            SpriteBatch pSB_Walls = SpriteBatchMan.Add(SpriteBatch.Name.Walls);


            //---------------------------------------------------------------------------------------------------------
            // Create Aliens
            //---------------------------------------------------------------------------------------------------------

            GameObject pGameObj = null;

            // create the factory - needs reworking

            Composite pAlienRoot = (Composite)new AlienRoot(GameObject.Name.AlienRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            GameObjectNodeMan.Attach(pAlienRoot);


            AlienFactory AF = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes, pAlienRoot);

            // Set Parent for Grid as Root
            AF.SetParent(pAlienRoot);
            GameObject pGrid = AF.Create(GameObject.Name.AlienGrid, AlienCategory.Type.Grid);
            //pGrid.ActivateCollisionSprite(pSB_Box);

            for (int i = 0; i < 11; i++)
            {
                float X = 86.0f + (50.0f * i);
                // Set Parent for Column as Grid
                AF.SetParent(pGrid);
                GameObject pCol = AF.Create(GameObject.Name.AlienColumn_0 + i, AlienCategory.Type.Column);
                //pCol.ActivateCollisionSprite(pSB_Box);

                // Set Parent for Aliens as Column
                AF.SetParent(pCol);
                pGameObj = AF.Create(GameObject.Name.Aliens, AlienCategory.Type.Octopus, X, 400.0f);
                //pCol.Add(pGameObj);

                pGameObj = AF.Create(GameObject.Name.Aliens, AlienCategory.Type.Octopus, X, 400.0f + 50.0f);
                //pCol.Add(pGameObj);

                pGameObj = AF.Create(GameObject.Name.Aliens, AlienCategory.Type.Crab, X, 500.0f);
                //pCol.Add(pGameObj);

                pGameObj = AF.Create(GameObject.Name.Aliens, AlienCategory.Type.Crab, X, 500.0f + 50.0f);
                //pCol.Add(pGameObj);

                pGameObj = AF.Create(GameObject.Name.Aliens, AlienCategory.Type.Squid, X, 600.0f);
                //pCol.Add(pGameObj);

                //pGrid.Add(pCol);
            }


            //GameObjectNodeMan.Attach(pGrid);



            //---------------------------------------------------------------------------------------------------------
            // Font Setup
            //---------------------------------------------------------------------------------------------------------


            FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, score1, Glyph.Name.Aliens, 26, 740);
            FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, score2, Glyph.Name.Aliens, 503, 740);
            FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, hiscore, Glyph.Name.Aliens, 265, 740);
            FontMan.Add(Font.Name.WaveNum, SpriteBatch.Name.Texts, wavenum, Glyph.Name.Aliens, 52, 700);
            FontMan.Add(Font.Name.Year, SpriteBatch.Name.Texts, year, Glyph.Name.Aliens, 275, 700);
            FontMan.Add(Font.Name.AnimCount, SpriteBatch.Name.Texts, animcount, Glyph.Name.Aliens, 557, 700);
            FontMan.Add(Font.Name.Lives, SpriteBatch.Name.Texts, lives, Glyph.Name.Aliens, 25, 30);
            FontMan.Add(Font.Name.Credit, SpriteBatch.Name.Texts, credit, Glyph.Name.Aliens, 485, 30);
            FontMan.Add(Font.Name.CreditNum, SpriteBatch.Name.Texts, creditnum, Glyph.Name.Aliens, 608, 30);


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


            //---------------------------------------------------------------------------------------------------------
            // Create Walls
            //---------------------------------------------------------------------------------------------------------

            // Wall Root
            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Walls);
            pWallGroup.ActivateCollisionSprite(pSB_Box);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 660, 350, 24, 580);
            pWallRight.ActivateCollisionSprite(pSB_Box);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, 14, 350, 24, 580);
            pWallLeft.ActivateCollisionSprite(pSB_Box);

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, SpriteGame.Name.NullObject, 337, 716, 672, 103);
            pWallTop.ActivateCollisionSprite(pSB_Box);

            WallTop pWallBottom = new WallTop(GameObject.Name.WallBottom, SpriteGame.Name.NullObject, 337, 50, 672, 3);
            pWallBottom.ActivateCollisionSprite(pSB_Box);

            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);

            GameObjectNodeMan.Attach(pWallGroup);

            //---------------------------------------------------------------------------------------------------------
            // Create Bumpers
            //---------------------------------------------------------------------------------------------------------


            BumperLeft pBumperLeft = new BumperLeft(GameObject.Name.BumperLeft, SpriteGame.Name.NullObject, 26, 100, 50, 100);
            pBumperLeft.ActivateSprite(pSB_Invaders);
            pBumperLeft.ActivateCollisionSprite(pSB_Box);

            BumperRight pBumperRight = new BumperRight(GameObject.Name.BumperRight, SpriteGame.Name.NullObject, 647, 100, 50, 100);
            pBumperRight.ActivateSprite(pSB_Invaders);
            pBumperRight.ActivateCollisionSprite(pSB_Box);


            GameObjectNodeMan.Attach(pBumperLeft);
            GameObjectNodeMan.Attach(pBumperRight);


            //-------------------------------------------------------------------
            // Create Missile
            //-------------------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(pSB_Missiles);
            pMissileGroup.ActivateCollisionSprite(pSB_Box);


            GameObjectNodeMan.Attach(pMissileGroup);

            Debug.WriteLine("-------------------");

            //  pMissileGroup.Print();


            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, SpriteGame.Name.NullObject, 336, 100);
            pShipRoot.ActivateCollisionSprite(pSB_Box);
            GameObjectNodeMan.Attach(pShipRoot);

            ShipMan.Create();



            //---------------------------------------------------------------------------------------------------------
            // Timer Events
            //---------------------------------------------------------------------------------------------------------

            MoveGridCommand moveGridCommand = new MoveGridCommand(pGrid);

            AnimationCmd pAnimationCrab = new AnimationCmd(SpriteGame.Name.Crab);
            pAnimationCrab.Attach(Image.Name.CrabA);
            pAnimationCrab.Attach(Image.Name.CrabB);

            AnimationCmd pAnimationOctopus = new AnimationCmd(SpriteGame.Name.Octopus);
            pAnimationOctopus.Attach(Image.Name.OctopusA);
            pAnimationOctopus.Attach(Image.Name.OctopusB);

            AnimationCmd pAnimationSquid = new AnimationCmd(SpriteGame.Name.Squid);
            pAnimationSquid.Attach(Image.Name.SquidA);
            pAnimationSquid.Attach(Image.Name.SquidB);

            SpriteAnimationManager animationManager = new SpriteAnimationManager(pAnimationSquid, pAnimationCrab, pAnimationOctopus, moveGridCommand);
            TimerEventMan.Add(TimerEvent.Name.Animation, animationManager, 0.7f);


            //------------------------------------------------------------------------------------------
            // ColPair 
            //------------------------------------------------------------------------------------------

            // Alien Grid with Side Walls
            ColPair pColPairAlienWall = ColPairMan.Add(ColPair.Name.Alien_Wall, pAlienRoot, pWallGroup);
            Debug.Assert(pColPairAlienWall != null);

            pColPairAlienWall.Attach(new GridObserver());
            //pColPair.Attach(new SndObserver(sndEngine, pSndVader0));

            // Missile with Top Wall
            ColPair pColPairMissileWall = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallTop);
            Debug.Assert(pColPairMissileWall != null);

            pColPairMissileWall.Attach(new ShipReadyObserver());
            pColPairMissileWall.Attach(new ShipRemoveMissileObserver());

            // Ship with Right Bumper
            ColPair pColPairShipWallRight = ColPairMan.Add(ColPair.Name.Ship_Wall, pShipRoot, pBumperRight);
            Debug.Assert(pColPairShipWallRight != null);
            
            pColPairShipWallRight.Attach(new ShipBumpRightObserver());

            // Ship with Left Bumper
            ColPair pColPairShipWallLeft = ColPairMan.Add(ColPair.Name.Ship_Wall, pShipRoot, pBumperLeft);
            Debug.Assert(pColPairShipWallLeft != null);

            pColPairShipWallLeft.Attach(new ShipBumpLeftObserver());

            ColPair pColPairAlienMissile = ColPairMan.Add(ColPair.Name.Alien_Missile, pMissileGroup, pAlienRoot);
            Debug.Assert(pColPairAlienMissile != null);

            pColPairAlienMissile.Attach(new ShipRemoveMissileObserver());
            pColPairAlienMissile.Attach(new RemoveAlienObserver(animationManager, moveGridCommand));
            pColPairAlienMissile.Attach(new ShipReadyObserver());



            //------------------------------------------------------------------------------------------
            // Player Lives
            //------------------------------------------------------------------------------------------

            for (int i = 0; i < 3; i++)
            {
                SpriteGameProxy playerLife = SpriteGameProxyMan.Add(SpriteGame.Name.Ship);
                playerLife.x = playerLifeStart + i * 45;
                playerLife.y = 33.0f;
                pSB_Lives.Attach(playerLife);
            }


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

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_K))
            {
                TimerEvent move = TimerEventMan.Find(TimerEvent.Name.Animation);
                move.switchState();
            }

            // Snd update - keeps everything moving and updating smoothly
            sndEngine.Update();

            // Input
            InputMan.Update();

            // Fire off the timer events
            TimerEventMan.Update(this.GetTime());

            // walk through all objects and push to proxy
            GameObjectNodeMan.Update();

            // Do the collision checks
            //Debug.WriteLine("\n------------------------------------");
            ColPairMan.Process();

            // Delete any objects here...
            DelayedObjectMan.Process();
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
