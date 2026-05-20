using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SE456
{
    public class SpriteAnimationManager : Command
    {
        private readonly AnimationCmd Squid;
        private readonly AnimationCmd Crab;
        private readonly AnimationCmd Octopus;
        private readonly MoveGridCommand Move;
        public float AliensCount;
        public float Delay;
        public bool move;

        public SpriteAnimationManager(AnimationCmd animation1, AnimationCmd animation2, AnimationCmd animation3, MoveGridCommand moveAll)
        {
            this.Squid = animation1;
            this.Crab = animation2;
            this.Octopus = animation3;
            this.Move = moveAll;
            this.AliensCount = 0.0f;
            this.Delay = 0.7f;
        }

        public override void Execute(float deltaTime, bool move)
        {
            float newDeltaTime = Delay - AliensCount * 0.0118f;
            if (AliensCount != 55) 
            {
                Squid.Execute(newDeltaTime, move);
                Crab.Execute(newDeltaTime, move);
                Octopus.Execute(newDeltaTime, move);
                Move.Execute(newDeltaTime, move);
            }
            TimerEventMan.Add(TimerEvent.Name.Animation, this, newDeltaTime);
        }

        public override void Reset() 
        { 
            AliensCount = 0;
            Move.Reset();
        }
    }
}
