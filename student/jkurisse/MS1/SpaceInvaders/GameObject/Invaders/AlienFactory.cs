using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE456
{
    class AlienFactory
    {
        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxBatch = SpriteBatchMan.Find(boxBatchName);
            Debug.Assert(this.pBoxBatch != null);
        }


        public GameObject Create(GameObject.Name type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case GameObject.Name.Squid:
                    // LTN - GameObject
                    pGameObj = new Squid(SpriteGame.Name.Squid, posX, posY);
                    break;

                case GameObject.Name.Octopus:
                    // LTN - GameObject
                    pGameObj = new Octopus(SpriteGame.Name.Octopus, posX, posY);
                    break;

                case GameObject.Name.Crab:
                    // LTN - GameObject
                    pGameObj = new Crab(SpriteGame.Name.Crab, posX, posY);
                    break;

                case GameObject.Name.AlienGrid:
                    // LTN - GameObject
                    pGameObj = new AlienGrid();
                    break;

                case GameObject.Name.AlienColumn:
                    // LTN - GameObject
                    pGameObj = new AlienColumn();
                    break;

                //case AlienBase.Type.Yellow:
                //    pGameObj = new BirdYellow(SpriteGame.Name.YellowBird, posX, posY);
                //    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // Attached to Group
            pGameObj.ActivateSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxBatch);

            return pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
        SpriteBatch pBoxBatch;
    }
}
