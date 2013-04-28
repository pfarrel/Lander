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
        public float Rotation { get; private set; }

        public Vector2 Velocity { get; private set; }

        private float MainThrust;
        private float RotationThrust;

        public Rectangle Rectangle { get; private set; }

        public const int Width = 40;
        public const int Height = 120;
        private readonly Vector2 RotationOrigin = new Vector2(Width / 2, Height / 2);

        public static Texture2D Texture;

        public Ship(Vector2 position)
        {
            Position = position;
            Rotation = 0.0f;

            Velocity = Vector2.Zero;
            MainThrust = 0.5f;
            RotationThrust = 0.0f;
        }

        public void Land(Rectangle on)
        {
            Velocity = Vector2.Zero;
            Position = new Vector2(Position.X, on.Top - Height);
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Left))
                RotationThrust -= 0.001f;
            if (keyboard.IsKeyDown(Keys.Right))
                RotationThrust += 0.001f;
            if (keyboard.IsKeyDown(Keys.Space))
                MainThrust += 0.015f;

            var thrustVector = Vector2.Transform(Vector2.UnitY, Matrix.CreateRotationZ(Rotation));
            Velocity += thrustVector * (-1.0f * MainThrust);
            Velocity += LanderGame.Gravity;

            Rotation += RotationThrust;

            Rotation += Rotation * 0.01f;

            Position += Velocity;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            // decay
            RotationThrust *= 0.995f;
            MainThrust *= 0.9f;

            //Console.WriteLine("Position: " + Position.ToString());
            //Console.WriteLine("Velocity: " + Velocity.ToString());
            //Console.WriteLine("Thrust: " + MainThrust);
            //Console.WriteLine("Rotation: " + Rotation);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            //batch.Draw(Texture, Rectangle, Color.Black);

            var center = new Rectangle(Rectangle.X + Width / 2, Rectangle.Y + Height / 2, Width, Height);
            batch.Draw(Texture, center, null, Color.Red, Rotation, RotationOrigin, SpriteEffects.None, 0f);


            var text = string.Format("Rotation: {0:f2}, RotationThrust {1:f2}", Rotation, RotationThrust);
            batch.DrawString(LanderGame.Font, text, new Vector2(100, 100), Color.White);
        }
    }
}
