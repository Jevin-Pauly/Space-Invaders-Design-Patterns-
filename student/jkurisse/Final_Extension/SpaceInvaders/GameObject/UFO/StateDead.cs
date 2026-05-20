using System;
using System.Diagnostics;

namespace SE456
{
    class StateDead : UFOSpawnState
    {
        public override void Handle(UFO pUFO)
        {
            pUFO.SetSpawnState(UFOMan.State.Dead);
            pUFO.sndEngine.StopAllSounds();
        }
        public override void SpawnUFOLeftMoving(UFO pUFO)
        {
            //Do Nothing
        }

        public override void SpawnUFORightMoving(UFO pUFO)
        {
            //Do Nothing
        }
    }
}

// --- End of File ---
