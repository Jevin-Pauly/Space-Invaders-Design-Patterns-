//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System.Diagnostics;

namespace SE456
{
    public class SceneOver : SceneState
    {
        public SceneOver()
        {
            this.Initialize();
        }
        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            TextureMan.Add(Texture.Name.Consolas36pt, "consolas36pt.t.azul");
            GlyphMan.AddXml("Consolas36pt.xml", Glyph.Name.Consolas36pt, Texture.Name.Consolas36pt);

            Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "Game OVER", Glyph.Name.Consolas36pt, 100, 500);
            pFont.SetColor(0.10f, 0.10f, 0.50f);
        }
        public override void Update(float systemTime)
        {
                // walk through all objects and push to flyweight
                GameObjectNodeMan.Update();
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
