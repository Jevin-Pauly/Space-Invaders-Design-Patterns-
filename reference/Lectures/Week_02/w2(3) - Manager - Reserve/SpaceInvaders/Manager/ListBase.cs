//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace SE456
{
    public abstract class ListBase
    {
        abstract public void AddToFront(NodeBase pNode);
        abstract public void Remove(NodeBase pNode);
        abstract public NodeBase RemoveFromFront();

        // HACK
        abstract public NodeBase GetFirst();
    }
}

// --- End of File ---
