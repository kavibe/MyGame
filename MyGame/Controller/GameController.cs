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
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Controller
{
    public class GameController
    {
        private readonly GameServices _model;
        private readonly GraphicsDeviceManager _graphics;
        private readonly GameLogic _game;
        private InputAction _pauseAction;
        private InputAction _fullscreenAction;


        public GameController(GameServices model, GraphicsDeviceManager graphics, GameLogic game)
        {
            _model = model;
            _graphics = graphics;
            _game = game;
            _pauseAction = new InputAction(new[] { Keys.Escape }, true);
            _fullscreenAction = new InputAction(new[] { Keys.F11 });
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            _pauseAction.Update();
            _fullscreenAction.Update();
            
            HandleGlobalInput();
            HandleGameInput(gameTime);
        }

        public void PutPause()
        {
            _model.IsPaused = !_model.IsPaused;
        }

        private void HandleGlobalInput()
        {
            if (_pauseAction.IsTriggered)
                TogglePause();

            if (_fullscreenAction.IsTriggered)
                ToggleFullscreen();

            //if (Keyboard.GetState().IsKeyDown(Keys.F4) && (GameStateManager.Instance.CurrentState == GameState.Playing))
            //    ExitGame?.Invoke();

            if (Keyboard.GetState().IsKeyDown(Keys.F4) && GameStateManager.Instance.CurrentState == GameState.Paused)
                GameStateManager.Instance.ChangeState(GameState.Menu);

        }

        private void HandleGameInput(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))
                DriveBus(_game.Players[0].Bus, deltaTime, DriveDirection.Left);
            if (keyboardState.IsKeyDown(Keys.D))
                DriveBus(_game.Players[0].Bus, deltaTime, DriveDirection.Right);
            if (keyboardState.IsKeyDown(Keys.W))
                DriveBus(_game.Players[0].Bus, deltaTime, DriveDirection.Straight);
            if (keyboardState.IsKeyDown(Keys.S))
                DriveBus(_game.Players[0].Bus, deltaTime, DriveDirection.Back);

            if (keyboardState.IsKeyDown(Keys.Left))
                DriveBus(_game.Players[1].Bus, deltaTime, DriveDirection.Left);
            if (keyboardState.IsKeyDown(Keys.Right))
                DriveBus(_game.Players[1].Bus, deltaTime, DriveDirection.Right);
            if (keyboardState.IsKeyDown(Keys.Up))
                DriveBus(_game.Players[1].Bus, deltaTime, DriveDirection.Straight);
            if (keyboardState.IsKeyDown(Keys.Down))
                DriveBus(_game.Players[1].Bus, deltaTime, DriveDirection.Back);
        }

        public void TogglePause()
        {
            _model.IsPaused = !_model.IsPaused;

            if (_model.IsPaused)
                GameStateManager.Instance.ChangeState(GameState.Paused);

            else
                GameStateManager.Instance.ChangeState(GameState.Playing);
        }


        public void ToggleFullscreen()
        {
            _model.ToggleFullScreen();
            ApplyScreenSettings();
        }

        private void DriveBus(Bus bus, float deltaTime, DriveDirection direction)
        {
            float moveLeft = -TurningSpeed * deltaTime;
            float moveRight = TurningSpeed * deltaTime;
            float moveUp = -(BoostSpeed - 60f) * deltaTime;
            float moveDown = (BoostSpeed + 50f) * deltaTime; 

            // Временный прямоугольник для проверки границ
            Rectangle newPosition = bus.Position;

            switch (direction)
            {
                case DriveDirection.Left:
                    newPosition.X += (int)moveLeft;
                    break;
                case DriveDirection.Right:
                    newPosition.X += (int)moveRight;
                    break;
                case DriveDirection.Straight:
                    newPosition.Y += (int)moveUp;
                    break;
                case DriveDirection.Back:
                    newPosition.Y += (int)moveDown;
                    break;
            }

            if (newPosition.X < bus.Bounds.X)
                newPosition.X = bus.Bounds.X;
            else if (newPosition.X + newPosition.Width > bus.Bounds.X + bus.Bounds.Width)
                newPosition.X = bus.Bounds.X + bus.Bounds.Width - newPosition.Width;

            if (newPosition.Y < bus.Bounds.Y)
                newPosition.Y = bus.Bounds.Y;
            else if (newPosition.Y + newPosition.Height > bus.Bounds.Y + bus.Bounds.Height)
                newPosition.Y = bus.Bounds.Y + bus. Bounds.Height - newPosition.Height;

            // Обновление позиции
            bus.Position = newPosition;
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

    public class InputAction
    {
        private readonly Keys[] _keys;
        private readonly bool _singleTrigger;
        private bool _wasPressed;

        public bool IsTriggered { get; private set; }

        public InputAction(Keys[] keys, bool singleTrigger = false)
        {
            _keys = keys;
            _singleTrigger = singleTrigger;
        }

        public void Update()
        {
            IsTriggered = false;
            bool isPressed = _keys.Any(key => Keyboard.GetState().IsKeyDown(key));

            if (isPressed && (!_wasPressed || !_singleTrigger))
            {
                IsTriggered = true;
            }

            _wasPressed = isPressed;
        }
    }
}
