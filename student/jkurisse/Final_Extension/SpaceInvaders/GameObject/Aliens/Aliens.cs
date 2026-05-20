using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class Aliens : AlienCategory
    {
        public Aliens(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
        : base(name, spriteName, posX, posY, AlienCategory.Type.Aliens)
        {
        }

        public void Resurrect(float posX, float posY, SpriteGame.Name name)
        {
            this.x = posX;
            this.y = posY;

            base.Resurrect(name);
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an YellowBird
            // Call the appropriate collision reaction            
            other.Visit(this);
        }

        public override void Visit(MissileGroup m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Visit(Missile m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Alien
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
            m.x = 0;
            m.y = 0;
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
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(s, this);
            pColPair.NotifyListeners();
            s.x = 0;
            s.y = 0;
        }

        public override void Update()
        {
            /*            this.y += 1.0f;
                        if (this.y > 600.0f)
                        {
                            this.y = 0.0f;
                        }
            */
            //Debug.WriteLine("crab");
            base.Update();
        }

        // Data: ---------------

    }
}
