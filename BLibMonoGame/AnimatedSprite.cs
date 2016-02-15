using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BLibMonoGame
{
    public class AnimatedSprite : Sprite
    {
        public AnimatedSprite(Texture2D texture, Vector2 position, Color color)
            : base(texture, position, color)
        {
            _frames = new List<Rectangle>();
        }
        
        private TimeSpan _elapsedTime;

        private TimeSpan _timePerFrame;
        public TimeSpan TimePerFrame
        {
            get
            {
                return _timePerFrame;
            }
            set
            {
                _timePerFrame = value;
            }
        }

        private List<Rectangle> _frames;

        public List<Rectangle> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }


         private int _currentFrame;

         public int CurrentFrame
         {
             get { return _currentFrame; }
             set { _currentFrame = value; }
         }

        public event EventHandler AnimationCompleted;

        public override void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime >= _timePerFrame)
            {
                _currentFrame++;

                if (_currentFrame >= _frames.Count)
                {
                    _currentFrame = 0;
                    if (AnimationCompleted != null)
                    {
                        AnimationCompleted(this, null);
                    }
                }
                _frame = _frames[_currentFrame];
                _elapsedTime = TimeSpan.Zero;
            }
        }

    }
}
