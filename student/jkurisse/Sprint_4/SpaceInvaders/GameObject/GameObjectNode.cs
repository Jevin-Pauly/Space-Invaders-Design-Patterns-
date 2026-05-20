using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    public class GameObjectNode : DLink
    {

        //------------------------------------
        // Constructor
        //------------------------------------

        public GameObjectNode()
            : base()
        {
            this.privClear();
        }

        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.pGameObj = pGameObject;
        }

        private void privClear()
        {
            this.pGameObj = null;
        }

        //------------------------------------
        // Override
        //------------------------------------

        public override object GetName()
        {
            Debug.Assert(this.pGameObj != null);
            return this.pGameObj.GetName();
        }

        override public void Wash()
        {
            this.privClear();
        }

        override public bool Compare(NodeBase pTarget)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(pTarget != null);

            GameObjectNode pDataB = (GameObjectNode)pTarget;

            bool status = false;

            Debug.Assert(pDataB.pGameObj != null);
            Debug.Assert(this.pGameObj != null);

            if (this.pGameObj.GetName() == pDataB.pGameObj.GetName())
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   GameObjectNode: ({0})", this.GetHashCode());

            // Data:
            if (this.pGameObj != null)
            {
                Debug.WriteLine("      GameObject.name: {0} ({1})", this.pGameObj.GetName(), this.pGameObj.GetHashCode());
            }
            else
            {
                Debug.WriteLine("      GameObject.name: null");
            }

            // Let the base print its contribution
            this.baseDump();
        }

        //----------------------------------
        // Data
        //----------------------------------
        public GameObject pGameObj;
    }
}

// --- End of File ---
