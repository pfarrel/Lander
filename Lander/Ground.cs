using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lander
{
    public class Ground
    {
        public const int Height = 600;
        public Rectangle Rectangle 
        { 
            get
            {
                return new Rectangle(0, Height, LanderGame.Width, LanderGame.Height - Height);
            }
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(LanderGame.WhitePixelTexture, Rectangle, Color.Gray);
        }
    }
}
