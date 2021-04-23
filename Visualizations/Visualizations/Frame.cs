using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class Frame
    {
        public Rectangle SourceRectangle
        {
            get
            {
                return new Rectangle();
            }
        }

        int x { get; set; }
        int y { get; set; }
        int width { get; set; }
        int height { get; set; }

        public Frame(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
