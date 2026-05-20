using System;
using System.Diagnostics;
using System.Linq;

namespace SE456
{
    public class RemoveAlienObserver : ColObserver
    {
        public RemoveAlienObserver(SpriteAnimationManager anim, MoveGridCommand move)
        {
            this.pAlien = null;
            this.pAnimation = anim;
            this.pMovement = move;
        }

        public RemoveAlienObserver(RemoveAlienObserver a)
        {
            Debug.Assert(a != null);
            this.pAlien = a.pAlien;
            this.pAnimation = a.pAnimation;
            this.pMovement = a.pMovement;
        }
        override public void Notify()
        {
            //Debug.WriteLine(" Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // OK do some magic
            this.pAlien = (AlienCategory)this.pSubject.pObjB;
            Debug.Assert(this.pAlien != null);

            if (pAlien.bMarkForDeath == false)
            {
                pAlien.bMarkForDeath = true;
                //   Delay
                RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
                DelayedObjectMan.Attach(pObserver);

                int number;
                int hiscore;

                Int32.TryParse(FontMan.Find(Font.Name.P1Score).GetMessage().Replace(" ", ""), out number);
                Int32.TryParse(FontMan.Find(Font.Name.Year).GetMessage().Replace(" ", ""), out hiscore);

                string message;
                //string hiscore;

                if (this.pAlien.spriteName == SpriteGame.Name.Octopus)
                {
                    number += 10;
                }
                else if (this.pAlien.spriteName == SpriteGame.Name.Crab)
                {
                    number += 20;
                }
                else if (this.pAlien.spriteName == SpriteGame.Name.Squid)
                {
                    number += 30;
                }

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
        }

        public override void Execute()
        {
            // Let the gameObject deal with this... 
            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)IteratorForwardComposite.GetParent(pA);
            GameObject pC = (GameObject)IteratorForwardComposite.GetParent(pB);
            this.pAnimation.AliensCount++;
            this.pMovement.AliensCount++;
            

            // Alien
            if (pA.GetNumChildren() == 0)
            {
                pA.Remove();
            }

            // Column 
            if (pB.GetNumChildren() == 0)
            {
                pB.Remove();
            }

            // Grid 
            if (pC.GetNumChildren() == 0)
            {
                pC.Remove();
            }
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
            return Name.RemoveAlienObserver;
        }



        private GameObject pAlien;
        public SpriteAnimationManager pAnimation;
        public MoveGridCommand pMovement;
    }
}

// --- End of File ---