using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Model;
using static System.Net.Mime.MediaTypeNames;

namespace MyGame.View
{
    public class LossView
    {
        private readonly Texture2D _background;
        private readonly SpriteBatch _spriteBatch;

        public LossView(SpriteBatch spriteBatch)
        {
            _background = LossModel.Background;
            _spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background,
                new Rectangle(0, 0,
                _spriteBatch.GraphicsDevice.Viewport.Width,
                _spriteBatch.GraphicsDevice.Viewport.Height),
                Color.White);

            _spriteBatch.End();
        }
    }
}
