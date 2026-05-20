//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace SE456
{
    public class SpaceInvaders : Azul.Game
    {

        SceneContext pSceneContext = null;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Final");
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

            Simulation.Create();
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
            GhostMan.Create();

            
            pSceneContext = new SceneContext();

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
            
            GlobalTimer.Update(this.GetTime());

            // Hack to proof of concept... 
            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_1) == true || Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_Q) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.Select);
            }

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_2) || Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_E) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.Play);
            }

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_3) == true || SpriteGameMan.GameOver)
            {
                pSceneContext.SetState(SceneContext.Scene.Over);
                SpriteGameMan.GameOver = false;
            }

            // Update the scene
            pSceneContext.GetState().Update(this.GetTime());

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_T) == true)
            {
                SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(pSB != null);
                pSB.Enable();
            }

            if (Azul.Keyboard.KeyPressed(Azul.AZUL_KEY.KEY_Y) == true)
            {
                SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(pSB != null);
                pSB.Disable();
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
            //SpriteBatchMan.Draw();
            pSceneContext.GetState().Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            GhostMan.Destroy();
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
