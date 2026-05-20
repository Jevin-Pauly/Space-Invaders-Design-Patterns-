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
        public AlienFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
        }


        public void Create(AlienBase.Type type, float posX, float posY)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienBase.Type.Squid:
                    pGameObj = new Squid(SpriteGame.Name.Squid, posX, posY);
                    break;

                case AlienBase.Type.Octopus:
                    pGameObj = new Octopus(SpriteGame.Name.Octopus, posX, posY);
                    break;

                case AlienBase.Type.Crab:
                    pGameObj = new Crab(SpriteGame.Name.Crab, posX, posY);
                    break;

                //case AlienBase.Type.Yellow:
                //    pGameObj = new BirdYellow(SpriteGame.Name.YellowBird, posX, posY);
                //    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            GameObjectNodeMan.Attach(pGameObj);

            // Attached to Group
            this.pSpriteBatch.Attach(pGameObj);
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
    }
}
