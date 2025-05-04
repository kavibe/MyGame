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
    public class PauseView
    {
        private readonly SpriteFont _font;
        private readonly Texture2D _overlay;
        private readonly SpriteBatch _spriteBatch;
        private readonly Viewport _viewport;

        public PauseView(SpriteBatch spriteBatch, Viewport viewport)
        {
            _font = PauseModel.Font;
            _overlay = PauseModel.Background;
            _spriteBatch = spriteBatch;
            _viewport = viewport;
        }

        public void Draw()
        {
            _spriteBatch.Begin();

            //Полупрозрачный оверлей
            _spriteBatch.Draw(_overlay,
                new Rectangle(0, 0,
                _spriteBatch.GraphicsDevice.Viewport.Width,
                _spriteBatch.GraphicsDevice.Viewport.Height),
                Color.White);

            // Текст паузы
            string text = "PAUSED";
            var size = _font.MeasureString(text);
            var position = new Vector2(
                    _spriteBatch.GraphicsDevice.Viewport.Width / 2 - size.X / 2,
                    100);

            _spriteBatch.DrawString(_font, text, position, Color.White);

            _spriteBatch.End();
        }
    }
}
