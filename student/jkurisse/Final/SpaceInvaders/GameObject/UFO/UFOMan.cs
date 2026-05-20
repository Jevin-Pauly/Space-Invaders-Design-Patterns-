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

            instance.pUFORightMoving = ActivateUFORightMoving();
            instance.pUFORightMoving.SetSpawnState(UFOMan.State.UFOReady);
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

            UFO pUFO = new UFO(GameObject.Name.UFO, SpriteGame.Name.UFO, new MoveUFOLeft(), -24.0f, -24.0f);
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

            UFO pUFO = new UFO(GameObject.Name.UFO, SpriteGame.Name.UFO, new MoveUFORight(), 660.0f, -24.0f);
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
            pMan.newUFOtimecheck += 1;

            UFO pUFOLeft = UFOMan.GetUFOLeftMoving();
            UFO pUFORight = UFOMan.GetUFORightMoving();

            if (pMan.newUFOtimecheck >= 500)
            {
                if (pMan.newUFOtimecheck >= pMan.GetRandomSpawnInterval(400, 900))
                {
                    int choice = pMan.random.Next(2);

                    if (choice == 0)
                        pUFOLeft.SpawnUFOLeftMoving();
                    else
                        pUFORight.SpawnUFORightMoving();
                }
                pMan.newUFOtimecheck -= 500;
            }
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

        private Random random = new Random();

        private StateReady pStateReady;
        private StateFlying pStateUFOFlying;
        private readonly StateDead pStateDead;

    }
}

// --- End of File ---