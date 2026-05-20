using System;
using System.Diagnostics;

namespace SE456
{
    class TempSpriteCmd : Command
    {
        public TempSpriteCmd(SpriteGame.Name name, SpriteBatch batchName, float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
            this.name = name;
            this.batchName = batchName;
            this.display = false;
        }
        override public void Execute(float deltaTime, bool check)
        {
            if(!this.display)
            {
                SpriteGameProxy deathSprite = SpriteGameProxyMan.Add(name);
                deathSprite.x = x;
                deathSprite.y = y;
                batchName.Attach(deathSprite);

                TimerEventMan.Add(TimerEvent.Name.Death, this, 1.0f);
            }
            else
            {
                SpriteGameProxy deathSprite = SpriteGameProxyMan.Find(name);
                SpriteGameProxyMan.Remove(deathSprite);
            }
            
        }

        // --------------------------------------
        // Data: 
        // --------------------------------------
        private float x;
        private float y;
        private SpriteGame.Name name;
        private SpriteBatch batchName;
        private bool display;
    }
}
