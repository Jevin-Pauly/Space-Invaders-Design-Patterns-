//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SE456
{
    public class SpriteNode : DLink
    {
        //------------------------------------
        // Enum
        //------------------------------------


        //------------------------------------
        // Constructors
        //------------------------------------

        public SpriteNode()
        : base()
        {
            this.pSprite = null;
        }

        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(SpriteGame.Name name)
        {
            // Go find it
            this.pSprite = SpriteGameMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }
        private void privClear()
        {
            this.pSprite = null;
        }

        //------------------------------------
        // Override
        //------------------------------------

        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public System.Enum GetName()
        {
            return null;
        }
        override public bool Compare(NodeBase pSpriteNodeBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pSpriteNodeBaseB != null);

            SpriteNode pDataB = (SpriteNode)pSpriteNodeBaseB;

            bool status = false;

            if (this.pSprite.GetName().GetHashCode() == pDataB.pSprite.GetName().GetHashCode())
            {
                status = true;
            }

            return status;
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   ({0}) node", this.GetHashCode());

            // Data:
            Debug.WriteLine("   pSprite: {0} ({1})", this.pSprite.name, this.pSprite.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public SpriteGame pSprite;
    }
}

// --- End of File ---

