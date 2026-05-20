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
        string year = "1 9 7 9";
        string animcount = "0";

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

            // --- Birds ---

            //ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            //ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            //ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            //ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);
            ImageMan.Add(Image.Name.BlueBird, Texture.Name.Birds, 301, 49, 33, 33);


            // --- Pacman ---

            //ImageMan.Add(Image.Name.RedGhost, Texture.Name.PacMan, 616, 148, 33, 33);
            //ImageMan.Add(Image.Name.PinkGhost, Texture.Name.PacMan, 663, 148, 33, 33);
            //ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);
            //ImageMan.Add(Image.Name.OrangeGhost, Texture.Name.PacMan, 757, 148, 33, 33);
            //ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);

            // --- Invaders ---
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.Aliens, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.Aliens, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidA, Texture.Name.Aliens, 61, 3, 8, 8);

            ImageMan.Add(Image.Name.OctopusB, Texture.Name.Aliens, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.Aliens, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.Aliens, 72, 3, 8, 8);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------

            // --- BoxSprites ---
            //SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            //SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            // --- Birds ---

            //SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 50, 500, 50,50);
            //SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 50,50);
            //SpriteGameMan.Add(SpriteGame.Name.GreenBird, Image.Name.GreenBird, 400, 200, 50,50);
            //SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 600, 300, 50,50);
            SpriteGameMan.Add(SpriteGame.Name.BlueBird, Image.Name.BlueBird, 50, 50, 50, 50);

            // --- Pacman ---

            //SpriteGameMan.Add(SpriteGame.Name.RedGhost, Image.Name.RedGhost, 100, 300, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.PinkGhost, Image.Name.PinkGhost, 300, 300, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.BlueGhost, Image.Name.BlueGhost, 500, 300, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.OrangeGhost, Image.Name.OrangeGhost, 700, 300, 100, 100);

            // --- Invaders ---

            SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabA, 0, 0, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 0, 0, 24, 25);


            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatch pSB_Invaders = SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);

            //SpriteBatch pSB_PacMan = SpriteBatchMan.Add(SpriteBatch.Name.PacMan);
            //SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.AngryBirds);





            //-------------------------------------------------------------------
            // Create Missile
            //-------------------------------------------------------------------

            //MissileGroup pMissileGroup = new MissileGroup();
            //pMissileGroup.ActivateSprite(pSB_Birds);
            //pMissileGroup.ActivateCollisionSprite(pSB_Birds);
            //
            //Missile pMissile = new Missile(SpriteGame.Name.BlueBird, 405, 100);
            //pMissile.ActivateSprite(pSB_Birds);
            //pMissile.ActivateCollisionSprite(pSB_Birds);
            //
            //pMissileGroup.Add(pMissile);
            //
            //GameObjectNodeMan.Attach(pMissileGroup);

            Debug.WriteLine("-------------------");

            //  pMissileGroup.Print();

            //---------------------------------------------------------------------------------------------------------
            // Create Walls
            //---------------------------------------------------------------------------------------------------------

            // Wall Root
            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Box);
            pWallGroup.ActivateCollisionSprite(pSB_Box);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 672, 350, 24, 580);
            pWallRight.ActivateCollisionSprite(pSB_Box);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, 0, 350, 24, 580);
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
            AlienFactory BF = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);

            GameObject pGrid = BF.Create(GameObject.Name.AlienGrid, AlienCategory.Type.Grid);
            pGrid.ActivateCollisionSprite(pSB_Box);

            for (int i = 0; i < 11; i++)
            {
                float X = 86.0f + (50.0f * i);

                GameObject pCol = BF.Create(GameObject.Name.AlienColumn_0 + i, AlienCategory.Type.Column);
                pCol.ActivateCollisionSprite(pSB_Box);

                pGameObj = BF.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, X, 400.0f);
                pCol.Add(pGameObj);

                pGameObj = BF.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, X, 400.0f + 50.0f);
                pCol.Add(pGameObj);

                pGameObj = BF.Create(GameObject.Name.Crab, AlienCategory.Type.Crab, X, 500.0f);
                pCol.Add(pGameObj);

                pGameObj = BF.Create(GameObject.Name.Crab, AlienCategory.Type.Crab, X, 500.0f + 50.0f);
                pCol.Add(pGameObj);

                pGameObj = BF.Create(GameObject.Name.Squid, AlienCategory.Type.Squid, X, 600.0f);
                pCol.Add(pGameObj);

                pGrid.Add(pCol);
            }


            GameObjectNodeMan.Attach(pGrid);



            //---------------------------------------------------------------------------------------------------------
            // Font Setup
            //---------------------------------------------------------------------------------------------------------


            FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, score1, Glyph.Name.Aliens, 26, 740);
            FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, score2, Glyph.Name.Aliens, 503, 740);
            FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, hiscore, Glyph.Name.Aliens, 265, 740);
            FontMan.Add(Font.Name.WaveNum, SpriteBatch.Name.Texts, wavenum, Glyph.Name.Aliens, 52, 700);
            FontMan.Add(Font.Name.Year, SpriteBatch.Name.Texts, year, Glyph.Name.Aliens, 302, 700);
            FontMan.Add(Font.Name.AnimCount, SpriteBatch.Name.Texts, animcount, Glyph.Name.Aliens, 557, 700);





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



            //-----------------------------------------------------------------
            // Print Test
            //-----------------------------------------------------------------

            //Debug.WriteLine("-------------------");

            //IteratorForwardComposite pFor = new IteratorForwardComposite(pGrid);
            //
            //Component pNode = pFor.First();
            //while (!pFor.IsDone())
            //{
            //    pNode.DumpNode();
            //
            //    pNode = pFor.Next();
            //}

            //------------------------------------------------------------------------------------------
            // ColPair 
            //------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Alien_Wall, pGrid, pWallGroup);
            Debug.Assert(pColPair != null);

            pColPair.Attach(new GridObserver());
            //pColPair.Attach(new SndObserver(sndEngine, pSndVader0));

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
