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

        public World()
        {
            ship = new Ship(new Vector2(400, 200));
            ground = new Ground();
        }

        public void Update(KeyboardState keyState)
        {
            if (ship.Rectangle.Intersects(ground.Rectangle))
                ship.Land(ground.Rectangle);

            ship.Update(keyState);
            ground.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ground.Draw(spriteBatch);
            ship.Draw(spriteBatch);
        }
    }
}
