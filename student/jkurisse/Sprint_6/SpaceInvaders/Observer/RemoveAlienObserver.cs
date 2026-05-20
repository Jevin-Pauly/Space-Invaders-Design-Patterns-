using System;
using System.Diagnostics;

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

            }
        }

        public override void Execute()
        {
            // Let the gameObject deal with this... 
            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)IteratorForwardComposite.GetParent(pA);

            pA.Remove();
            this.pAnimation.AliensCount++;
            this.pMovement.AliensCount++;
            // TODO: Need a better way... 
            if (privCheckParent(pB) == true)
            {
                GameObject pC = (GameObject)IteratorForwardComposite.GetParent(pB);
                pB.Remove();

                if (privCheckParent(pC) == true)
                {
                    pC.Remove();
                }
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