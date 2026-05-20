using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SpriteAnimationManager : Command
    {
        private readonly AnimationCmd Squid;
        private readonly AnimationCmd Crab;
        private readonly AnimationCmd Octopus;
        private readonly MoveGridCommand Move;

        public SpriteAnimationManager(AnimationCmd animation1, AnimationCmd animation2, AnimationCmd animation3, MoveGridCommand moveAll)
        {
            this.Squid = animation1;
            this.Crab = animation2;
            this.Octopus = animation3;
            this.Move = moveAll;
        }

        public override void Execute(float deltaTime)
        {
            Squid.Execute(deltaTime);
            Crab.Execute(deltaTime);
            Octopus.Execute(deltaTime);
            Move.Execute(deltaTime);

        }
    }
}
