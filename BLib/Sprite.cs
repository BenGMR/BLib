using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BLibXNA
{
    public class Sprite : ISprite
    {
        protected Texture2D _texture;

        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        protected Vector2 _position;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        protected Color _tint;

        public Color Tint
        {
            get { return _tint; }
            set { _tint = value; }
        }

        protected float _rotation;

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        protected Vector2 _scale;

        public Vector2 Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        private Vector2 _origin;

        public Vector2 Origin
        {
            get { return _origin * Scale; }
            set { _origin = value; _origin *= Scale; }
        }

        protected SpriteEffects _effect;

        public SpriteEffects SpriteEffect
        {
            get { return _effect; }
            set { _effect = value; }
        }



        private Rectangle _hitBox;

        public Rectangle HitBox
        {
            get 
            {
                _hitBox.X = Left.ToInt();
                _hitBox.Y = Top.ToInt();
                _hitBox.Width = Width.ToInt();
                _hitBox.Height = Height.ToInt();
                return _hitBox; 
            }
        }

        public float Radius
        {
            get
            {
                if (Height > Width)
                {
                    return Height / 2;
                }
                return Width / 2;
            }
        }

        protected bool _visible;

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public float Left
        {
            get
            {
                return X - Origin.X;
            }
        }

        public float Top
        {
            get
            {
                return Y - Origin.Y;
            }
        }
        public float Right
        {
            get
            {
                return (Left + Width);
            }
        }

        public float Bottom
        {
            get
            {
               return (Top + Height);
            }
        }

        public float X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
            }
        }

        public float Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }

        public float Width
        {
            get
            {
                if (_frame == null)
                {
                    return _texture.Width * Scale.X;
                }
                return _frame.Value.Width * Scale.X;
            }
        }

        public float Height
        {
            get
            {
                if (_frame == null)
                {
                    return _texture.Height * Scale.Y;
                }
                return _frame.Value.Height * Scale.Y;
            }
        }

        protected Rectangle? _frame;
        public Rectangle? Frame
        {
            get
            {
                return _frame;
            }
            set
            {
                _frame = value;
            }
        }

        protected float _layerDepth;
        public float LayerDepth
        {
            get { return _layerDepth; }
            set { _layerDepth = value; }
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (_visible)
            {
                batch.Draw(_texture, _position, _frame, _tint, _rotation, Origin, _scale, _effect, _layerDepth);
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            _texture = texture;
            _position = position;
            _tint = color;
            _visible = true;
            _scale = Vector2.One;
            _frame = null;
            _effect = SpriteEffects.None;
            _rotation = 0f;
            Origin = Vector2.Zero;
        }


        public void SetOriginToCenter()
        {
            if (_frame == null)
            {
                 Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
                return;
            }
            Origin = new Vector2(_frame.Value.Width / 2, _frame.Value.Height / 2);
        }
    }
}
