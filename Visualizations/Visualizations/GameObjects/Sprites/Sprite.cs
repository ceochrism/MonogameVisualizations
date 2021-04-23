using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class Sprite:GameObject
    {

        public Texture2D Image { get; set; }

        public Vector2 Size { get; set; }

        public Color Tint { get; set; }

        public float Scale { get; set; }

        public float Rotation { get; set; } = 0;

        public Vector2 Origin { get; set; }

        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        public Rectangle HitBox { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)(Size.X * Scale), (int)(Size.Y * Scale)); } }

        public Sprite(Vector2 position, Vector2 size, Texture2D image, Color tint, object Tag = null, float scale = 1.0f, Vector2 Origin = default) : base(position,Tag)
        {
            Size = size;
            Image = image;
            Tint = tint;
            Scale = scale;
            if (Origin == default)
            {
                this.Origin = new Vector2(HitBox.Width / 2, HitBox.Height / 2);
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Image, HitBox, null, Tint, Rotation, Origin, SpriteEffects, 0);
        }

        public override void Update(GameTime gameTime)
        {

        }


    }
}
