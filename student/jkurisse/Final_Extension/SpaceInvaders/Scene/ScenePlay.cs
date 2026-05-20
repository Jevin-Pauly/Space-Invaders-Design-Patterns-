//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Shapes;

namespace SE456
{
    public class ScenePlay : SceneState
    {
        public ScenePlay()
        {

            this.Initialize();
        }
        public override void Handle()
        {

        }


        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poFontMan = new FontMan(3, 1);
            FontMan.SetActive(this.poFontMan);

            this.pColPairMan = new ColPairMan();
            ColPairMan.SetActive(this.pColPairMan);

            this.poTimerMan = new TimerEventMan(3, 1);
            TimerEventMan.SetActive(this.poTimerMan);

            this.poGOBMan = new GameObjectNodeMan(3, 1);
            GameObjectNodeMan.SetActive(this.poGOBMan);

            this.FirstTime = true;

            //------------------------------------------------------
            // Sound Experiment
            //------------------------------------------------------

            // start up the engine
            sndEngine = new IrrKlang.ISoundEngine();
            IrrKlang.ISoundSource pSndVader0 = sndEngine.AddSoundSourceFromFile("fastinvader1.wav");
            pSndVader0.DefaultVolume = 0.0f;
            IrrKlang.ISound pSnd = sndEngine.Play2D(pSndVader0, false, false, false);
            pSndVader0.DefaultVolume = 1.0f;


            IrrKlang.ISoundSource sndShoot = sndEngine.AddSoundSourceFromFile("invaderkilled.wav");
            IrrKlang.ISoundSource sndExplode = sndEngine.AddSoundSourceFromFile("explosion.wav");
            IrrKlang.ISoundSource sndAlienDeath = sndEngine.AddSoundSourceFromFile("shoot.wav");

            //-------------------------------------------------------
            // Load the Textures
            //-------------------------------------------------------

            TextureMan.Add(Texture.Name.Aliens, "SpaceInvaders_ROM.t.azul");
            TextureMan.Add(Texture.Name.Birds, "Birds_N_Shield.t.azul");
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

            // --- Shield Stuff ---
            ImageMan.Add(Image.Name.Brick, Texture.Name.Birds, 20, 210, 10, 5);
            ImageMan.Add(Image.Name.Brick_LeftTop0, Texture.Name.Birds, 15, 180, 10, 10);
            ImageMan.Add(Image.Name.Brick_LeftTop1, Texture.Name.Birds, 15, 185, 10, 5);
            ImageMan.Add(Image.Name.Brick_LeftBottom, Texture.Name.Birds, 36, 215, 10, 5);
            ImageMan.Add(Image.Name.Brick_RightTop0, Texture.Name.Birds, 75, 180, 10, 10);
            ImageMan.Add(Image.Name.Brick_RightTop1, Texture.Name.Birds, 75, 185, 10, 5);
            ImageMan.Add(Image.Name.Brick_RightBottom, Texture.Name.Birds, 55, 215, 10, 5);

            // --- UFO ---
            ImageMan.Add(Image.Name.UFO, Texture.Name.Aliens, 99, 3, 16, 8);

            // --- Bomb ---
            //ImageMan.Add(Image.Name.BombStraight, Texture.Name.Birds, 111, 101, 5, 49);
            //ImageMan.Add(Image.Name.BombZigZag, Texture.Name.Birds, 132, 100, 20, 50);
            //ImageMan.Add(Image.Name.BombCross, Texture.Name.Birds, 219, 103, 19, 47);

            ImageMan.Add(Image.Name.SquigglyShotA, Texture.Name.Aliens, 18, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotB, Texture.Name.Aliens, 24, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotC, Texture.Name.Aliens, 30, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotD, Texture.Name.Aliens, 36, 26, 3, 7);
            ImageMan.Add(Image.Name.PlungerShotA, Texture.Name.Aliens, 42, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotB, Texture.Name.Aliens, 48, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotC, Texture.Name.Aliens, 54, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotD, Texture.Name.Aliens, 60, 27, 3, 6);
            ImageMan.Add(Image.Name.RollingShotA, Texture.Name.Aliens, 65, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotB, Texture.Name.Aliens, 70, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotC, Texture.Name.Aliens, 75, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotD, Texture.Name.Aliens, 80, 26, 3, 7);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------


            // --- Invaders ---

            SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.Crab, Image.Name.CrabA, 0, 0, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.Squid, Image.Name.SquidA, 0, 0, 24, 25);

