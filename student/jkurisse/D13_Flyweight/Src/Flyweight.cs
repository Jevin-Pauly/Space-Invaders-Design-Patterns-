//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace PA
{
    public class Flyweight
    {
        // -----------------------------------------------------------
        // Add CODE/REFACTOR here
        // -----------------------------------------------------------
        //  Fill in the two methods...
        //       add additional helper methods if you want
        // -----------------------------------------------------------

        public Letter GetLetter(string pString)
        {
            // ----------------------------------------------------------
            // Add CODE/REFACTOR here
            // ----------------------------------------------------------
            // return a letter...
            //          returned a share object if found on list
            //          else
            //          created create a new object and add to list
            // ----------------------------------------------------------
            // 1) Return the letter if its already in the flyweight
            // or 
            // 2) not on list...
            //      Create a new letter
            //      attach new letter to flyweight
            // ----------------------------------------------------------

            Letter pCurr = poHead;
            while (pCurr != null)
            {
                if (pCurr.mString == pString)
                {
                    return pCurr;
                }
                pCurr = (Letter)pCurr.pNext;
            }

            pCurr = poHead;
            Letter newLetter = new Letter(pString);
            newLetter.pNext = pCurr;
            poHead = newLetter;

            return newLetter;
        }

        public void Remove(string pString)
        {
            // --------------------------------------------------
            // Add CODE/REFACTOR here
            // --------------------------------------------------
            //  remove a entry on the flyweight if it exists
            // --------------------------------------------------

            Letter pCurr = this.poHead;
            Letter pPrev = null;

            while (pCurr != null)
            {
                if (pCurr.mString == pString)
                {
                    if (pCurr == this.poHead && pCurr.pNext == null)
                    {
                        this.poHead = null;
                        break;
                    }
                    else if (pCurr == this.poHead)
                    {
                        pCurr = (Letter)pCurr.pNext;
                        this.poHead = null;
                        this.poHead = pCurr;
                        break;
                    }
                    else
                    {
                        pPrev.pNext = pCurr.pNext;
                        pCurr = null;
                        break;
                    }
                }
                pPrev = pCurr;
                pCurr = (Letter)pCurr.pNext;

            }
        }


        // ------------------------------------------
        // Data:
        // ------------------------------------------

        public Letter poHead;
    }
}

// --- End of File ---

