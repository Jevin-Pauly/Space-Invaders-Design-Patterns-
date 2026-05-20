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
            this.pSpriteBase = null;
        }

        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(SpriteBase pNode)
        {
            // associate it
            Debug.Assert(pNode != null);
            this.pSpriteBase = pNode;
        }
        //public void Set(SpriteGame.Name name)
        //{
        //    // Go find it
        //    this.pSpriteBase = SpriteGameMan.Find(name);
        //    Debug.Assert(this.pSpriteBase != null);
        //}
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

            if (this.pSpriteBase.GetName().GetHashCode() == pDataB.pSpriteBase.GetName().GetHashCode())
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
            Debug.WriteLine("   pSprite: {0} ({1})", this.pSpriteBase.GetName(), this.pSpriteBase.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public SpriteBase pSpriteBase;
    }
}

// --- End of File ---

