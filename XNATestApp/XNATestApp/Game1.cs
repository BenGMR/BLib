using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BLibXNA;
using FarseerPhysics.Dynamics;

namespace XNATestApp
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite testSprite;
        TextSprite text;
        TextSprite coords;
        Vector2 speed;
        PhysicsSprite circle;
        World world;
        PhysicsSprite platform1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            testSprite = new Sprite(Content.Load<Texture2D>("WhiteCircle100x100"), new Vector2(100, 100), Color.White);
            coords = new TextSprite(Content.Load<SpriteFont>("DebugFont"), "", new Vector2(0, 0), Color.Red);
            text = new TextSprite(Content.Load<SpriteFont>("DebugFont"), "Tasdasd", new Vector2(200, 200), Color.White);
            speed = new Vector2(5, 5);
            testSprite.SetOriginToCenter();

            world = new World(new Vector2(0, 9.8f));

            circle = new PhysicsSprite(Content.Load<Texture2D>("WhiteCircle100x100"), Vector2.Zero, Color.Red, world);
            circle.Body.BodyType = BodyType.Dynamic;
            circle.PixelTexture = Content.Load<Texture2D>("pixel");
            circle.Body.OnCollision += Body_OnCollision;

            platform1 = new PhysicsSprite(Content.Load<Texture2D>("WhiteBar700x15"), new Vector2(0, 400), Color.White, world);
            platform1.Body.BodyType = BodyType.Static;
            platform1.Body.CollidesWith = Category.Cat1;
            
            //text.Scale = new Vector2(2, 2);
            
        }

        bool Body_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            return true;
        }

        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();
            //taken straight from a farseer example
            // variable time step but never less then 30 Hz
            world.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalSeconds, (1f / 30f)));

            circle.Update(gameTime);

            platform1.Update(gameTime);

            if (InputManager.KeyJustPressed(Keys.Right))
            {
                circle.Body.ApplyLinearImpulse(new Vector2(1, 0));
            }
            else if (InputManager.KeyJustPressed(Keys.Up))
            {
                circle.Body.ApplyLinearImpulse(new Vector2(0, -1));
            }
            else if (InputManager.KeyJustPressed(Keys.Down))
            {
                circle.Body.Rotation += 1;
            }
            Rectangle mouseRect = new Rectangle(InputManager.MousePosition.X.ToInt(), InputManager.MousePosition.Y.ToInt(), 1, 1);

            coords.Text = string.Format("X: {0} Y: {1}", InputManager.MousePosition.X, InputManager.MousePosition.Y);

            #region BouncingCircle
            testSprite.Position += speed;

            if (testSprite.Bottom >= GraphicsDevice.Viewport.Height || testSprite.Top <= 0)
            {
                speed.Y *= -1;
            }
            if (testSprite.Right >= GraphicsDevice.Viewport.Width || testSprite.Left <= 0)
            {
                speed.X *= -1;
            }
            #endregion BouncingCircle

            if (mouseRect.Intersects(text.HitBox))
            {
                text.Tint = Color.Red;
                //text.UseCenterOrigin = true;
            }
            else
            {
                text.Tint = Color.White;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            testSprite.Draw(spriteBatch);
            text.Draw(spriteBatch);
            coords.Draw(spriteBatch);
            circle.Draw(spriteBatch);
            circle.DrawBody(spriteBatch);

            platform1.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
