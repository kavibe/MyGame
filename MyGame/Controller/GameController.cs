using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyGame.Model;
using MyGame.View;
using static MyGame.Model.Bus;

namespace MyGame.Controller
{
    public class GameController
    {
        private readonly GameServices _model;
        private readonly GraphicsDeviceManager _graphics;

        private readonly GameLogic _game;


        public GameController(GameServices model, GraphicsDeviceManager graphics, GameLogic game)
        {
            _model = model;
            _graphics = graphics;
            _game = game;
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.Escape))
                ExitGame?.Invoke();

            if (keyboardState.IsKeyDown(Keys.F11))
            {
                _model.ToggleFullScreen();
                ApplyScreenSettings();
            }

            if (keyboardState.IsKeyDown(Keys.A))
                _game.Players[0].Bus.Drive(deltaTime, Bus.DriveDirection.Left);
            if (keyboardState.IsKeyDown(Keys.D))
                _game.Players[0].Bus.Drive(deltaTime, Bus.DriveDirection.Right);

            if (keyboardState.IsKeyDown(Keys.Left))
                _game.Players[1].Bus.Drive(deltaTime, DriveDirection.Left);
            if (keyboardState.IsKeyDown(Keys.Right))
                _game.Players[1].Bus.Drive(deltaTime, DriveDirection.Right);

            if (keyboardState.IsKeyDown(Keys.W))
                _game.Players[0].Bus.Drive(deltaTime, Bus.DriveDirection.Straight);
            if (keyboardState.IsKeyDown(Keys.S))
                _game.Players[0].Bus.Drive(deltaTime, Bus.DriveDirection.Back);
            if (keyboardState.IsKeyDown(Keys.Up))
                _game.Players[1].Bus.Drive(deltaTime, Bus.DriveDirection.Straight);
            if (keyboardState.IsKeyDown(Keys.Down))
                _game.Players[1].Bus.Drive(deltaTime, Bus.DriveDirection.Back);


        }

        private void ApplyScreenSettings()
        {
            _graphics.PreferredBackBufferWidth = _model.ScreenWidth;
            _graphics.PreferredBackBufferHeight = _model.ScreenHeight;
            _graphics.IsFullScreen = _model.IsFullScreen;
            _graphics.ApplyChanges();
        }

        public event Action ExitGame;
    }

    public class BackgroundController
    {
        private readonly BackgroundModel _model;

        public BackgroundController(BackgroundModel model)
        {
            _model = model;
        }

        public void Update(GameTime gameTime)
        {
            float delta = _model.ScrollSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Обновляем позиции через свойства
            _model.Position1 = new Vector2(_model.Position1.X, _model.Position1.Y + delta);
            _model.Position2 = new Vector2(_model.Position2.X, _model.Position2.Y + delta);

            if (_model.Position1.Y >= _model.Texture.Height)
                _model.Position1 = new Vector2(_model.Position1.X,
                    _model.Position2.Y - _model.Texture.Height);

            if (_model.Position2.Y >= _model.Texture.Height)
                _model.Position2 = new Vector2(_model.Position2.X,
                    _model.Position1.Y - _model.Texture.Height);
        }
    }
}
