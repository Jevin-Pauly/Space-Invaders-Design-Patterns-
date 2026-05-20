using System;
using System.Diagnostics;

namespace SE456
{
    public class UFOMan
    {
        public enum State 
        {
            UFOReady,
            UFOFlying,

            Dead
        }

        private UFOMan()
        {
            // Store the states
            this.pStateReady = new StateReady();
            this.pStateUFOFlying = new StateFlying();
            this.pStateDead = new StateDead();

            // set active
            this.pUFORightMoving = null;
            this.pUFOLeftMoving = null;
        }

        public static void Create()
        {
            // make sure its the first time
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new UFOMan();
            }

            Debug.Assert(instance != null);

            // Stuff to initialize after the instance was created
            instance.pUFOLeftMoving = ActivateUFOLeftMoving();
            instance.pUFOLeftMoving.SetSpawnState(UFOMan.State.UFOReady);
            // Removed on creation from root because of duplication issues (stupid hack)
            instance.pUFOLeftMoving.Remove();
            instance.pUFORightMoving = ActivateUFORightMoving();
            instance.pUFORightMoving.SetSpawnState(UFOMan.State.UFOReady);
            // Removed on creation from root because of duplication issues (stupid hack)
            instance.pUFORightMoving.Remove();
        }

        private static UFOMan privInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static UFO GetUFOLeftMoving()
        {
            UFOMan pMan = UFOMan.privInstance();

            Debug.Assert(pMan != null);
            Debug.Assert(pMan.pUFOLeftMoving != null);

            return pMan.pUFOLeftMoving;
        }

        public static UFO GetUFORightMoving()
        {
            UFOMan pMan = UFOMan.privInstance();

            Debug.Assert(pMan != null);
            Debug.Assert(pMan.pUFORightMoving != null);

            return pMan.pUFORightMoving;
        }

        public static UFOSpawnState GetState(State state)
        {
            UFOMan pMan = UFOMan.privInstance();
            Debug.Assert(pMan != null);

            UFOSpawnState pSpawnState = null;

            switch (state)
            {
                case UFOMan.State.UFOReady:
                    pSpawnState = pMan.pStateReady;
                    break;

                case UFOMan.State.UFOFlying:
                    pSpawnState = pMan.pStateUFOFlying;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pSpawnState;
        }

        public static UFO ActivateUFOLeftMoving()
        {
            UFOMan pMan = UFOMan.privInstance();
            Debug.Assert(pMan != null);

            UFO pUFO = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.UFOLeft);
            if (pGameObjNode == null)
            {
                pUFO = new UFO(GameObject.Name.UFOLeft, SpriteGame.Name.UFO, new MoveUFOLeft(), -24.0f, -24.0f);
            }
            else
            {
                // Recycle it.
                pUFO = (UFO)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                pUFO.Resurrect(400, 100);
            }
            pMan.pUFOLeftMoving = pUFO;
            pMan.SpriteAttach(pUFO);

            UFORoot pUFORoot = (UFORoot)GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            Debug.Assert(pUFORoot != null);

            pUFORoot.Add((Component)pMan.pUFOLeftMoving);

            return pMan.pUFOLeftMoving;
        }

        public static UFO ActivateUFORightMoving()
        {
            UFOMan pMan = UFOMan.privInstance();
            Debug.Assert(pMan != null);

            UFO pUFO = null;

            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.UFORight);
            if (pGameObjNode == null)
            {
                pUFO = new UFO(GameObject.Name.UFORight, SpriteGame.Name.UFO, new MoveUFORight(), 660.0f, -24.0f);
            }
            else
            {
                // Recycle it.
                pUFO = (UFO)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                pUFO.Resurrect(400, 100);
            }
            pMan.pUFORightMoving = pUFO;        
            pMan.SpriteAttach(pUFO);
        
            UFORoot pUFORoot = (UFORoot)GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            Debug.Assert(pUFORoot != null);
        
            pUFORoot.Add((Component)pMan.pUFORightMoving);
        
            return pMan.pUFORightMoving;
        }

        private void SpriteAttach(UFO pUFO)
        {
            SpriteBatch pSB_UFO = SpriteBatchMan.Find(SpriteBatch.Name.UFO);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            pUFO.ActivateCollisionSprite(pSB_Boxes);
            pUFO.ActivateSprite(pSB_UFO);
        }


        public static void Update()
        {
            UFOMan pMan = UFOMan.privInstance();
            Debug.Assert(pMan != null);
            if (pMan.Running)
            {
                if (pMan.pUFOLeftMoving.removed && pMan.pUFORightMoving.removed)
                {
                    if (pMan.newUFOtimecheck == 0)
                    {
                        pMan.newUFOtimecheck = (int)pMan.GetRandomSpawnInterval(1300, 2500);
                    }
                    else
                    {
                        pMan.newUFOtimecheck--;
                        if (pMan.newUFOtimecheck == 0)
                        {
                            int choice = pMan.random.Next(2);
                            if (choice == 0)
                            {
                                UFO pUFOLeft = UFOMan.GetUFOLeftMoving();
                                pUFOLeft.SpawnUFOLeftMoving();
                            }
                            else
                            {
                                UFO pUFORight = UFOMan.GetUFORightMoving();
                                pUFORight.SpawnUFORightMoving();
                            }
                        }
                    }
                }
            }
        }

        public static void ResetTimer()
        {
            UFOMan pMan = UFOMan.privInstance();
            Debug.Assert(pMan != null);

            pMan.newUFOtimecheck = 0;
            pMan.Running = true;
        }

        public static void Stop()
        {
            UFOMan pMan = UFOMan.privInstance();
            Debug.Assert(pMan != null);

            pMan.Running = false;
        }


        private float GetRandomSpawnInterval(int min, int max)
        {
            return random.Next(min, max);
        }

        // Data: ----------------------------------------------
        private static UFOMan instance = null;
        private UFO pUFORightMoving;
        private UFO pUFOLeftMoving;
        private int newUFOtimecheck;
        private int choice = 0;
        private Random random = new Random();

        private StateReady pStateReady;
        private StateFlying pStateUFOFlying;
        private readonly StateDead pStateDead;
        private bool Running = true;

    }
}

// --- End of File ---