            // --- UFO ---
            SpriteGameMan.Add(SpriteGame.Name.UFO, Image.Name.UFO, 0, 0, 48, 24, new Azul.Color(1.0f, 0.0f, 0.0f, 1.0f));

            // --- Ship Stuff ---
            SpriteGameMan.Add(SpriteGame.Name.Missile, Image.Name.Missile, 0, 0, 3, 12);
            SpriteGameMan.Add(SpriteGame.Name.Ship, Image.Name.Ship, 0, 0, 39, 24, new Azul.Color(0.0f, 1.0f, 0.0f, 1.0f));

            // --- Shield Stuff ---
            SpriteGameMan.Add(SpriteGame.Name.Brick, Image.Name.Brick, 50, 25, 11, 11);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop0, Image.Name.Brick_LeftTop0, 0, 25, 11, 11);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop1, Image.Name.Brick_LeftTop1, 0, 25, 11, 11);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftBottom, Image.Name.Brick_LeftBottom, 0, 25, 11, 11);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop0, Image.Name.Brick_RightTop0, 0, 25, 11, 11);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop1, Image.Name.Brick_RightTop1, 0, 25, 11, 11);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightBottom, Image.Name.Brick_RightBottom, 0, 25, 11, 11);

            // --- Bomb Stuff ---
            SpriteGameMan.Add(SpriteGame.Name.BombZigZag, Image.Name.SquigglyShotA, 200, 200, 20, 30);
            SpriteGameMan.Add(SpriteGame.Name.BombStraight, Image.Name.PlungerShotA, 100, 100, 10, 30);
            SpriteGameMan.Add(SpriteGame.Name.BombDagger, Image.Name.RollingShotA, 100, 100, 20, 30);

            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatch pSB_Invaders = SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);
            pSB_Box.Disable();

            SpriteBatch pSB_Lives = SpriteBatchMan.Add(SpriteBatch.Name.PlayerLives);
            SpriteBatch pSB_Missiles = SpriteBatchMan.Add(SpriteBatch.Name.Missiles);
            SpriteBatch pSB_Walls = SpriteBatchMan.Add(SpriteBatch.Name.Walls);
            SpriteBatch pSB_Shields = SpriteBatchMan.Add(SpriteBatch.Name.Shields);
            SpriteBatch pSB_UFO = SpriteBatchMan.Add(SpriteBatch.Name.UFO);
            SpriteBatch pSB_Bombs = SpriteBatchMan.Add(SpriteBatch.Name.Bombs);

            //-------------------------------------------------------
            // Create UFO
            //-------------------------------------------------------
            Composite pUFORoot = (Composite)new UFORoot(GameObject.Name.UFORoot, SpriteGame.Name.NullObject);
            GameObjectNodeMan.Attach(pUFORoot);

            UFOMan.Create();
            //UFOMan.GetUFOLeftMoving().SetSoundEngine(sndEngine);
            //UFOMan.GetUFORightMoving().SetSoundEngine(sndEngine);

            //---------------------------------------------------------------------------------------------------------
            // Create Aliens
            //---------------------------------------------------------------------------------------------------------

            GameObject pAlienRoot = AlienFactory.CreateAliens();
            // For the Alien Count
            this.poAlienRoot = (AlienRoot)pAlienRoot;

            //-------------------------------------------------------------------
            // Create Shields
            //-------------------------------------------------------------------

            GameObject pShieldRoot = ShieldFactory.CreateShields();

            //---------------------------------------------------------------------------------------------------------
            // Font Setup
            //---------------------------------------------------------------------------------------------------------

            FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, score1, Glyph.Name.Aliens, 26, 740);
            FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, score2, Glyph.Name.Aliens, 503, 740);
            FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, hiscore, Glyph.Name.Aliens, 265, 740);
            FontMan.Add(Font.Name.WaveNum, SpriteBatch.Name.Texts, wavenum, Glyph.Name.Aliens, 525, 700);
            FontMan.Add(Font.Name.Year, SpriteBatch.Name.Texts, SpriteGameMan.GetHiScore(), Glyph.Name.Aliens, 310, 700);
            FontMan.Add(Font.Name.P1Score, SpriteBatch.Name.Texts, animcount, Glyph.Name.Aliens, 52, 700);
            FontMan.Add(Font.Name.Lives, SpriteBatch.Name.Texts, lives, Glyph.Name.Aliens, 25, 30);
            FontMan.Add(Font.Name.Credit, SpriteBatch.Name.Texts, credit, Glyph.Name.Aliens, 485, 30);
            FontMan.Add(Font.Name.CreditNum, SpriteBatch.Name.Texts, creditnum, Glyph.Name.Aliens, 608, 30);

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

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, SpriteGame.Name.NullObject, 337, 50, 672, 3);
            pWallBottom.ActivateCollisionSprite(pSB_Lives);


            WallLeft pUFOWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, -60, 500, 2, 580);
            pUFOWallLeft.ActivateCollisionSprite(pSB_Box);

            WallRight pUFOWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 750, 500, 2, 580);
            pUFOWallRight.ActivateCollisionSprite(pSB_Box);

            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);
            pWallGroup.Add(pUFOWallLeft);
            pWallGroup.Add(pUFOWallRight);

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

            //---------------------------------------------------------------------------------------------------------
            // Bomb
            //---------------------------------------------------------------------------------------------------------


            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pSB_Box);

            //Bomb pBombDagger = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombDagger, new FallDagger(), 200, 500);
            //pBombDagger.ActivateCollisionSprite(pSB_Box);
            //pBombDagger.ActivateSprite(pSB_Bombs);
            //
            //Bomb pBombStraight = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombStraight, new FallStraight(), 300, 500);
            //pBombStraight.ActivateCollisionSprite(pSB_Box);
            //pBombStraight.ActivateSprite(pSB_Bombs);
            //
            //Bomb pBombZigZag = new Bomb(GameObject.Name.Bomb, SpriteGame.Name.BombZigZag, new FallDagger(), 400, 500);
            //pBombZigZag.ActivateCollisionSprite(pSB_Box);
            //pBombZigZag.ActivateSprite(pSB_Bombs);

            GameObjectNodeMan.Attach(pBombRoot);

            //-------------------------------------------------------------------
            // Create Missile
            //-------------------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(pSB_Missiles);
            pMissileGroup.ActivateCollisionSprite(pSB_Box);

            GameObjectNodeMan.Attach(pMissileGroup);

            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, SpriteGame.Name.NullObject, 336, 100);
            pShipRoot.ActivateCollisionSprite(pSB_Box);
            GameObjectNodeMan.Attach(pShipRoot);

            ShipMan.Create();


            //------------------------------------------------------------------------------------------
            // Player Lives
            //------------------------------------------------------------------------------------------

            LifeRoot pLifeRoot = new LifeRoot(GameObject.Name.ShipLifeRoot, SpriteGame.Name.NullObject, 336, 100);
            pLifeRoot.CreateLives(2);
            GameObjectNodeMan.Attach(pLifeRoot);
            
            //pLifeRoot.Add(new Life(GameObject.Name.ShipLife, SpriteGame.Name.Ship, 178.0f, 33.0f));

            //---------------------------------------------------------------------------------------------------------
            // Timer Events
            //---------------------------------------------------------------------------------------------------------

            MoveGridCommand moveGridCommand = new MoveGridCommand(pAlienRoot);

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



            BombSpawnCmd bombCommand = new BombSpawnCmd();

            AnimationCmd pAnimationZigZag = new AnimationCmd(SpriteGame.Name.BombZigZag);
            pAnimationZigZag.Attach(Image.Name.SquigglyShotA); 
            pAnimationZigZag.Attach(Image.Name.SquigglyShotB); 
            pAnimationZigZag.Attach(Image.Name.SquigglyShotC);
            pAnimationZigZag.Attach(Image.Name.SquigglyShotD);

            AnimationCmd pAnimationCross = new AnimationCmd(SpriteGame.Name.BombStraight);
            pAnimationCross.Attach(Image.Name.PlungerShotA);
            pAnimationCross.Attach(Image.Name.PlungerShotB);
            pAnimationCross.Attach(Image.Name.PlungerShotC);
            pAnimationCross.Attach(Image.Name.PlungerShotD);

            AnimationCmd pAnimationDagger = new AnimationCmd(SpriteGame.Name.BombDagger);
            pAnimationDagger.Attach(Image.Name.RollingShotA);
            pAnimationDagger.Attach(Image.Name.RollingShotB);
            pAnimationDagger.Attach(Image.Name.RollingShotC);
            pAnimationDagger.Attach(Image.Name.RollingShotD);

            TimerEventMan.Add(TimerEvent.Name.BombSpawn, bombCommand, 4.0f);
            //TimerEventMan.Add(TimerEvent.Name.BombZigZag, pAnimationZigZag, 0.2f);
            //TimerEventMan.Add(TimerEvent.Name.BombCross, pAnimationCross, 0.2f);
            //TimerEventMan.Add(TimerEvent.Name.BombDagger, pAnimationDagger, 0.2f);

            //------------------------------------------------------------------------------------------
            // ColPair 
            //------------------------------------------------------------------------------------------

            // --- Alien Grid with Side Walls ---
            ColPair pColPairAlienWall = ColPairMan.Add(ColPair.Name.Alien_Wall, pAlienRoot, pWallGroup);
            Debug.Assert(pColPairAlienWall != null);

            pColPairAlienWall.Attach(new GridObserver());

            // --- Missile with Top Wall ---
            ColPair pColPairMissileWall = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallTop);
            Debug.Assert(pColPairMissileWall != null);

            pColPairMissileWall.Attach(new ShipReadyObserver());
            pColPairMissileWall.Attach(new ShipRemoveMissileObserver());

            // --- Ship with Right Bumper ---
            ColPair pColPairShipWallRight = ColPairMan.Add(ColPair.Name.Ship_Wall, pShipRoot, pBumperRight);
            Debug.Assert(pColPairShipWallRight != null);

            pColPairShipWallRight.Attach(new ShipBumpRightObserver());

            // --- Ship with Right Bumper ---
            ColPair pColPairShipWallLeft = ColPairMan.Add(ColPair.Name.Ship_Wall, pShipRoot, pBumperLeft);
            Debug.Assert(pColPairShipWallLeft != null);

            pColPairShipWallLeft.Attach(new ShipBumpLeftObserver());

            // --- Missile with Alien ---
            ColPair pColPairAlienMissile = ColPairMan.Add(ColPair.Name.Alien_Missile, pMissileGroup, pAlienRoot);
            Debug.Assert(pColPairAlienMissile != null);

            pColPairAlienMissile.Attach(new ShipRemoveMissileObserver());
            pColPairAlienMissile.Attach(new RemoveAlienObserver(animationManager, moveGridCommand));
            pColPairAlienMissile.Attach(new ShipReadyObserver());
            pColPairAlienMissile.Attach(new SndObserver(sndEngine, sndAlienDeath));

            // --- Missile with Shield ---
            ColPair pColPairMissileShield = ColPairMan.Add(ColPair.Name.Missile_Shield, pMissileGroup, pShieldRoot);
            Debug.Assert(pColPairMissileShield != null);

            pColPairMissileShield.Attach(new ShipRemoveMissileObserver());
            pColPairMissileShield.Attach(new RemoveBrickObserver());
            pColPairMissileShield.Attach(new ShipReadyObserver());

            // --- Alien with Shield ---
            ColPair pColPairAlienShield = ColPairMan.Add(ColPair.Name.Alien_Shield, pAlienRoot, pShieldRoot);
            Debug.Assert(pColPairAlienShield != null);

            pColPairAlienShield.Attach(new RemoveBrickObserver());

            // --- UFO with Wall ---
            ColPair pColPairUFOWallLeft = ColPairMan.Add(ColPair.Name.UFO_Wall, pUFORoot, pUFOWallLeft);
            Debug.Assert(pColPairUFOWallLeft != null);
            pColPairUFOWallLeft.Attach(new RemoveUFOObserver());

            ColPair pColPairUFOWallRight = ColPairMan.Add(ColPair.Name.UFO_Wall, pUFORoot, pUFOWallRight);
            Debug.Assert(pColPairUFOWallRight != null);
            pColPairUFOWallRight.Attach(new RemoveUFOObserver());

            // --- UFO with Missile ---
            ColPair pColPairUFOAlien = ColPairMan.Add(ColPair.Name.UFO_Missile, pUFORoot, pMissileGroup);
            Debug.Assert(pColPairUFOAlien != null);

            pColPairUFOAlien.Attach(new ShipRemoveMissileObserver());
            pColPairUFOAlien.Attach(new RemoveUFOObserver());
            pColPairUFOAlien.Attach(new ShipReadyObserver());
            pColPairUFOAlien.Attach(new SndObserver(sndEngine, sndAlienDeath));

            // --- Bomb with Wall ---
            ColPair pColPairBombAlien = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            pColPairBombAlien.Attach(new BombObserver());

            // --- Bomb with Shield ---
            ColPair pColPairBombShield = ColPairMan.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pColPairBombShield.Attach(new BombObserver());
            pColPairBombShield.Attach(new RemoveBrickObserver());

            // --- Bomb with Ship ---
            ColPair pColPairBombShip = ColPairMan.Add(ColPair.Name.Bomb_Ship, pBombRoot, pShipRoot);
            pColPairBombShip.Attach(new SndObserver(sndEngine, sndExplode));
            pColPairBombShip.Attach(new RemoveLifeObserver());
            pColPairBombShip.Attach(new BombObserver());

            // --- Bomb with Missile ---
            ColPair pColPairBombMissile = ColPairMan.Add(ColPair.Name.Bomb_Ship, pBombRoot, pMissileGroup);
            pColPairBombMissile.Attach(new SndObserver(sndEngine, sndShoot));
            pColPairBombMissile.Attach(new ShipRemoveMissileObserver());
            pColPairBombMissile.Attach(new ShipReadyObserver());
            pColPairBombMissile.Attach(new BombObserver());




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

            


            //this.ResetTime();
        }




        bool lastKeyR = false;
        bool lastKeyK = false;
        bool lastKeyE = false;

        public override void Update(float systemTime)
        {
            // Add your update below this line: ----------------------------

            // --- Boxes Visibility ---
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


            // --- Stop Movement Dump ---
            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_K) == true && lastKeyK == false)
            {
                TimerEvent move = TimerEventMan.Find(TimerEvent.Name.Animation);
                move.switchState();
            }
            lastKeyK = Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_K);


            // --- Ghost Dump ---
            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_R) == true && lastKeyR == false)
            {
                GhostMan.Dump();
            }
            lastKeyR = Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_R);

            if (this.poAlienRoot.globalAlienDeath >= 55)
            {
                if (this.poAlienRoot.globalAlienDeath != 56)
                {
                    FontMan.Add(Font.Name.NextLevel, SpriteBatch.Name.Texts, "P R E S S     E       T O     C O N T I N U E", Glyph.Name.Aliens, 170, 360);
                    this.poAlienRoot.globalAlienDeath += 1;
                }
                
                if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_E) == true && lastKeyE == false)
                {
                    ShieldFactory.RemoveAll();
                    ShieldFactory.CreateShields();
                    AlienFactory.RemoveAll();
                    AlienFactory.CreateAliens();
                    TimerEventMan.ResetAnimation();
                    UFOMan.ResetTimer();
                    this.poAlienRoot.globalAlienDeath = 0;
                    Font pFont = FontMan.Find(Font.Name.NextLevel);
                    FontMan.Remove(pFont);
                    LifeRoot tempLifeRoot = (LifeRoot)GameObjectNodeMan.Find(GameObject.Name.ShipLifeRoot);
                    tempLifeRoot.CreateLives(2);
                }
                lastKeyE = Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_E);
            }
            

            // Snd update - keeps everything moving and updating smoothly
            sndEngine.Update();

            // Input
            InputMan.Update();

            // Single Step, Free running...
            Simulation.Update(systemTime);

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

                UFOMan.Update();
            }

            if (SpriteGameMan.GameOver)
            {
                ShieldFactory.RemoveAll();
                ShieldFactory.CreateShields();
                AlienFactory.RemoveAll();
                AlienFactory.CreateAliens();
                TimerEventMan.ResetAnimation();
                UFORoot tempUFORoot = (UFORoot)GameObjectNodeMan.Find(GameObject.Name.UFORoot);
                UFO tempUFO = (UFO)tempUFORoot.GetFirstChild();
                if (tempUFO != null)
                {
                    tempUFO.Remove();
                }
                UFOMan.ResetTimer();
                this.poAlienRoot.globalAlienDeath = 55;

            }
        }
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }
        public override void Entering()
        {
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            ColPairMan.SetActive(this.pColPairMan);
            TimerEventMan.SetActive(this.poTimerMan);
            GameObjectNodeMan.SetActive(this.poGOBMan);

            sndEngine.SetAllSoundsPaused(false);
            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);

            if (this.FirstTime)
            {
                this.FirstTime = false;
            }
            else
            {
                FontMan.Find(Font.Name.P1Score).UpdateMessage("0");
            }
        }
        public override void Leaving()
        {
            sndEngine.SetAllSoundsPaused(true);
            // Need a better way to do this
            this.TimeAtPause = GlobalTimer.GetTime();
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
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
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;
        public ColPairMan pColPairMan;
        public TimerEventMan poTimerMan;
        public GameObjectNodeMan poGOBMan;
        private AlienRoot poAlienRoot;
        public bool FirstTime;
    }
}
// --- End of File ---
