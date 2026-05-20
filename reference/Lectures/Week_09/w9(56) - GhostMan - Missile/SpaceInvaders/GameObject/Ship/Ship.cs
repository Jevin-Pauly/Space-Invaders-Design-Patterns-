//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class Ship : ShipCategory
    {

        public Ship(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
         : base(name, spriteName, posX, posY, ShipCategory.Type.Ship)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 3.0f;
            this.state = null;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.VisitShip(this);
        }

        public void MoveRight()
        {
            this.state.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.state.MoveLeft(this);
        }

        public void ShootMissile()
        {
            this.state.ShootMissile(this);
        }

        public void SetState(ShipMan.State inState)
        {
            this.state = ShipMan.GetState(inState);
        }
        public void Handle()
        {
            this.state.Handle(this);
        }
        public ShipState GetState()
        {
            return this.state;
        }
        // Data: --------------------
        public float shipSpeed;
        private ShipState state;
    }
}

// --- End of File ---
