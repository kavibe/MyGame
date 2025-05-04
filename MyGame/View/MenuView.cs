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
        private readonly MenuModel _model;
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteFont _font;
        private readonly Texture2D _background;

        public MenuView(MenuModel model, SpriteBatch spriteBatch)
        {
            _model = model;
            _spriteBatch = spriteBatch;
            _font = MenuModel.Font;
            _background = MenuModel.Background;
        }

        public void Draw()
        {
            _spriteBatch.Begin();
            // Фон
            _spriteBatch.Draw(_background, new Rectangle(0, 0,
                _spriteBatch.GraphicsDevice.Viewport.Width,
                _spriteBatch.GraphicsDevice.Viewport.Height),
                Color.White);

            // Заголовок
            var titleSize = _font.MeasureString(_model.Title);
            _spriteBatch.DrawString(_font, _model.Title,
                new Vector2(
                    _spriteBatch.GraphicsDevice.Viewport.Width / 2 - titleSize.X / 2,
                    100),
                Color.Gold);

            _spriteBatch.End();
        }
    }
}
