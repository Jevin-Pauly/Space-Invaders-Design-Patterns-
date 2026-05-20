using System;
using System.Diagnostics;

namespace SE456
{
    class TimedSpriteCmd : Command
    {
        public TimedSpriteCmd(SpriteGame.Name name, SpriteBatch batchName, float xPos, float yPos, float _red, float _green, float _blue)
        {
            this.x = xPos;
            this.y = yPos;
            this.red = _red;
            this.green = _green;
            this.blue = _blue;
            this.name = name;
            this.batchName = batchName;

            //if (this.pCmd_old != null)
            //{
            //    Debug.WriteLine(" {0}  old:{1}", this.GetHashCode(), this.pCmd_old.GetHashCode());
            //}
            //else
            //{
            //    Debug.WriteLine(" {0}  old:{1}", this.GetHashCode(), "null");
            //
            //}
        }
        override public void Execute(float deltaTime, bool check)
        {
            //Debug.WriteLine("\nexec start: {0} ", this.GetHashCode());


            // Get rid of the old one 
            //if (this.pCmd_old != null)
            //{
            //    Debug.WriteLine("{0} remove this one", this.pCmd_old.GetHashCode());
            //    FontMan.Remove(this.pCmd_old.poFont);
            //}


            //SpriteGameMan.Add(SpriteGame.Name.Octopus, Image.Name.OctopusA, 0, 0, 36, 25);

            SpriteGameProxy newAlien = SpriteGameProxyMan.Add(name);
            newAlien.x = x;
            newAlien.y = y;
            batchName.Attach(newAlien);
            // New one
            //Font pFont = FontMan.Add(Font.Name.TimedCharacter,
            //                         SpriteBatch.Name.Texts,
            //                         this.pLetter,
            //                         Glyph.Name.Aliens,
            //                         this.x,
            //                         this.y);

            //pFont.SetColor(red, green, blue);


            //this.poFont = pFont;

            //Debug.WriteLine("exec exit: {0} this.poFont: {1}", this.GetHashCode(), this.poFont.GetHashCode());
        }

        // --------------------------------------
        // Data: 
        // --------------------------------------
        private float x;
        private float y;
        private float red;
        private float green;
        private float blue;
        private SpriteGame.Name name;
        private SpriteBatch batchName;
    }
}

// --- End of File ---
