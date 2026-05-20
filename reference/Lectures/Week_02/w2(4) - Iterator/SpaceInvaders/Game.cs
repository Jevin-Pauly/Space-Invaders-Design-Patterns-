//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class SpaceInvaders : Azul.Game
    {

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("w2(4) - Iterator");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            Debug.WriteLine("\n");

            Debug.WriteLine("--------------------------");
            Debug.WriteLine("   1) Add To Front        ");
            Debug.WriteLine("--------------------------");
            {
                DLinkMan pActive = new DLinkMan();
                DLinkMan pReserve = new DLinkMan();
                Manager pMan = new Manager(pActive, pReserve, 0, 2);

                pMan.Dump();

                Node pBird = pMan.Add(Node.Name.Bird, 55);

                pMan.Dump();

                Node pCat = pMan.Add(Node.Name.Cat, 66);

                pMan.Dump();

                Node pDog = pMan.Add(Node.Name.Dog, 77);

                pMan.Dump();

                Node pFish = pMan.Add(Node.Name.Fish, 88);

                pMan.Dump();
            }


            Debug.WriteLine("-----------------------------");
            Debug.WriteLine("   2) Remove Test ");
            Debug.WriteLine("-----------------------------");
            {
                DLinkMan pActive = new DLinkMan();
                DLinkMan pReserve = new DLinkMan();
                Manager pMan = new Manager(pActive, pReserve, 0, 2);

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   2a) original ");
                Debug.WriteLine("-----------------------------");
                Node pBird = pMan.Add(Node.Name.Bird, 55);
                Node pCat = pMan.Add(Node.Name.Cat, 66);
                Node pDog = pMan.Add(Node.Name.Dog, 77);
                Node pFish = pMan.Add(Node.Name.Fish, 88);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   2b) Remove middle: Dog ");
                Debug.WriteLine("-----------------------------");
                pMan.Remove(pDog);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   2c) Remove end: Bird ");
                Debug.WriteLine("-----------------------------");
                pMan.Remove(pBird);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   2d) Remove first: Fish ");
                Debug.WriteLine("-----------------------------");
                pMan.Remove(pFish);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   2e) Remove only: Cat ");
                Debug.WriteLine("-----------------------------");
                pMan.Remove(pCat);
                pMan.Dump();
            }


            Debug.WriteLine("-----------------------------");
            Debug.WriteLine("   3) Memory Pooling         ");
            Debug.WriteLine("-----------------------------");
            {
                DLinkMan pActive = new DLinkMan();
                DLinkMan pReserve = new DLinkMan();
                Manager pMan = new Manager(pActive, pReserve, 3, 2);

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3a) original ");
                Debug.WriteLine("-----------------------------");
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3b) Add 1st node ");
                Debug.WriteLine("-----------------------------");
                Node pBird = pMan.Add(Node.Name.Bird, 55);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3c) Add 2nd node ");
                Debug.WriteLine("-----------------------------");
                Node pCat = pMan.Add(Node.Name.Cat, 66);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3d) Add 3rd node ");
                Debug.WriteLine("-----------------------------");
                Node pDog = pMan.Add(Node.Name.Dog, 77);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3e) Add 4th node ");
                Debug.WriteLine("-----------------------------");
                Node pFish = pMan.Add(Node.Name.Fish, 88);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3f) Remove node ");
                Debug.WriteLine("-----------------------------");
                pMan.Remove(pCat);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3g) Remove node ");
                Debug.WriteLine("-----------------------------");
                pMan.Remove(pBird);
                pMan.Dump();
                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   3h) add node ");
                Debug.WriteLine("-----------------------------");
                pMan.Add(Node.Name.Worm, 123);
                pMan.Dump();
            }

            Debug.WriteLine("-----------------------------");
            Debug.WriteLine("   4) Find                  ");
            Debug.WriteLine("-----------------------------");
            {
                DLinkMan pActive = new DLinkMan();
                DLinkMan pReserve = new DLinkMan();
                Manager pMan = new Manager(pActive, pReserve, 3, 2);

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   4a) original ");
                Debug.WriteLine("-----------------------------");

                Node pBird = pMan.Add(Node.Name.Bird, 55);
                Node pCat = pMan.Add(Node.Name.Cat, 66);
                Node pDog = pMan.Add(Node.Name.Dog, 77);
                Node pFish = pMan.Add(Node.Name.Fish, 88);
                pMan.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   4b) Find (Dog) ");
                Debug.WriteLine("-----------------------------");
                Node pNode = pMan.Find(Node.Name.Dog);
                Debug.WriteLine(" Found Node:");
                pNode.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   4c) Find (Fish) ");
                Debug.WriteLine("-----------------------------");
                Node pNode2 = pMan.Find(Node.Name.Fish);
                Debug.WriteLine(" Found Node:");
                pNode2.Dump();

                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("   4d) Find (Worm) ");
                Debug.WriteLine("-----------------------------");
                Node pNode3 = pMan.Find(Node.Name.Worm);
                Debug.WriteLine(" Found _NOT_ Node:");
                Debug.Assert(pNode3 == null);

            }


        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {


        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {

        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }


        public override void DisplayHeader()
        {
            Console.Write(this.Header());
        }

        public override void DisplayFooter()
        {
            Console.Write(this.Footer());
        }

    }
}

// --- End of File ---
