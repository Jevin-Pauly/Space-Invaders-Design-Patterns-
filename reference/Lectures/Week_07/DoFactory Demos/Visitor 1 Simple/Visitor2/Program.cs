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


            // Missile vs Alien scenario

            // In your collide object, 
            //     You determine that Alien and Missile collided
            //     collide(gameObj p1, gameObj p2) is true
            //     now call the appropriate reactions

            // example case: Missile vs Alien
            Debug.Write("\n---- Missile vs Alien--------------\n");
            // Missile reacts to Alien
            m1.Accept(a1);
            // Alien reacts to Missile
            a1.Accept(m1);

            // Wait for user

            //Console.ReadKey();
        }
    }

    public interface ICollidable
    {
        void Accept(IVisitor other);
    }

    public interface IVisitor
    {
        void VisitAlien(Alien a);
        void VisitMissile(Missile m);
    }


    public class Alien : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Alien] ");
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction
            other.VisitAlien(this);
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Alien");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Alien");
        }
    }



    public class Missile : ICollidable, IVisitor
    {
        public void Accept(IVisitor other)
        {
            Debug.Write("[Missile] ");
            other.VisitMissile(this);
        }

        public void VisitAlien(Alien a)
        {
            Debug.WriteLine("Collided with Missile");
        }

        public void VisitMissile(Missile m)
        {
            Debug.WriteLine("Collided with Missile");
        }
    }


}



