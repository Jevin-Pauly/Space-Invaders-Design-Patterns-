using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class MoveGridCommand : Command
    {
        public MoveGridCommand(GameObject grid)
        {
            Debug.Assert(grid != null);
            this.grid = (AlienGrid)grid;

            this.direction = 1.0f;
            this.xMax = 336.0f + 50;
            this.xMin = 336.0f - 50;
            //this.totalMovement = 0;
            
        }

        int count = 0;
        public override void Execute(float deltaTime)
        {
            if (grid.x > xMax || grid.x < xMin)
            {
                direction *= -1.0f;
                count = 0;
            }
            count++;

            this.grid.Move(4 * direction, 0);
            TimerEventMan.Add(TimerEvent.Name.GridMovement, this, deltaTime);
        }


        private readonly AlienGrid grid;
        //private float totalMovement;
        private float direction;
        private float xMax;
        private float xMin;
    }
}
