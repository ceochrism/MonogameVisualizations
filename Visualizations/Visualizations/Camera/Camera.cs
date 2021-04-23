using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class Camera
    {
        public Matrix transform { get; private set; }
        public Camera()
        {

        }
        
        public void Follow(Sprite target, Viewport screenSize)
        {
            var trans = Matrix.CreateTranslation(-target.HitBox.X - (target.HitBox.Width / 2), -target.HitBox.Y - (target.HitBox.Height / 2), 0);
            var offset = Matrix.CreateTranslation(screenSize.Width / 2, screenSize.Height / 2, 0);

            transform = trans * offset;
        }
    }
}
