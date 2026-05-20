//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SE456
{
    public class FontMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private FontMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            this.poNodeCompare = new Font();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new FontMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
        }

        public static Font Add(Font.Name name, SpriteBatch.Name SB_Name, string pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontMan pMan = FontMan.privGetInstance();

            Font pNode = (Font)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            SpriteBatch pSB = SpriteBatchMan.Find(SB_Name);
            Debug.Assert(pSB != null);
            Debug.Assert(pNode.poSpriteFont != null);
            pSB.Attach(pNode.poSpriteFont);

            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, string assetName, Texture.Name textName)
        {
            GlyphMan.AddXml(assetName, glyphName, textName);
        }

        public static Font Find(Font.Name name)
        {
            FontMan pMan = FontMan.privGetInstance();

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            Font pData = (Font)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(Font pNode)
        {
            Debug.Assert(pNode != null);

            FontMan pMan = FontMan.privGetInstance();
            pMan.baseRemove(pNode);
        }
        public static void Dump()
        {
            FontMan pMan = FontMan.privGetInstance();
            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static FontMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new Font();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private readonly Font poNodeCompare;
        private static FontMan pInstance = null;

    }
}

// --- End of File ---
