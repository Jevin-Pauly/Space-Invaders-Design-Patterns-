
using System.Diagnostics;

namespace SE456
{
    public class SceneSelect : SceneState
    {
        public SceneSelect()
        {
            this.Initialize();
        }

        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poFontMan = new FontMan(3, 1);
            FontMan.SetActive(this.poFontMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            TextureMan.Add(Texture.Name.Consolas36pt, "consolas36pt.t.azul");
            GlyphMan.AddXml("Consolas36pt.xml", Glyph.Name.Consolas36pt, Texture.Name.Consolas36pt);
        }

        private void LoadOnEntry()
        {
            Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "Attract Mode", Glyph.Name.Consolas36pt, 250, 700);
            pFont.SetColor(0.90f, 0.90f, 0.90f);

            TimedCharacterFactory.Install("PLAY", 2.0f, 0.30f, 340, 500, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("SPACE  INVADERS", 4.0f, 0.10f, 230, 400, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= ? MYSTERY", 7.0f, 0.10f, 360, 300, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 30 POINTS", 10.0f, 0.10f, 360, 250, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 20 POINTS", 13.0f, 0.10f, 360, 200, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 10 POINTS", 16.0f, 0.10f, 360, 150, 0.2f, 0.8f, 0.2f);

        }

        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputMan.Update();

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

        public override void Entering()
        {
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);


            //  FontMan.Dump();
            //  TimerEventMan.Dump();


            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);


            this.LoadOnEntry();
        }
        public override void Leaving()
        {
            this.TimeAtPause = TimerEventMan.GetCurrTime();

    
           // FontMan.RemoveAll();

           // FontMan.Dump();
          //  TimerEventMan.Dump();
            
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;

    }
}

// --- End of File ---
