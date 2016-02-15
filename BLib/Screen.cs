using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BLibXNA
{
    public abstract class Screen : Sprite
    {
        private List<ISprite> _sprites;

        public List<ISprite> Sprites
        {
            get
            {
                return _sprites;
            }
        }
        /// <summary>
        /// Base class for any screen
        /// </summary>
        /// <param name="texture">The background texture</param>
        /// <param name="position">The position of the screen</param>
        /// <param name="color">The color of the screen</param>
        public Screen(Texture2D texture, Vector2 position, Color color)
            :base(texture, position, color)
        {
            _sprites = new List<ISprite>();
        }
        /// <summary>
        /// Updates the current screen.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (ISprite sprite in _sprites)
            {
                sprite.Update(gameTime);
            }
            //update all sprites here
        }

        /// <summary>
        /// Draws the current screen.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (ISprite sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public virtual void Initialize()
        {

        }
    }
}
