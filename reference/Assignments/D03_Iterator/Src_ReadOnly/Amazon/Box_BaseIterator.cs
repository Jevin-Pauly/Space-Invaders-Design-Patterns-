//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    abstract public class Box_BaseIterator
    {
        // -------------------------------------------------------------------
        // Next() - Advances the iterator to the next item after current item
        //          If valide returns the next item
        //          If the item is not valid, return null
        //          This function advances the iterator
        // -------------------------------------------------------------------
        abstract public Box Next();

        // -------------------------------------------------------------------
        // IsDone() - Return status
        //            Is there additional elements after the current item?
        //            Does not advance the iterator
        // -------------------------------------------------------------------
        abstract public bool IsDone();

        // -------------------------------------------------------------------
        // First() - Returns the first element
        //           Does not advance the iterator
        // -------------------------------------------------------------------
        abstract public Box First();

        // -------------------------------------------------------------------
        // Current() - Returns the current item the iterator is pointing to
        //             Does not advance the iterator
        // -------------------------------------------------------------------
        abstract public Box Current();
    }
}

// --- End of File ---

