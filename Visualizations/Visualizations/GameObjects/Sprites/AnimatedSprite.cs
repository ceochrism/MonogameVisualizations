using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class AnimatedSprite : Sprite
    {
        List<Animation> animations;
        int currentAnimation = 0;
        public AnimatedSprite(Vector2 position, Vector2 size, Color tint, List<Animation> animations, Texture2D image = null,object Tag = null, Vector2 scale = default) : base(position, size, image, tint, Tag, scale)
        {
            this.animations = animations;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
