//----------------------------------------------------------------------ImageMan-------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class TextureMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public TextureMan(ListBase _poActive, ListBase _poReserve, int reserveNum = 3, int reserveGrow = 1)
                : base(_poActive, _poReserve, reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            this.poTextureCompare = new Texture();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public Texture Add(Texture.Name name, string pTextureName)
        {
            Debug.Assert(pTextureName != null);

            Texture pTexture = (Texture)this.baseAdd();
            Debug.Assert(pTexture != null);

            // Initialize the data
            pTexture.Set(name, pTextureName);
            return pTexture;
        }

        public Texture Find(Texture.Name name)
        {
            // Compare functions only compares two Textures

            // So:  Use the Compare Texture - as a reference
            //      use in the Compare() function
            this.poTextureCompare.name = name;

            Texture pData = (Texture)this.baseFind(this.poTextureCompare);
            return pData;
        }
        public void Remove(Texture pTexture)
        {
            Debug.Assert(pTexture != null);
            this.baseRemove(pTexture);
        }
        public void Dump()
        {
            this.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new Texture();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        override protected bool derivedCompare(NodeBase pTextureBaseA, NodeBase pTextureBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pTextureBaseA != null);
            Debug.Assert(pTextureBaseB != null);

            Texture pDataA = (Texture)pTextureBaseA;
            Texture pDataB = (Texture)pTextureBaseB;

            bool status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(NodeBase pTextureBase)
        {
            Debug.Assert(pTextureBase != null);
            Texture pTexture = (Texture)pTextureBase;
            pTexture.Wash();
        }
        override protected void derivedDumpNode(NodeBase pTextureBase)
        {
            Debug.Assert(pTextureBase != null);
            Texture pData = (Texture)pTextureBase;
            pData.Dump();
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private readonly Texture poTextureCompare;
    }
}

// --- End of File ---
