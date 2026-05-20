using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class Octopus : AlienCategory
    {
        public Octopus(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Octopus, spriteName, posX, posY, AlienCategory.Type.Aliens)
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
            // Bird vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Bird
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        //public override void Move(float _x, float _y)
        //{
        //    this.x += _x;
        //    this.y += _y;
        //}


        public override void Update()
        {
            /*            this.y += 1.0f;
                        if (this.y > 600.0f)
                        {
                            this.y = 0.0f;
                        }
            */
            //Debug.WriteLine("octopus");
            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
