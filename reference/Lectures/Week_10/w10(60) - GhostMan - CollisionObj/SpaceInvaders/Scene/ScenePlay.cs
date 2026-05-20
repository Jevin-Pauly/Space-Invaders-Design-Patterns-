using System.Diagnostics;

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
            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            TextureMan.Add(Texture.Name.Birds, "Birds_N_Shield.t.azul");

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);
            ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.Name.BlueBird, Texture.Name.Birds, 301, 49, 33, 33);
            ImageMan.Add(Image.Name.Missile, Texture.Name.Birds, 73, 53, 5, 4);
            ImageMan.Add(Image.Name.Ship, Texture.Name.Birds, 10, 93, 30, 18);
            ImageMan.Add(Image.Name.Wall, Texture.Name.Birds, 40, 185, 20, 10);
            ImageMan.Add(Image.Name.BombStraight, Texture.Name.Birds, 225, 70, 10, 10);
            ImageMan.Add(Image.Name.BombZigZag, Texture.Name.Birds, 132, 100, 20, 50);
            ImageMan.Add(Image.Name.BombCross, Texture.Name.Birds, 219, 103, 19, 47);
            ImageMan.Add(Image.Name.Brick, Texture.Name.Birds, 20, 210, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Birds, 15, 180, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Top1, Texture.Name.Birds, 15, 185, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Birds, 35, 215, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Birds, 75, 180, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Top1, Texture.Name.Birds, 75, 185, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Birds, 55, 215, 10, 5);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 50, 500, 70, 70);
            SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 70, 70);
            SpriteGameMan.Add(SpriteGame.Name.GreenBird, Image.Name.GreenBird, 400, 200, 70, 70);
            SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 600, 200, 70, 70);
            SpriteGameMan.Add(SpriteGame.Name.BlueBird, Image.Name.BlueBird, 50, 50, 50, 50);
               
            SpriteGameMan.Add(SpriteGame.Name.Missile, Image.Name.Missile, 0, 0, 5, 50);
            SpriteGameMan.Add(SpriteGame.Name.Ship, Image.Name.Ship, 500, 100, 80, 28);
            SpriteGameMan.Add(SpriteGame.Name.Wall, Image.Name.Wall, 448, 900, 850, 30);
                  
            SpriteGameMan.Add(SpriteGame.Name.BombZigZag, Image.Name.BombZigZag, 200, 200, 20, 60);
            SpriteGameMan.Add(SpriteGame.Name.BombStraight, Image.Name.BombStraight, 100, 100, 5, 50);
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

            //---------------------------------------------------------------------------------------------------------
            // Create SpriteBatch
            //---------------------------------------------------------------------------------------------------------
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.Birds);
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

            GameObjectNodeMan.Attach(pBombRoot);

            //---------------------------------------------------------------------------------------------------------
            // Walls
            //---------------------------------------------------------------------------------------------------------

            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Birds);

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, SpriteGame.Name.NullObject, 400, 770, 700, 30);
            pWallTop.ActivateCollisionSprite(pSB_Birds);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, SpriteGame.Name.Wall, 448, 50, 850, 30);
            pWallBottom.ActivateCollisionSprite(pSB_Box);
            pWallBottom.ActivateSprite(pSB_Birds);

            // Add to the composite the children
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);

            GameObjectNodeMan.Attach(pWallGroup);

            //---------------------------------------------------------------------------------------------------------
            // Missile
            //---------------------------------------------------------------------------------------------------------

            // Missile Root
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

            GameObject pShieldRoot = ShieldFactory.CreateSingleShield();

            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPair pColPair;
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            Debug.Assert(pColPair != null);

            // Missile Wall a collision pair
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());

            // Bomb vs Bottom
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            pColPair.Attach(new RemoveBombObserver());

            // Bomb vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            // Missile vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Misslie_Shield, pMissileGroup, pShieldRoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver());

        }




        bool lastKeyE = false;

        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputMan.Update();


            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_E) == true && lastKeyE == false)
            {
                GhostMan.Dump();
                GameObject pShieldRoot = ShieldFactory.CreateSingleShield();
                GhostMan.Dump();

            }
            lastKeyE = Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_E);




            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

                // Do the collision checks
                ColPairMan.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeMan.Update();

                // Delete any objects here...
                DelayedObjectMan.Process();
            }
        }
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }
        public override void Transition()
        {
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
    }
}

// --- End of File ---
