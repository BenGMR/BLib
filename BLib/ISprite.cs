﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BLibXNA
{
    public interface ISprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch batch);
    }
}
