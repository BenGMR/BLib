using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLibXNA;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics;

namespace BLibXNA
{
    public class PhysicsSprite : Sprite
    {
        Body _body;
        Texture2D _pixel;
        Rectangle _bodyRectangle;

        public Texture2D PixelTexture
        {
            get
            {
                return _pixel;
            }
            set
            {
                _pixel = value;
            }
        }

        public Body Body
        {
            get
            {
                return _body;
            }
        }

        public Rectangle BodyRectangle
        {
            get
            {
                _bodyRectangle.X = ConvertUnits.ToDisplayUnits(_body.Position.X).ToInt();
                _bodyRectangle.Y = ConvertUnits.ToDisplayUnits(_body.Position.Y).ToInt();
                _bodyRectangle.Width = _texture.Width;
                _bodyRectangle.Height = _texture.Height;
                
                return _bodyRectangle;
            }
        }

        public PhysicsSprite(Texture2D texture, Vector2 position, Color color, World world)
            : base(texture, position, color)
        {
            _body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(Width), ConvertUnits.ToSimUnits(Height), 1);
            _body.Position = ConvertUnits.ToSimUnits(position);
            SetOriginToCenter();
            _bodyRectangle = new Rectangle(ConvertUnits.ToDisplayUnits(_body.Position.X).ToInt(), ConvertUnits.ToDisplayUnits(_body.Position.Y).ToInt(), _texture.Width, _texture.Height);
        }

        public void Dispose()
        {
            _body.Dispose();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position = ConvertUnits.ToDisplayUnits(_body.Position);
            Rotation = _body.Rotation;
        }

        public void DrawBody(SpriteBatch batch)
        {
            if(_pixel == null)
            {
                throw new Exception("You must load the PixelTexture property in order to drawbody");
            }
            batch.Draw(_pixel, BodyRectangle, null, Color.Purple, _body.Rotation, new Vector2(_pixel.Width/2f, _pixel.Height/2f), SpriteEffects.None, _layerDepth);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

        public void Move(Vector2 speed)
        {
            _body.Position += ConvertUnits.ToSimUnits(speed);
        }

        public void ShootInSomeDirection(Vector2 target, float power)
        {
            Vector2 dist = target - Position;
            dist.Normalize();
            dist *= power;
            _body.ApplyLinearImpulse(dist);
        }
    }
}
