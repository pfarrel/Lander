#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Lander
{
    public class LanderGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int Width = 1280;
        public const int Height = 720;

        World world;

        public LanderGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            this.IsFixedTimeStep = true;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            world = new World();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Ship.Texture = new Texture2D(GraphicsDevice, Ship.Width, Ship.Height);
            Ship.Texture.SetData(Enumerable.Repeat(Color.White, Ship.Width * Ship.Height).ToArray());

            Ground.Texture = new Texture2D(GraphicsDevice, Ground.Width, Ground.Height);
            Ground.Texture.SetData(Enumerable.Repeat(Color.White, Ground.Width * Ground.Height).ToArray());
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Escape))
                Exit();

            world.Update(keyState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            world.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
