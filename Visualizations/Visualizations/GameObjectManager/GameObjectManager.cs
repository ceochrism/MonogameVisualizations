using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class GameObjectManager
    {
        public Dictionary<string, GameObject> objects { get; } = new Dictionary<string, GameObject>();

        public GameObject this[string name]
        {
            get
            {
                if(!objects.ContainsKey(name))
                {
                    return null;
                }
                return objects[name];
            }
        }

        public GameObjectManager()
        {

        }

        public bool RegisterGameObject(string key, GameObject gameObject)
        {
            if(objects.ContainsKey(key))
            {
                return false;
            }

            objects.Add(key, gameObject);

            return true;
        }

        public List<GameObject> SelectWithTag(object Tag)
        {
            return objects.Select(x => x.Value).Where(x => x.Tag == Tag).ToList();
        }
        public void Draw(SpriteBatch sb) => objects.Select(x => x.Value).ToList().ForEach(x => x.Draw(sb));

        public void Update(GameTime gameTime) => objects.Select(x => x.Value).ToList().ForEach(x => x.Update(gameTime));

    }
}
