using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Model;
using MyGame;

namespace MyGame.View
{
    public class GameView
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly GraphicsDevice _graphics;
        private Texture2D _busTexture;

        private GameLogic _game;

        public GameView(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            _spriteBatch = spriteBatch;
            _graphics = graphics;
        }

        public void LoadContent(ContentManager content, GameLogic game)
        {
            _busTexture = content.Load<Texture2D>("bus"); // Загрузка текстуры автобуса
            _game = game;
        }

        public void Draw()
        {
            
            _graphics.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(); // Начинаем отрисовку

            foreach (var bus in _game.Buses)
            {
                _spriteBatch.Draw(
                _busTexture,
                position: bus.Position,
                sourceRectangle: null,
                color: Color.White,
                rotation: 3.14f,
                origin: new Vector2(0, 0),
                scale: 0.3f,
                effects: SpriteEffects.FlipVertically,
                layerDepth: 0
            );

            }

            _spriteBatch.End();


        }
    }
}
