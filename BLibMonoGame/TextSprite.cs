using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BLibMonoGame
{
    public class TextSprite : ISprite
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                
                if (_originCenter)
                {
                    SetOriginToCenter();
                }
            }
        }

        private Vector2 _position;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private SpriteFont _font;

        public SpriteFont Font
        {
            get { return _font; }
            set { _font = value; }
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

        public float Left
        {
            get
            {
                return _position.X - _origin.X;
            }
        }

        public float Top
        {
            get
            {
                return _position.Y - _origin.Y;
            }
        }

        public float Right
        {
            get
            {
                return Left + Width;
            }
        }

        public float Bottom
        {
            get
            {
                return Top + Height;
            }
        }

        public float Width
        {
            get
            {
                return _font.MeasureString(_text).X * _scale.X;
            }
        }

        public float Height
        {
            get
            {
                return _font.MeasureString(_text).Y * _scale.Y;
            }
        }

        private Color _tint;

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
            set
            { 
                _scale = value;
                _origin *= _scale;
            }
        }

        protected Vector2 _origin;

        public Vector2 Origin
        {
            get { return _origin; }
            set 
            { 
                _origin = value;
            }
        }

        protected float _layerDepth;
        public float LayerDepth
        {
            get { return _layerDepth; }
            set { _layerDepth = value; }
        }

        protected bool _visible;

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        protected Rectangle _hitBox;

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
            set
            {
                _hitBox = value; 
            }
        }

        protected SpriteEffects _effect;

        public SpriteEffects SpriteEffect
        {
            get { return _effect; }
            set { _effect = value; }
        }

        private bool _originCenter;

        public void SetOriginToCenter()
        {
            Origin = new Vector2(Width / 2, Height / 2);
            _originCenter = true;
        }

        public TextSprite(SpriteFont font, string text, Vector2 position, Color color)
        {
            _font = font;
            _text = text;
            _scale = Vector2.One;
            _position = position;
            _tint = color;
            _visible = true;
            _effect = SpriteEffects.None;
            _rotation = 0f;
            _origin = Vector2.Zero;
            _layerDepth = 0;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (_visible)
            {
                batch.DrawString(_font, _text, _position, _tint, _rotation, _origin, _scale, _effect, _layerDepth);
            }
        }

    }
}
