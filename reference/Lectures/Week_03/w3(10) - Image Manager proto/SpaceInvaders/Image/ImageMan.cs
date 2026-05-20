//----------------------------------------------------------------------ImageMan-------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SE456
{
    class ImageMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public ImageMan(ListBase _poActive, ListBase _poReserve, int reserveNum = 3, int reserveGrow = 1)
                : base(_poActive, _poReserve, reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            this.poImageCompare = new Image();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public Image Add(Image.Name name, Texture pSrcTexture, Azul.Rect pSubRect)
        {
            Image pImage = (Image)this.baseAdd();
            Debug.Assert(pImage != null);

            // Initialize the data
            pImage.Set(name, pSrcTexture, pSubRect);
            return pImage;
        }

        public Image Find(Image.Name name)
        {
            // Compare functions only compares two Images

            // So:  Use the Compare Image - as a reference
            //      use in the Compare() function
            this.poImageCompare.name = name;

            Image pData = (Image)this.baseFind(this.poImageCompare);
            return pData;
        }
        public void Remove(Image pImage)
        {
            Debug.Assert(pImage != null);
            this.baseRemove(pImage);
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
            NodeBase pNodeBase = new Image();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        override protected bool derivedCompare(NodeBase pImageBaseA, NodeBase pImageBaseB)
        {
            // This is used in baseFind() 
            Debug.Assert(pImageBaseA != null);
            Debug.Assert(pImageBaseB != null);

            Image pDataA = (Image)pImageBaseA;
            Image pDataB = (Image)pImageBaseB;

            bool status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(NodeBase pImageBase)
        {
            Debug.Assert(pImageBase != null);
            Image pImage = (Image)pImageBase;
            pImage.Wash();
        }
        override protected void derivedDumpNode(NodeBase pImageBase)
        {
            Debug.Assert(pImageBase != null);
            Image pData = (Image)pImageBase;
            pData.Dump();
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private readonly Image poImageCompare;
    }
}

// --- End of File ---
