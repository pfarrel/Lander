using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lander
{
    public class Ship
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        public float Rotation { get; private set; }
        public Rectangle Rectangle { get; private set; }

        public const int Width = 40;
        public const int Height = 80;
        private readonly Vector2 RotationOrigin = new Vector2(Width / 2, Height / 2);

        private readonly Vector2 YMove = new Vector2(0, -0.2f);
        private readonly Vector2 Gravity = new Vector2(0, 0.1f);

        public static Texture2D Texture;

        public Ship(Vector2 position)
        {
            Position = position;
            Velocity = Vector2.Zero;
            Rotation = 0.0f;
        }

        public void Land()
        {
            Velocity = Vector2.Zero;
        }

        public void Update(KeyboardState keyboard)
        {
            Position += Velocity;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            Velocity += Gravity;

            if (keyboard.IsKeyDown(Keys.Left))
                Rotation -= 0.05f ;
            if (keyboard.IsKeyDown(Keys.Right))
                Rotation += 0.05f;
            if (keyboard.IsKeyDown(Keys.Space))
                Velocity += YMove;

            Velocity = new Vector2(Velocity.X, MathHelper.Clamp(Velocity.Y, -5.0f, 5.0f));

            Console.WriteLine("Position: " + Position.ToString());
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Rectangle, Color.Black);

            var center = new Rectangle(Rectangle.X + Width / 2, Rectangle.Y + Height / 2, Width, Height);
            batch.Draw(Texture, center, null, Color.Red, Rotation, RotationOrigin, SpriteEffects.None, 0f);
        }
    }
}
