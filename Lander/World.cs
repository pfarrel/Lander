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

        public World()
        {
            ship = new Ship(new Vector2(400, 200));
            ground = new Ground();
            target = new Target(new Vector2(1000, 600));
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
            target.Draw(spriteBatch);
            ship.Draw(spriteBatch);
        }
    }
}
