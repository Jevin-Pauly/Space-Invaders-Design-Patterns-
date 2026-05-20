
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SE456
{
    public class SceneSelect : SceneState
    {
        public SceneSelect()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            Debug.WriteLine("Handle");
        }
        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poColPairMan = new ColPairMan();
            ColPairMan.SetActive(this.poColPairMan);

            this.poFontMan = new FontMan(3, 1);
            FontMan.SetActive(this.poFontMan);

            this.poTimerMan = new TimerEventMan(3, 1);
            TimerEventMan.SetActive(this.poTimerMan);

            this.poGOBMan = new GameObjectNodeMan(3, 1);
            GameObjectNodeMan.SetActive(this.poGOBMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);            

            this.FirstTime = true;

            //TextureMan.Add(Texture.Name.Consolas36pt, "consolas36pt.t.azul");
            //GlyphMan.AddXml("Consolas36pt.xml", Glyph.Name.Consolas36pt, Texture.Name.Consolas36pt);


            //Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "Attract Mode", Glyph.Name.Consolas36pt, 100, 500);
            //pFont.SetColor(0.10f, 0.10f, 0.10f);
        }


        private void LoadOnEntry()
        {
            SpriteBatch pSB_AlienSelect = SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
            //Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "A T T R A C T  M O D E", Glyph.Name.Aliens, 250, 700);
            //pFont.SetColor(0.90f, 0.90f, 0.90f);
            FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, "S C O R E < 1 >", Glyph.Name.Aliens, 26, 740);
            FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, "S C O R E < 2 >", Glyph.Name.Aliens, 503, 740);
            FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, "H I - S C O R E", Glyph.Name.Aliens, 265, 740);

            FontMan.Add(Font.Name.WaveNum, SpriteBatch.Name.Texts, "0 0 0 0", Glyph.Name.Aliens, 52, 700);
            FontMan.Add(Font.Name.Year, SpriteBatch.Name.Texts, SpriteGameMan.GetHiScore(), Glyph.Name.Aliens, 300, 700);
            FontMan.Add(Font.Name.P1Score, SpriteBatch.Name.Texts, "0 0 0 0", Glyph.Name.Aliens, 530, 700);


            TimedCharacterFactory.Install("P L A Y", 2.0f, 0.10f, 300, 600, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("S P A C E        I N V A D E R S", 3.0f, 0.05f, 220, 550, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("*S C O R E       A D V A N C E      T A B L E*", 5.0f, 0.05f, 160, 450, 0.9f, 0.9f, 0.9f);

            TimedCharacterFactory.Install(SpriteGame.Name.UFO, pSB_AlienSelect, 8.0f, 0.00f, 250, 400, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("=    ?     M Y S T E R Y", 8.0f, 0.0f, 280, 400, 0.9f, 0.9f, 0.9f);

            TimedCharacterFactory.Install(SpriteGame.Name.Squid, pSB_AlienSelect, 9.0f, 0.0f, 250, 350, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("=    3 0    P O I N T S", 9.0f, 0.0f, 280, 350, 0.9f, 0.9f, 0.9f);

            TimedCharacterFactory.Install(SpriteGame.Name.Crab, pSB_AlienSelect, 10.0f, 0.0f, 250, 300, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("=    2 0    P O I N T S", 10.0f, 0.0f, 280, 300, 0.9f, 0.9f, 0.9f);

            TimedCharacterFactory.Install(SpriteGame.Name.Octopus, pSB_AlienSelect, 11.0f, 0.0f, 250, 250, 0.2f, 0.8f, 0.2f);
            TimedCharacterFactory.Install("=    1 0    P O I N T S", 11.0f, 0.0f, 280, 250, 0.2f, 0.8f, 0.2f);

            TimedCharacterFactory.Install("P R E S S        E       T O     S T A R T", 12.0f, 0.05f, 205, 180, 0.8f, 0.2f, 0.2f);

            FontMan.Add(Font.Name.Credit, SpriteBatch.Name.Texts, "C R E D I T", Glyph.Name.Aliens, 485, 30);
            FontMan.Add(Font.Name.CreditNum, SpriteBatch.Name.Texts, "0 0", Glyph.Name.Aliens, 608, 30);

        }


        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

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
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            ColPairMan.SetActive(this.poColPairMan);
            TimerEventMan.SetActive(this.poTimerMan);
            GameObjectNodeMan.SetActive(this.poGOBMan);

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);                                                 

            if (this.FirstTime)
            {
                this.LoadOnEntry();
                this.FirstTime = false;
            }
            else
            {
                FontMan.Find(Font.Name.Year).UpdateMessage(SpriteGameMan.GetHiScore());
            }
        }
        public override void Leaving()
        {
            // update SpriteBatchMan()
            this.TimeAtPause = TimerEventMan.GetCurrTime();
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public bool FirstTime;
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;
        public GameObjectNodeMan poGOBMan;
        public ColPairMan poColPairMan;
        public TimerEventMan poTimerMan;
        
    }
}
// --- End of File ---
