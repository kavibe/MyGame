using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MyGame.Model;

namespace MyGame.Controller
{
    public class BackgroundTrafficController
    {
        private readonly BackgroundModel _model;
        private readonly GameLogic _gameLogic;
        private readonly GraphicsDevice _graphicsDevice;

        public BackgroundTrafficController(BackgroundModel model, GameLogic gameLogic, GraphicsDevice graphicsDevice)
        {
            _model = model;
            _gameLogic = gameLogic;
            _graphicsDevice = graphicsDevice;
        }

        public void Update(GameTime gameTime)
        {
            UpdateBackground(gameTime);
            UpdateTrafficCar(gameTime);
        }

        private void UpdateBackground(GameTime gameTime)
        {
            float delta = _model.ScrollSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Обновление позиции заднего фона
            _model.Position1 = new Vector2(_model.Position1.X, _model.Position1.Y + delta);
            _model.Position2 = new Vector2(_model.Position2.X, _model.Position2.Y + delta);

            if (_model.Position1.Y >= _model.Texture.Height)
                _model.Position1 = new Vector2(_model.Position1.X,
                    _model.Position2.Y - _model.Texture.Height);

            if (_model.Position2.Y >= _model.Texture.Height)
                _model.Position2 = new Vector2(_model.Position2.X,
                    _model.Position1.Y - _model.Texture.Height);
        }

        public void UpdateTrafficCar(GameTime gameTime)
        {
            //Intersects();
            foreach (var car in _gameLogic.TrafficCarsList)
            {
                float backgroundSpeed = _model.ScrollSpeed;
                float delta = GetTrafficCarSpeed(backgroundSpeed) * (float)gameTime.ElapsedGameTime.TotalSeconds;

                car.Position = new Rectangle(
                    car.Position.X,
                    car.Position.Y + (int)delta,
                    car.Position.Width,
                    car.Position.Height
                );

                if (car.Position.Y > _graphicsDevice.Viewport.Height + 100)
                    RespawnCar(car);
            }
        }

        private void RespawnCar(TrafficCars car)
        {
            Random random = new Random();

            if (_gameLogic.Players[0].TrafficCars.Contains(car))
            {
                car.Position = new Rectangle(
                    random.Next(280, 820),
                    0 - car.Position.Height,
                    car.Position.Width,
                    car.Position.Height
                );
            }
            else
            {
                car.Position = new Rectangle(
                    random.Next(1220, 1860),
                    0 - car.Position.Height,
                    car.Position.Width,
                    car.Position.Height
                );
            }
        }

        private float GetTrafficCarSpeed(float backgroundSpeed)
        {
            Random random = new Random();
            return backgroundSpeed + random.Next(50, 150);
        }

        //public void Intersects()
        //{
        //    if (Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[0].Position) ||
        //        Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[1].Position) ||
        //        Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[2].Position) ||
        //        Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[3].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[0].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[1].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[2].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[3].Position)) 
        //        _model.PutPause();
        //}
    }
}
