using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class Animation
    {
        public Texture2D Image { get; private set; }

        List<Frame> frames { get; set; }

        public IReadOnlyList<Frame> Frames { get { return frames; } }

        private int currentFrame = 0;

        public int CurrentFrame { get { return currentFrame; } set { if (value > frames.Count) { currentFrame = 0; } else { currentFrame = value; } } }

        public Animation(List<Frame> frames, Texture2D image)
        {
            this.frames = frames;
            Image = image;
        }
    }
}
