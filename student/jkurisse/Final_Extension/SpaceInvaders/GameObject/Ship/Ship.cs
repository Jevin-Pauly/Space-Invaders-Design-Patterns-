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

            this.shipSpeed = 2.0f;
            this.mState = null;
            this.sState = null;
            sndEngine = new IrrKlang.ISoundEngine();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.Visit(this);
        }
        public override void Visit(Bomb b)
        {
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public void MoveRight()
        {
            this.mState.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.mState.MoveLeft(this);
        }

        public void ShootMissile()
        {
            this.sState.ShootMissile(this);
        }

       
        public void MoveHandle(bool left)
        {
            if (left)
            {
                this.mState.Handle(this, left);
            }
            else
            {
                this.mState.Handle(this, left);
            }

        }
        public void ShootHandle()
        {
            this.sState.Handle(this);
        }


        public void SetShootState(ShipMan.SState state)
        {
            this.sState = ShipMan.GetShootState(state);
        }

        public void SetMoveState(ShipMan.MState state)
        {
            this.mState = ShipMan.GetMoveState(state);
        }

        public MoveState GetMoveState()
        {
            return this.mState;
        }
        public ShootState GetShootState()
        {
            return this.sState;
        }


        // Data: --------------------
        public float shipSpeed;
        private ShootState sState;
        private MoveState mState;
        public IrrKlang.ISoundEngine sndEngine = new IrrKlang.ISoundEngine();
    }
}

// --- End of File ---
