using System;
using System.Diagnostics;

namespace SE456
{
    public class AlienRoot : Composite
    {
        public AlienRoot(GameObject.Name name, SpriteGame.Name spriteName)
            : base(name, spriteName)
        {
        }
        ~AlienRoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.Visit(this);
        }
        public override void Visit(MissileGroup m)
        {
            // MissileRoot vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            if (pGameObj != null)
            {
                ColPair.Collide(pGameObj, this);
            }
        }
        public override void Visit(Missile m)
        {
            // Missile vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            if (pGameObj != null)
            {
                ColPair.Collide(m, pGameObj);
            }
            
        }

        public override void Visit(ShieldRoot s)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(s);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(ShieldGrid s)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(s);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(ShieldColumn s)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(s);
            ColPair.Collide(pGameObj, this);
        }

        public override void Visit(ShieldBrick s)
        {
            // Alien vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            if (pGameObj != null)
            {
                ColPair.Collide(s, pGameObj);
            }
        }


        public AlienGrid GetAlienGrid()
        {
            return (AlienGrid)IteratorForwardComposite.GetChild(this);
        }
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------

        public int globalAlienDeath = 0;
    }
}

// --- End of File ---
