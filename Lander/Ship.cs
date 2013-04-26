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
        public Rectangle Rectangle { get; private set; }

        private readonly Vector2 Size = new Vector2(40, 80);
        private readonly Vector2 XMove = new Vector2(1, 0);
        private readonly Vector2 YMove = new Vector2(0, -0.2f);
        private readonly Vector2 Gravity = new Vector2(0, 0.1f);

        public Ship(Vector2 position)
        {
            Position = position;
            Velocity = Vector2.Zero;
        }

        public void Stop()
        {
            Velocity = Vector2.Zero;
        }

        public void Update(KeyboardState keyboard)
        {
            Position += Velocity;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

            Velocity += Gravity;

            if (keyboard.IsKeyDown(Keys.Left))
                Velocity -= XMove;
            if (keyboard.IsKeyDown(Keys.Right))
                Velocity += XMove;
            if (keyboard.IsKeyDown(Keys.Up))
                Velocity += YMove;


            Velocity = new Vector2(Velocity.X, Helpers.Clamp(Velocity.Y, -5.0f, 5.0f));

            Console.WriteLine("Position: " + Position.ToString());
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(LanderGame.WhitePixelTexture, Rectangle, Color.Red);
        }
    }
}
