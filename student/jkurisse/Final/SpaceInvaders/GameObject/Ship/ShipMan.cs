//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class ShipMan
    {
        public enum SState
        {
            Ready,
            MissileFlying,
        }

        public enum MState
        {

            LeftBumper,
            RightBumper,
            Normal,

            Dead
        }

        private ShipMan()
        {
            // Store the states
            this.pStateReady = new ShipStateReady();
            this.pStateMissileFlying = new ShipStateMissileFlying();

            this.pStateNormal = new ShipNormalState();
            this.pStateBumpLeft = new ShipBumperLeftState();
            this.pStateBumpRight = new ShipBumperRightState();
            this.pStateDead = new ShipStateDead();

            // set active
            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            // make sure its the first time
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new ShipMan();
            }

            Debug.Assert(instance != null);

            // Stuff to initialize after the instance was created
            instance.pShip = ActivateShip();
            instance.pShip.SetShootState(ShipMan.SState.Ready);
            instance.pShip.SetMoveState(ShipMan.MState.Normal);

        }

        private static ShipMan PrivInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static Ship GetShip()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static ShootState GetShootState(SState state)
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            ShootState pShipState = null;

            switch (state)
            {
                case ShipMan.SState.Ready:
                    pShipState = pShipMan.pStateReady;
                    break;

                case ShipMan.SState.MissileFlying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static MoveState GetMoveState(MState state)
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            MoveState pShipState = null;

            switch (state)
            {
                case ShipMan.MState.Normal:
                    pShipState = pShipMan.pStateNormal;
                    break;

                case ShipMan.MState.LeftBumper:
                    pShipState = pShipMan.pStateBumpLeft;
                    break;

                case ShipMan.MState.RightBumper:
                    pShipState = pShipMan.pStateBumpRight;
                    break;

                case ShipMan.MState.Dead:
                    pShipState = pShipMan.pStateDead;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }











        public static Missile GetMissile()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            // No need to re-calling new()
            Missile pMissile = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.Missile);
            if (pGameObjNode == null)
            {
                pMissile = new Missile(SpriteGame.Name.Missile, 400, 100);
            }
            else
            {
                // Recycle it.
                pMissile = (Missile)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                pMissile.Resurrect(400, 100);
                //GhostMan.Dump();
            }
            pShipMan.pMissile = pMissile;

            // Attached to SpriteBatches
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateSprite(pSB_Aliens);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectNodeMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }


        private static Ship ActivateShip()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            // LTN - owned by ShipMan.. but needs some cleanup
            Ship pShip = new Ship(GameObject.Name.Ship, SpriteGame.Name.Ship, 336, 100);
            pShipMan.pShip = pShip;

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            pSB_Aliens.Attach(pShip.pSpriteProxy);

            // Attach the missile to the missile root
            GameObject pShipRoot = GameObjectNodeMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShipMan.pShip);

            return pShipMan.pShip;
        }

        // Data: ----------------------------------------------
        private static ShipMan instance = null;

        // Active
        private Ship pShip;
        private Missile pMissile;

        // Reference
        private ShipStateReady pStateReady;
        private ShipStateMissileFlying pStateMissileFlying;

        private ShipNormalState pStateNormal;
        private ShipBumperLeftState pStateBumpLeft;
        private ShipBumperRightState pStateBumpRight;
        private readonly ShipStateDead pStateDead;

    }
}

// --- End of File ---
