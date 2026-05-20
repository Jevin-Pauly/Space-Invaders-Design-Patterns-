using System;
using System.Diagnostics;

namespace SE456
{
    class StateReady : UFOSpawnState
    {
        public override void Handle(UFO pUFO)
        {
            pUFO.SetSpawnState(UFOMan.State.UFOFlying);
        }

        public override void SpawnUFOLeftMoving(UFO pUFOIn)
        {
            UFO pUFO = UFOMan.GetUFOLeftMoving();

            if (pUFO.removed)
            {
                pUFO = UFOMan.ActivateUFOLeftMoving();
                pUFO.SetSpawnState(UFOMan.State.UFOReady);
            }

            pUFO.SetPos(696.0f, 660.0f);
            pUFO.SetActive(true);
            pUFO.SetSoundEngine(pUFOIn.sndEngine);
            // switch states
            //this.Handle(pUFO);
            pUFOIn.sndEngine.Play2D("ufo_highpitch.wav", true);
            pUFO.SpawnHandle();
        }

        public override void SpawnUFORightMoving(UFO pUFOIn)
        {
            UFO pUFO = UFOMan.GetUFORightMoving();

            if (pUFO.removed)
            {
                pUFO = UFOMan.ActivateUFORightMoving();
                pUFO.SetSpawnState(UFOMan.State.UFOReady);
            }

            pUFO.SetPos(-24, 660.0f);
            pUFO.SetActive(true);
            pUFO.SetSoundEngine(pUFOIn.sndEngine);
            // switch states
            //this.Handle(pUFO);
            pUFOIn.sndEngine.Play2D("ufo_highpitch.wav", true);
            pUFO.SpawnHandle();
        }
    }
}

// --- End of File ---
