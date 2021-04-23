using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class Text : GameObject
    {

        SpriteFont font { get; }
        public string Message { get; set; }
        public Color Color { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; }

        public Text(Vector2 position, SpriteFont font, string message, Color color, float scale = 1, float rotation = 0, object Tag = null) : base(position, Tag)
        {
            this.Message = message;
            this.Color = color;
            Scale = scale;
            Rotation = rotation;
            this.font = font;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, Message, Position, Color, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
