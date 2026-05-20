using System;
using System.Diagnostics;

namespace SE456
{
    public class UFORoot : Composite
    {
        public UFORoot(GameObject.Name name, SpriteGame.Name spriteName)
            : base(name, spriteName)
        {
            this.poColObj.pColSprite.SetColor(1, 1, 1);
        }

        ~UFORoot()
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
            // MissileRoot vs WallTop
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void Visit(Missile m)
        {
            // Missile vs WallTop
            //Debug.WriteLine(" ---> Done");
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }



        // Data: ---------------


    }
}

// --- End of File ---
