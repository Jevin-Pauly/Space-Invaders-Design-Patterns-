using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Visitor2
{
    class Program
    {
        static void Main(string[] args)
        {
            Alien a1 = new Alien();
            Missile m1 = new Missile();
            UFO u1 = new UFO();
            Bomb b1 = new Bomb();
            Shield s1 = new Shield();


            // Missile vs Alien scenario

            // In your collide object, 
            //    You determine that Alien and Missile collided
            //    collide(gameObj p1, gameObj p2) is true
            //    now call the appropriate reactions

            // example case: Missile vs Alien
            Debug.Write("\n---- Missile vs Alien--------------\n");
            // Missile reacts to Alien
            m1.Accept(a1);
            // Alien reacts to Missile
            a1.Accept(m1);

            // example case: Missile vs Bomb
            Debug.Write("\n---- Missile vs Bomb --------------\n");
            m1.Accept(b1);
            b1.Accept(m1);

            // example case: Missile vs UFO
            Debug.Write("\n---- Missile vs UFO ---------------\n");
            m1.Accept(u1);
            u1.Accept(m1);

            // example case: Bomb vs Shield
            Debug.Write("\n---- Bomb vs Shield ---------------\n");
            b1.Accept(s1);
            s1.Accept(b1);

            // example case: Bomb vs Shield
            Debug.Write("\n ************ Impossible ******************");
            Debug.Write("\n---- UFO vs Shield ----------------\n");
            u1.Accept(s1);
            s1.Accept(u1);

            // Wait for user

           // Console.ReadKey();
        }
    }

    interface ICollidable
    {
        void Accept(IVisitor other);
    }
    //BANG - default implementation 
    class IVisitor
    {
        public virtual void VisitAlien(Alien a)
        {
            Debug.Write("Alien Visitor not implemented\n");
        }
        public virtual void VisitMissile(Missile m)
        {
            Debug.Write("Missile Visitor not implemented\n");
        }
        public virtual void VisitUFO(UFO u)
        {
            Debug.Write("UFO Visitor not implemented\n");
        }
        public virtual void VisitBomb(Bomb b)
        {
            Debug.Write("Bomb Visitor not implemented\n");
        }
        public virtual void VisitShield(Shield s)
        {
            Debug.Write("Shield Visitor not implemented\n");
        }
    }

    class Shield : IVisitor, ICollidable
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Shield] ");
            // Important: at this point we have an Shield
            // Call the appropriate collision reaction
            other.VisitShield(this);
        }

        //Bang - override with correctness
        public override void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with Shield");
        }

    }

    class Bomb : IVisitor, ICollidable
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Bomb] ");
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.VisitBomb(this);
        }

        public override void VisitShield(Shield b)
        {
            Debug.WriteLine("Collided with Bomb");
        }



        public override void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Bomb");
        }
    }


    class Alien : IVisitor, ICollidable
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Alien] ");
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction
            other.VisitAlien(this);
        }



        public override void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Alien");
        }
    }


    class UFO : IVisitor, ICollidable
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[UFO] ");
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction
            other.VisitUFO(this);
        }

        public override void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with UFO");
        }
    }

    class Missile : IVisitor, ICollidable
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Missile] ");
            other.VisitMissile(this);
        }


        public override void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public override void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public override void VisitUFO(UFO u)
        {
            Debug.WriteLine("Collided with Missile");
        }


    }


}



