using System;
using System.Diagnostics;
using System.Linq;

namespace SE456
{
    public class RemoveLifeObserver : ColObserver
    {
        public RemoveLifeObserver()
        {
            this.pLife = null;
        }

        public RemoveLifeObserver(RemoveLifeObserver m)
        {
            Debug.Assert(m.pLife != null);
            this.pLife = m.pLife;
        }

        public override void Notify()
        {
            if (this.pSubject.pObjB.name == GameObject.Name.Ship)
            {
                this.pLife = pLifeRoot.GetLife();
                if (this.pLife != null) 
                {
                    if (pLife.bMarkForDeath == false)
                    {
                        pLife.bMarkForDeath = true;

                        // Delay - remove object later
                        // TODO - reduce the new functions
                        RemoveLifeObserver pObserver = new RemoveLifeObserver(this);
                        DelayedObjectMan.Attach(pObserver);
                    }
                }
                else
                {
                    SpriteGameMan.GameOver = true;
                }
            } 
        }

        public override void Execute()
        {
            GameObject pA = (GameObject)this.pLife;
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
        private Life pLife;
        private LifeRoot pLifeRoot = (LifeRoot)GameObjectNodeMan.Find(GameObject.Name.ShipLifeRoot);
    }
}

// --- End of File ---
