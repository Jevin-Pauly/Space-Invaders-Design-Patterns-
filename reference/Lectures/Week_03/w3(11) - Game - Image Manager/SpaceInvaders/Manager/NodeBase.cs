//-----------------------------------------------------------------------------
// Copyright 2024, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace SE456
{
    abstract public class NodeBase
    {
        // these are needed to make the ManagerBase work
        abstract public void Wash();
        abstract public void Dump();
        abstract public object GetName();
    }
}

// --- End of File ---

