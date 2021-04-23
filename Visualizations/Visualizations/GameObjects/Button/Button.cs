using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class Button : Sprite
    {

        public EventHandler<ButtonEventArgs> OnButtonClicked { get; set; }
        public EventHandler<ButtonEventArgs> OnMouseEnter { get; set; }
        public EventHandler<ButtonEventArgs> OnMouseLeave { get; set; }
        bool wasPreviouslyDown { get; set; }
        bool wasDownInButton { get; set; }
        public string Message { get; set; }
        public Text Text { get; private set; }
        public Vector2 Padding { get; set; } = new Vector2(5, 5);
        public SpriteFont Font { get; set; }
        public Color TextColor { get; set; } = Color.Black;
        public Color OriginalTint { get; set; }
        MouseState prevMS { get; set; }
        public Color TargetColor { get; set; }
        public TimeSpan FadeTime { get; set; }

        public Button(Vector2 position, Vector2 size, Texture2D image, Color tint, string message = "", SpriteFont font = null, object Tag = null, float scale = 1) : base(position, size, image, tint, Tag, scale)
        {
            wasPreviouslyDown = false;
            wasDownInButton = false;
            this.Font = font;
            this.Message = message;
            this.OriginalTint = tint;
            this.TargetColor = OriginalTint;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            if (Font != null)
            {
                this.Text = new Text(Position + Padding, Font, Message, TextColor);
            }
            Text?.Draw(sb);
        }



        public override void Update(GameTime gameTime)
        {

            if(Tint != TargetColor && FadeTime > TimeSpan.Zero)
            {
                Vector3 newRGB = Vector3.Lerp(new Vector3(Tint.R, Tint.G, Tint.B), new Vector3(TargetColor.R,TargetColor.G,TargetColor.B), (float)(1.0/FadeTime.TotalMilliseconds));
                int newR = 0;
                int newG = 0;
                int newB = 0;
                if(TargetColor.R < Tint.R)
                {
                    newR = (int)Math.Floor(newRGB.X);
                }
                else
                {
                    newR = (int)Math.Ceiling(newRGB.X);
                }
                if (TargetColor.G < Tint.G)
                {
                    newG = (int)Math.Floor(newRGB.Y);
                }
                else
                {
                    newG = (int)Math.Ceiling(newRGB.Y);
                }
                if (TargetColor.B < Tint.B)
                {
                    newB = (int)Math.Floor(newRGB.Z);
                }
                else
                {
                    newB = (int)Math.Ceiling(newRGB.Z);
                }
                Tint = Color.FromNonPremultiplied(newR, newG, newB, 255);
                FadeTime -= gameTime.ElapsedGameTime;
            }
            else
            {
                FadeTime = TimeSpan.Zero;
                Tint = TargetColor;
            }

            base.Update(gameTime);
            Text?.Update(gameTime);
            MouseState ms = Mouse.GetState();
            OnEnter(new ButtonEventArgs(ms));
            OnLeave(new ButtonEventArgs(ms));
            OnClick(new ButtonEventArgs(ms));
            prevMS = ms;
        }

        public void FadeToColor(Color TargetColor, TimeSpan FadeTime)
        {
            this.TargetColor = TargetColor;
            this.FadeTime = FadeTime;
        }

        protected void OnEnter(ButtonEventArgs e)
        {
            if (prevMS != null)
            {
                if (new Rectangle(e.ms.X, e.ms.Y, 1, 1).Intersects(HitBox) && !new Rectangle(prevMS.X, prevMS.Y, 1, 1).Intersects(HitBox))
                {
                    OnMouseEnter?.Invoke(this, e);
                }
            }
        }

        protected void OnLeave(ButtonEventArgs e)
        {
            if(prevMS != null)
            {
                if(!new Rectangle(e.ms.X,e.ms.Y,1,1).Intersects(HitBox) && new Rectangle(prevMS.X,prevMS.Y,1,1).Intersects(HitBox))
                {
                    OnMouseLeave?.Invoke(this, e);
                }
            }
        }

        protected void OnClick(ButtonEventArgs e)
        {
            if (wasPreviouslyDown && wasDownInButton && e.ms.LeftButton == ButtonState.Released)
            {
                OnButtonClicked?.Invoke(this, e);
            }

            if (e.ms.LeftButton == ButtonState.Pressed)
            {
                if (!wasPreviouslyDown)
                {
                    wasPreviouslyDown = true;
                    if (new Rectangle(e.ms.X, e.ms.Y, 1, 1).Intersects(HitBox))
                    {
                        wasDownInButton = true;
                    }
                }
                else if (!new Rectangle(e.ms.X, e.ms.Y, 1, 1).Intersects(HitBox))
                {
                    wasDownInButton = false;
                }
            }
            else
            {
                wasPreviouslyDown = false;
                wasDownInButton = false;
            }
        }

    }

    internal class ButtonEventArgs : EventArgs
    {
        public MouseState ms { get; set; }
        public ButtonEventArgs(MouseState ms)
        {
            this.ms = ms;
        }

    }
}
