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
        private readonly BackgroundModel _backgroundModel;
        private Texture2D _busTexture;
        private Texture2D _carTexture;
        private GameLogic _game;

        public GameView(SpriteBatch spriteBatch, GraphicsDevice graphics, BackgroundModel backgroundModel)
        {
            _spriteBatch = spriteBatch;
            _graphics = graphics;
            _backgroundModel = backgroundModel;
        }

        public void LoadContent(ContentManager content, GameLogic game)
        {
            _busTexture = content.Load<Texture2D>("bus"); // Загрузка текстуры автобуса
            _carTexture = content.Load<Texture2D>("car");
            _game = game;

            // Загрузка текстуры фона
            if (_backgroundModel.Texture == null)
            {
                _backgroundModel.Texture = content.Load<Texture2D>("background");
                _backgroundModel.Position1 = Vector2.Zero;
                _backgroundModel.Position2 = new Vector2(0, _backgroundModel.Texture.Height);
            }
        }

        public void Draw()
        {
            _graphics.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(); // Начинаем отрисовку

            // Отрисовка движущегося фона
            _spriteBatch.Draw(_backgroundModel.Texture, _backgroundModel.Position1, Color.White);
            _spriteBatch.Draw(_backgroundModel.Texture, _backgroundModel.Position2, Color.White);

            foreach (var car in _game.TrafficCars)
            {
                _spriteBatch.Draw(
                    _carTexture,
                    position: car.Position,
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: 3.14f,
                    origin: new Vector2(0, 0),
                    scale: 0.3f,
                    effects: SpriteEffects.FlipVertically,
                    layerDepth: 0
                );

                // Отрисовка всех автобусов
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

            
            }

            _spriteBatch.End();
        }
    }
}
