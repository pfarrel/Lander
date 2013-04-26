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
        public Vector2 Position { get; set; }
        private Vector2 Velocity { get; set; }

        private readonly Vector2 Size = new Vector2(40, 80);
        private readonly Vector2 XMove = new Vector2(1, 0);
        private readonly Vector2 YMove = new Vector2(0, -2);
        private readonly Vector2 Gravity = new Vector2(0, 1);

        public static Texture2D Texture;

        public Ship(Vector2 position)
        {
            Position = position;
            Velocity = Vector2.Zero;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            Velocity += Gravity;

            if (keyboard.IsKeyDown(Keys.Left))
                Velocity -= XMove;
            if (keyboard.IsKeyDown(Keys.Right))
                Velocity += XMove;
            if (keyboard.IsKeyDown(Keys.Up))
                Velocity += YMove;

            var speed = Velocity.Length();
            if (speed > 5.0f)
            {
                Velocity /= speed;
            }

            Position += Velocity;
        }

        public void Draw(SpriteBatch batch)
        {
            var rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            batch.Draw(Texture, rectangle, Color.Red);
        }
    }
}
