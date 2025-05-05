using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Model;

namespace MyGame.View
{
    public class MenuView
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _background;

        public MenuView(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _background = MenuModel.Background;
        }

        public void Draw()
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, new Rectangle(0, 0,
                _spriteBatch.GraphicsDevice.Viewport.Width,
                _spriteBatch.GraphicsDevice.Viewport.Height),
                Color.White);

            _spriteBatch.End();
        }
    }
}
