using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lander
{
    public class Target
    {
        public const int Width = 100;
        public const int Height = 20;

        public Rectangle Rectangle { get; private set; }

        public static Texture2D Texture;

        public Target(Vector2 position)
        {
            Rectangle = new Rectangle((int)position.X, (int)position.Y, Width, Height);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Rectangle, Color.LawnGreen);
        }
    }
}
