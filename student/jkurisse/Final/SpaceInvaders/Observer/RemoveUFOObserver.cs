using System;
using System.Diagnostics;
using System.Linq;

namespace SE456
{
    public class RemoveUFOObserver : ColObserver
    {
        public RemoveUFOObserver()
        {
            this.pUFO = null;
            this.random = new Random();
        }

        public RemoveUFOObserver(RemoveUFOObserver m)
        {
            Debug.Assert(m.pUFO != null);
            this.pUFO = m.pUFO;
        }

        public override void Notify()
        {

            this.pUFO = (UFO)this.pSubject.pObjA;
            if (this.pSubject.pObjB.name == GameObject.Name.Missile)
            {
                int score = this.random.Next(50, 350);
                int number;
                int hiscore;
                string message;
                if (score < 100) { score = 50; }
                else if (score < 150) { score = 100; }
                else if (score < 200) { score = 150; }
                else if (score < 300) { score = 200; }
                else if (score <= 350) { score = 300; }

                Int32.TryParse(FontMan.Find(Font.Name.P1Score).GetMessage().Replace(" ", ""), out number);
                Int32.TryParse(FontMan.Find(Font.Name.Year).GetMessage().Replace(" ", ""), out hiscore);
                number += score;

                if (number > hiscore)
                {
                    hiscore = number;
                    message = $"{hiscore}";
                    message = string.Join(" ", message.Select(c => c.ToString()));
                    FontMan.Find(Font.Name.Year).UpdateMessage(message);
                }

                message = $"{number}";
                message = string.Join(" ", message.Select(c => c.ToString()));
                FontMan.Find(Font.Name.P1Score).UpdateMessage(message);
            }

            if (pUFO.bMarkForDeath == false)
            {
                pUFO.bMarkForDeath = true;

                // Delay - remove object later
                // TODO - reduce the new functions
                RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
                DelayedObjectMan.Attach(pObserver);
                ((UFO)this.pUFO).SpawnHandle();
                ((UFO)this.pUFO).removed = true;
            }
        }

        public override void Execute()
        {
            GameObject pA = (GameObject)this.pUFO;
            pA.Remove();

        }

        private bool privCheckParent(GameObject pObj)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(pObj);
            if (pGameObj == null)
            {
                return true;
            }

            return false;
        }


        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.RemoveUFOObserver;
        }

        // --------------------------
        // Data
        // --------------------------
        private GameObject pUFO;
        private Random random;
    }
}

// --- End of File ---
