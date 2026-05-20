//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    abstract public class GameObject : Component
    {
        public enum Name
        {
            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,
            MsPacMan,
            PowerUpGhost,
            Prezel,

            Null_Object,
            Uninitialized
        }

        protected GameObject(GameObject.Name gameName, SpriteGameProxy pProxy)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pSpriteProxy = pProxy;
        }

        protected GameObject(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
        {
            this.name = gameName;
            this.x = _x;
            this.y = _y;

            this.pSpriteProxy = SpriteGameProxyMan.Add(spriteName);
        }

        ~GameObject()
        {

        }

        public virtual void Update()
        {
            Debug.Assert(this.pSpriteProxy != null);
            this.pSpriteProxy.x = this.x;
            this.pSpriteProxy.y = this.y;
        }

        override public void Dump()
        {
            // Data:
            Debug.WriteLine("");
            Debug.WriteLine("\tGameObject: --------------");
            Debug.WriteLine("\t\t\t       name: {0} ({1})", this.name, this.GetHashCode());

            if (this.pSpriteProxy != null)
            {
                Debug.WriteLine("\t\t   pProxySprite: {0}", this.pSpriteProxy.name);
                Debug.WriteLine("\t\t    pRealSprite: {0}", this.pSpriteProxy.pSprite.GetName());
            }
            else
            {
                Debug.WriteLine("\t\t   pProxySprite: null");
                Debug.WriteLine("\t\t    pRealSprite: null");
            }
            Debug.WriteLine("\t\t\t      (x,y): {0}, {1}", this.x, this.y);

            base.baseDump();
        
        }

        override public System.Enum GetName()
        {
            return this.name;
        }
        // Data: ---------------
        public GameObject.Name name;

        public float x;
        public float y;
        public SpriteGameProxy pSpriteProxy;
    }

}

// --- End of File ---
