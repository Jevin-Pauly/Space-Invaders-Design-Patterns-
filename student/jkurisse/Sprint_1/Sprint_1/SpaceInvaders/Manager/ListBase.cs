using SpaceInvaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
