using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyGame.Model;
using MyGame.View;

namespace MyGame.Controller
{
    public class GameController
    {
        private readonly GameServices _model;
        private readonly GraphicsDeviceManager _graphics;

        public GameController(GameServices model, GraphicsDeviceManager graphics)
        {
            _model = model;
            _graphics = graphics;
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
                GameView.Position.X -= GameView.MoveSpeed * deltaTime;
            if (keyboardState.IsKeyDown(Keys.D))
                GameView.Position.X += GameView.MoveSpeed * deltaTime;


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
}
