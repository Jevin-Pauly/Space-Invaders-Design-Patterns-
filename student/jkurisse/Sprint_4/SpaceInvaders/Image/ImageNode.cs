using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class ImageNode : SLink
    {
        //------------------------------------
        // Constructors
        //------------------------------------
        public ImageNode(Image _pImage)
            : base()
        {
            Debug.Assert(_pImage != null);
            this.pImage = _pImage;
        }
        //------------------------------------
        // Methods
        //------------------------------------
        private void privClean()
        {
            this.pImage = null;
        }

        //------------------------------------
        // Override
        //------------------------------------
        override public void Wash()
        {
            this.privClean();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   ({0}) node", this.GetHashCode());

            // Data:
            Debug.WriteLine("   pImage: {0} ({1})", this.pImage.GetName(), this.pImage.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }
        public override object GetName()
        {
            return this.pImage.GetName();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public Image pImage;
    }
}
