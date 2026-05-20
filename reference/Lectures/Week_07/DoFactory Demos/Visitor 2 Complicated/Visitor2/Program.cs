using System;
using System.Diagnostics;

namespace Visitor2
{
    class Program
    {
        static void Main(string[] args)
        {
            Alien a1 = new Alien();
            Missile m1 = new Missile();
            // Bang add more types of objects
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

            // Wait for user

           // Console.ReadKey();
        }
    }

    interface ICollidable
    {
        void Accept(IVisitor other);
    }

    interface IVisitor
    {
        void VisitAlien(Alien a);
        void VisitMissile(Missile m);
        void VisitUFO(UFO u);
        void VisitBomb(Bomb b);
        void VisitShield(Shield s);
    }

    class Shield : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Shield] ");
            // Important: at this point we have an Shield
            // Call the appropriate collision reaction
            other.VisitShield(this);
        }
        // Bang explosion: now needs 5 methods
        public void VisitShield(Shield s)
        {
            Debug.WriteLine("Collided with Shield");
        }

        public void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with Shield");
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Shield");
        }

        public void VisitUFO(UFO u)
        {
            Debug.WriteLine("Collided with Shield");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Shield");
        }
    }

    class Bomb : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Bomb] ");
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.VisitBomb(this);
        }

        public void VisitShield(Shield b)
        {
            Debug.WriteLine("Collided with Bomb");
        }

        public void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with Bomb");
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Bomb");
        }

        public void VisitUFO(UFO u)
        {
            Debug.WriteLine("Collided with Bomb");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Bomb");
        }
    }


    class Alien : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Alien] ");
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction
            other.VisitAlien(this);
        }

        public void VisitShield(Shield s)
        {
            Debug.WriteLine("Collided with Alien");
        }

        public void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with Alien");
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Alien");
        }

        public void VisitUFO(UFO u)
        {
            Debug.WriteLine("Collided with Alien");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Alien");
        }
    }


    class UFO : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[UFO] ");
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction
            other.VisitUFO(this);
        }

        public void VisitShield(Shield b)
        {
            Debug.WriteLine("Collided with UFO");
        }

        public void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with UFO");
        }

        public void VisitUFO(UFO u)
        {
            Debug.WriteLine("Collided with UFO");
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with UFO");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with UFO");
        }
    }

    class Missile : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Missile] ");
            other.VisitMissile(this);
        }

        public void VisitShield(Shield s)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public void VisitBomb(Bomb b)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public void VisitUFO(UFO u)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Missile");
        }
    }


}



