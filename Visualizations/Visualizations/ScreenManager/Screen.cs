using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    abstract class Screen
    {
        protected ScreenManager manager { get; }

        protected Viewport viewport { get; }

        public Screen(ScreenManager manager, Viewport viewport)
        {
            this.manager = manager;
            this.viewport = viewport;
        }

        protected GameObjectManager objectManager { get; } = new GameObjectManager();

        public abstract void LoadContent(ContentManager content);

        public virtual void Draw(SpriteBatch sb) => objectManager.Draw(sb);

        public abstract void Update(GameTime gameTime);

    }
}
