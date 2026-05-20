using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public abstract class GameObject : Component
    {
        public enum Name
        {
            AlienGrid,
            AlienColumn,

            Squid,
            Octopus,
            Crab,

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

        protected GameObject(Component.Container type, GameObject.Name gameName, SpriteGame.Name proxyName)
            : base(type)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;

            SpriteGameProxy pProxy = SpriteGameProxyMan.Find(proxyName);
            Debug.Assert(pProxy != null);

            this.pSpriteProxy = pProxy;

            // LTN - GameObject
            this.poColObj = new ColObject(this.pSpriteProxy);
            Debug.Assert(this.poColObj != null);
        }

        protected GameObject(Component.Container type, GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(type)
        {
            this.name = gameName;
            this.x = _x;
            this.y = _y;

            this.pSpriteProxy = SpriteGameProxyMan.Add(spriteName);

            // LTN - GameObject
            this.poColObj = new ColObject(this.pSpriteProxy);
            Debug.Assert(this.poColObj != null);
        }

        ~GameObject()
        {

        }


        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;

            // point to ColTotal
            ColRect ColTotal = this.poColObj.poColRect;

            // Get the first child
            pNode = (GameObject)IteratorComposite.GetChild(pNode);

            // Initialized the union to the first block
            ColTotal.Set(pNode.poColObj.poColRect);

            // loop through sliblings
            while (pNode != null)
            {
                ColTotal.Union(pNode.poColObj.poColRect);

                // go to next sibling
                pNode = (GameObject)IteratorComposite.GetSibling(pNode);
            }

            this.x = this.poColObj.poColRect.x;
            this.y = this.poColObj.poColRect.y;

            //  Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", ColTotal.x, ColTotal.y, ColTotal.width, ColTotal.height);
        }



        public virtual void Update()
        {
            Debug.Assert(this.pSpriteProxy != null);
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            this.pSpriteProxy.x = this.x;
            this.pSpriteProxy.y = this.y;

            this.poColObj.UpdatePos(this.x, this.y);
            this.poColObj.pColSprite.Update();
        }


        public void ActivateCollisionSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.poColObj != null);
            pSpriteBatch.Attach(this.poColObj.pColSprite);
        }
        public void ActivateSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.Attach(this.pSpriteProxy);
        }

        override public void Dump()
        {
            // Data:
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
        public ColObject poColObj;
    }

}
