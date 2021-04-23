using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    abstract class GameObject
    {
        public Vector2 Position { get; set; }

        public object Tag { get; set; }

        public GameObject(Vector2 Position, object Tag = null)
        {
            this.Position = Position;
            this.Tag = Tag;
        }

        public abstract void Draw(SpriteBatch sb);
        public abstract void Update(GameTime gameTime);
    }
}
