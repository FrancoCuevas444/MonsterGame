using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonsterGame
{
    // TODO : Work on Shuriken
    // Finish AI
    // Get damage
    // Add R
    // Add Game over/ win screen
    // Add Menu
    // Add animations
    // Add Audio

    public class MonsterGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        UITop ui;
        Floor floor;
        Enemy enemy;
        public const int screenWidth = 1280, screenHeight = 720;

        public MonsterGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {


            base.Initialize();
        }
        
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ResourceLoader.LoadResources(Content);
            player = new Player();
            floor = new Floor();
            ui = new UITop(player);
            enemy = new Enemy(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update(gameTime);
            floor.Update(gameTime);
            ui.Update(gameTime);
            enemy.Update(gameTime);
            if (player.IsGrounded == false) floor.CheckGrounded(player);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            floor.Draw(spriteBatch);
            player.Draw(spriteBatch);
            ui.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
