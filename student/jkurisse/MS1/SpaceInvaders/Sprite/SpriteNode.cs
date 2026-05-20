using Azul;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SpriteNode : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
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

            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------

        public SpriteNode()
        : base()
        {
            this.pSpriteBase = null;
        }

        //------------------------------------
        // Methods
        //------------------------------------

        //public void Set(SpriteGame.Name name)
        //{
        //    // Go find it
        //    this.pSpriteBase = SpriteGameMan.Find(name);
        //    Debug.Assert(this.pSpriteBase != null);
        //}

        public void Set(SpriteBase pNode)
        {
            // associate it
            Debug.Assert(pNode != null);
            this.pSpriteBase = pNode;
        }

        //public void Set(SpriteGameProxy pNode)
        //{
        //    // associate it
        //    Debug.Assert(pNode != null);
        //    this.pSpriteBase = pNode;
        //}







        private void privClear()
        {
            this.pSpriteBase = null;
        }

        //------------------------------------
        // Override
        //------------------------------------

        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   ({0}) node", this.GetHashCode());
        
            // Data:
            //Debug.WriteLine("   pSprite: {0} ({1})", this.pSprite.name, this.pSprite.GetHashCode());
        
            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public SpriteBase pSpriteBase;
    }
}
