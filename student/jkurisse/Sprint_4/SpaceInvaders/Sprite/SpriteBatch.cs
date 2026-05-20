using Azul;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class SpriteBatch : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            PacMan,
            AngryBirds,
            Boxes,
            Misc,

            Invaders,

            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;

            this.poSpriteNodeMan = new SpriteNodeMan();
            Debug.Assert(this.poSpriteNodeMan != null);
        }

        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(SpriteBatch.Name name, float priority, int reserveNum = 3, int reserveGrow = 1)
        {
            this.name = name;
            this.priority = priority;
            this.poSpriteNodeMan.Set(name, reserveNum, reserveGrow);
        }

        public void SetName(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        public SpriteNodeMan GetSpriteNodeMan()
        {
            return this.poSpriteNodeMan;
        }

        public SpriteNode Attach(SpriteGame.Name name)
        {
            SpriteNode pNode = this.poSpriteNodeMan.Attach(name);
            return pNode;
        }

        public SpriteNode Attach(SpriteBox.Name name)
        {
            SpriteNode pNode = this.poSpriteNodeMan.Attach(name);
            return pNode;
        }

        public SpriteNode Attach(SpriteGameProxy _pNode)
        {
            SpriteNode pNode = this.poSpriteNodeMan.Attach(_pNode);
            return pNode;
        }
        public SpriteNode Attach(GameObject pGameObj)
        {
            Debug.Assert(pGameObj != null);
            SpriteNode pNode = this.poSpriteNodeMan.Attach(pGameObj.pSpriteProxy);
            return pNode;
        }

        private void privClear()
        {

        }

        //------------------------------------
        // Override
        //------------------------------------
        public override object GetName()
        {
            return this.name;
        }
        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public SpriteBatch.Name name;
        private readonly SpriteNodeMan poSpriteNodeMan;
        //public float priority;
    }
}
