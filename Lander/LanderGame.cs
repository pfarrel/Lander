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

        private static Vector2 NormalGravity = new Vector2(0, 0.1f);
        public static Vector2 Gravity = NormalGravity;

        public static SpriteFont Font;

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

            Target.Texture = new Texture2D(GraphicsDevice, Target.Width, Target.Height);
            Target.Texture.SetData(Enumerable.Repeat(Color.White, Target.Width * Target.Height).ToArray());

            Font = Content.Load<SpriteFont>("SpriteFont1");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardHandler.Update();

            if (KeyboardHandler.CurrentState.IsKeyDown(Keys.Escape))
                Exit();

            if (KeyboardHandler.Pressed.Contains(Keys.G))
                Gravity = (Gravity != Vector2.Zero) ? Vector2.Zero : NormalGravity;

            if (KeyboardHandler.Pressed.Contains(Keys.R))
                world = new World();

            world.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            world.Draw(gameTime, spriteBatch);

            //spriteBatch.DrawString(Font, "Test", new Vector2(100, 100), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
