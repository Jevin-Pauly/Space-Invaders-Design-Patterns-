using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class UFOSpawnState
    {
        // state()
        public abstract void Handle(UFO pUFO);
        public abstract void SpawnUFOLeftMoving(UFO pUFO);
        public abstract void SpawnUFORightMoving(UFO pUFO);

    }
}
