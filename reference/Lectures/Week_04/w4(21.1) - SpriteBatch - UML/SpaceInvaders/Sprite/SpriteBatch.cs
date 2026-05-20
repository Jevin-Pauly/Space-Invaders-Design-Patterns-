//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public abstract class SpriteBatch_Link : DLink
    {

    }
    public class SpriteBatch : SpriteBatch_Link
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            PacMan,
            AngryBirds,
   
            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;

            this.pSpriteNodeMan = new SpriteNodeMan();
            Debug.Assert(this.pSpriteNodeMan != null);
        }

        //------------------------------------
        // Methods
        //------------------------------------
        public void Set(SpriteBatch.Name name, int reserveNum = 3, int reserveGrow = 1)
        {
            this.name = name;
            this.pSpriteNodeMan.Set(name, reserveNum, reserveGrow);
        }

        public void SetName(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        public SpriteNodeMan GetSpriteNodeMan()
        {
            return this.pSpriteNodeMan;
        }

        public SpriteNode Attach(Sprite.Name name)
        {
            SpriteNode pNode = this.pSpriteNodeMan.Attach(name);
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
        private readonly SpriteNodeMan pSpriteNodeMan;
    }
}

// --- End of File ---
