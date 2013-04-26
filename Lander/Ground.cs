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
        public const int Position = 600;
        public const int Width = LanderGame.Width;
        public const int Height = LanderGame.Height - Position;
        public Rectangle Rectangle = new Rectangle(0, Position, Width, Height);

        public static Texture2D Texture;

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(Texture, Rectangle, Color.Gray);
        }
    }
}
