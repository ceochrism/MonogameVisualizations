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

        public Vector2 Scale { get; set; }

        public float Rotation { get; set; } = 0;

        public Vector2 Origin { get { return new Vector2((float)Image.Width/2, (float)Image.Height/2); } }

        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        public Rectangle HitBox { get { return new Rectangle((int)(Position.X/* - Origin.X*/), (int)(Position.Y /*- Origin.Y*/), (int)(Size.X * Scale.X), (int)(Size.Y * Scale.Y)); } }

        public Sprite(Vector2 position, Vector2 size, Texture2D image, Color tint, object Tag = null, Vector2 scale = default) : base(position,Tag)
        {
            Size = size;
            Image = image;
            Tint = tint;
            if (scale == default)
            {
                this.Scale = Vector2.One;
            }
            else
            {
                Scale = scale;
            }
        }

        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(Image, HitBox, sourceRectangle: null, Tint, Rotation, Origin, SpriteEffects, 0);
        }

        public override void Update(GameTime gameTime)
        {

        }


    }
}
