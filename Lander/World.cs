using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lander
{
    public class World
    {
        Ship ship;
        Ground ground;
        Target target;

        public GameState State { get; private set;}

        public World()
        {
            ship = new Ship(new Vector2(400, 200));
            ground = new Ground();
            target = new Target(new Vector2(1000, 600));

            State = GameState.Playing;
        }

        public void Update(GameTime gameTime)
        {
            if (State == GameState.Playing)
            {
                if (ship.Rectangle.Intersects(target.Rectangle) && ship.Velocity.Length() < 1 && Math.Abs(ship.Rotation) < 0.2f)
                {
                    State = GameState.Won;
                }

                if (ship.Rectangle.Intersects(ground.Rectangle))
                {
                    if (!(ship.Velocity.Length() < 1 && Math.Abs(ship.Rotation) < 0.2f))
                    {
                        State = GameState.Lost;
                    }
                    ship.Land(ground.Rectangle);
                }

                ship.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            ground.Draw(gameTime, spriteBatch);
            target.Draw(gameTime, spriteBatch);
            ship.Draw(gameTime, spriteBatch);
        }
    }

    public enum GameState
    {
        Playing,
        Won,
        Lost
    }
}
