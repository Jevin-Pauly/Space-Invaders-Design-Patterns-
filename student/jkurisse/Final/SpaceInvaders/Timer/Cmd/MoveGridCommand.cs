using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SE456
{
    public class MoveGridCommand : Command
    {
        public MoveGridCommand(GameObject pAlienRoot)
        {
            
            this.grid = (AlienGrid)IteratorForwardComposite.GetChild(pAlienRoot);
            //this.grid = (AlienGrid)grid;
            Debug.Assert(this.grid != null);
            this.AliensCount = 0;

            pSndEngine = new IrrKlang.ISoundEngine();
            pSndEngine.AddSoundSourceFromFile("fastinvader1.wav");
            pSndEngine.AddSoundSourceFromFile("fastinvader2.wav");
            pSndEngine.AddSoundSourceFromFile("fastinvader3.wav");
            pSndEngine.AddSoundSourceFromFile("fastinvader4.wav");
            pSndEngine.SoundVolume = 0.2f;


            //new SndObserver(sndEngine, pSndVader0);
            //this.direction = 1.0f;
            //this.xMax = 336.0f + 50;
            //this.xMin = 336.0f - 50;
            //this.totalMovement = 0;

        }

        public override void Execute(float deltaTime, bool move)
        {
            if (marchCount == 1)
            {
                pSndVader = pSndEngine.GetSoundSource("fastinvader1.wav");
                pSndEngine.Play2D(pSndVader, false, false, false);
                FontMan.Find(Font.Name.WaveNum).UpdateMessage("1 - W A V");
                marchCount++;
            }
            else if (marchCount == 2)
            {
                pSndVader = pSndEngine.GetSoundSource("fastinvader2.wav");
                pSndEngine.Play2D(pSndVader, false, false, false);
                FontMan.Find(Font.Name.WaveNum).UpdateMessage("2 - W A V");
                marchCount++;
            }
            else if (marchCount == 3)
            {
                pSndVader = pSndEngine.GetSoundSource("fastinvader3.wav");
                pSndEngine.Play2D(pSndVader, false, false, false);
                FontMan.Find(Font.Name.WaveNum).UpdateMessage("3 - W A V");
                marchCount++;
            }
            else
            {
                pSndVader = pSndEngine.GetSoundSource("fastinvader4.wav");
                pSndEngine.Play2D(pSndVader, false, false, false);
                FontMan.Find(Font.Name.WaveNum).UpdateMessage("4 - W A V");
                marchCount = 1;
            }

            if (move)
            {
                this.grid.MoveGrid(AliensCount);
            }

        }

        public override void Reset()
        {
            marchCount = 1;
        }

        private readonly AlienGrid grid;


        private IrrKlang.ISoundEngine pSndEngine;
        private int marchCount = 1;
        private IrrKlang.ISoundSource pSndVader;
        private int number;
        private string message;

        public int AliensCount;
    }
}
