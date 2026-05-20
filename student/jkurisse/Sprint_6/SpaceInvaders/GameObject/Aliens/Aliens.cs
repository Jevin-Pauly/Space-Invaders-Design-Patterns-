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
        public Aliens(SpriteGame.Name spriteName, GameObject.Name name, float posX, float posY)
        : base(name, spriteName, posX, posY, AlienCategory.Type.Aliens)
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an YellowBird
            // Call the appropriate collision reaction            
            other.Visit(this);
        }

        public override void Visit(MissileGroup m)
        {
            // BirdColumn vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Visit(Missile m)
        {
            // Bird vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Alien
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
            m.x = 0;
            m.y = 0;
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
