using IrrKlang;
using System;
using System.Diagnostics;

namespace SE456
{
    public class UFO : UFOCategory
    {
        public UFO(GameObject.Name name, SpriteGame.Name spriteName, MoveStrategy _pStrategy, float posX, float posY)
            : base(name, spriteName, posX, posY, UFOCategory.Type.UFO)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 2.0f;
            this.removed = true;

            Debug.Assert(_pStrategy != null);
            this.pStrategy = _pStrategy;
            this.sndEngine = new IrrKlang.ISoundEngine();
            this.sndEngine.SoundVolume = 0.2f;
            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 2.0f;
            this.poColObj.pColSprite.SetColor(1, 1, 0);
            base.Resurrect(SpriteGame.Name.UFO);
        }


        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();
            this.removed = true;
            this.sndEngine.StopAllSounds();
            // Now remove it
            base.Remove();
        }
        public override void Update()
        {
            base.Update();
            // Strategy
            this.pStrategy.Move(this);

            this.x += delta;
        }
        public float GetBoundingBoxHeight()
        {
            return this.poColObj.poColRect.height;
        }

        public void SetSoundEngine(IrrKlang.ISoundEngine soundEngine)
        {
            this.sndEngine = soundEngine;
            this.sndEngine.SoundVolume = 0.2f;
        }

        public void SetSpawnState(UFOMan.State state)
        {
            this.sState = UFOMan.GetState(state);
        }

        public void SpawnHandle()
        {
            this.sState.Handle(this);
        }

        public void SpawnUFOLeftMoving()
        {
            this.sState.SpawnUFOLeftMoving(this);
        }

        public void SpawnUFORightMoving()
        {
            this.sState.SpawnUFORightMoving(this);
        }

        ~UFO()
        {
        }

        public override void Accept(ColVisitor other)
        {         
            other.Visit(this);
        }

        public override void Visit(MissileGroup m)
        {
            // MissileRoot vs WallTop
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void Visit(Missile m)
        {
            // Missile vs WallTop
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
            m.x = 0;
            m.y = 0;
        }


        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }
        public void SetActive(bool state)
        {
            this.removed = state;
        }

        // Data -------------------------------------
        public bool removed;
        public float delta;
        public ISoundEngine sndEngine;
        public UFOSpawnState sState;
        private MoveStrategy pStrategy;
    }
}

// --- End of File ---