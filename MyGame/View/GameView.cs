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
using static System.Net.Mime.MediaTypeNames;

namespace MyGame.View
{
    public class GameView
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly GraphicsDevice _graphics;
        private readonly BackgroundModel _backgroundModel;
        private readonly GameLogic _game;


        public GameView(SpriteBatch spriteBatch, GraphicsDevice graphics, BackgroundModel backgroundModel, GameLogic game)
        {
            _spriteBatch = spriteBatch;
            _graphics = graphics;
            _backgroundModel = backgroundModel;
            _game = game;
        }

        public void Draw()
        {
            _graphics.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin();

            // Отрисовка движущегося фона
            _spriteBatch.Draw(_backgroundModel.Texture, _backgroundModel.Position1, Color.White);
            _spriteBatch.Draw(_backgroundModel.Texture, _backgroundModel.Position2, Color.White);

            foreach (var car in _game.TrafficCarsList)
            {
                _spriteBatch.Draw(
                    TrafficCars.Texture,
                    destinationRectangle:car.Position,
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: 3.14f,
                    origin: new Vector2(0, 0),
                    effects: SpriteEffects.FlipVertically,
                    layerDepth: 0
                );

                foreach (var bus in _game.Buses)
                {
                    _spriteBatch.Draw(
                        Bus.Texture,
                        destinationRectangle: bus.Position,
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: 3.14f,
                        origin: new Vector2(0, 0),
                        effects: SpriteEffects.FlipVertically,
                        layerDepth: 0
                    );
                }
            }

            _spriteBatch.End();
        }
    }
}
