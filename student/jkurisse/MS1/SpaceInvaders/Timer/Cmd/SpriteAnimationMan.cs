using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SpriteAnimationManager : Command
    {
        private readonly SpriteAnimationCommand Squid;
        private readonly SpriteAnimationCommand Crab;
        private readonly SpriteAnimationCommand Octopus;
        private readonly MoveGridCommand Move;

        public SpriteAnimationManager(SpriteAnimationCommand animation1, SpriteAnimationCommand animation2, SpriteAnimationCommand animation3, MoveGridCommand moveAll)
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
