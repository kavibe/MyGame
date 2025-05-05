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
        private readonly InputAction _pauseAction;
        private readonly InputAction _fullscreenAction;
        private readonly LossModel _lossModel;


        public GameController(GameServices model, GraphicsDeviceManager graphics, GameLogic game, LossModel lossModel)
        {
            _model = model;
            _graphics = graphics;
            _game = game;
            _lossModel = lossModel;
            _pauseAction = new InputAction(new[] { Keys.Escape }, true);
            _fullscreenAction = new InputAction(new[] { Keys.F11 });

        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            //CollisionCheck(); // Пока работает не совсем как надо

            _pauseAction.Update();
            _fullscreenAction.Update();
            
            HandleGlobalInput();
            HandleGameInput(gameTime);
        }

        private void HandleGlobalInput()
        {
            if (_pauseAction.IsTriggered && GameStateManager.Instance.CurrentState != GameState.Menu)
                TogglePause();

            if (_fullscreenAction.IsTriggered)
                ToggleFullscreen();

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

        public void CollisionCheck()
        {
            if (_game.Players[0].Bus.Position.Intersects(_game.TrafficCarsPlayer1[0].Position) ||
                 _game.Players[0].Bus.Position.Intersects(_game.TrafficCarsPlayer1[1].Position) ||
                 _game.Players[0].Bus.Position.Intersects(_game.TrafficCarsPlayer1[2].Position) ||
                 _game.Players[0].Bus.Position.Intersects(_game.TrafficCarsPlayer1[3].Position) ||
                 _game.Players[1].Bus.Position.Intersects(_game.TrafficCarsPlayer2[0].Position) ||
                 _game.Players[1].Bus.Position.Intersects(_game.TrafficCarsPlayer2[1].Position) ||
                 _game.Players[1].Bus.Position.Intersects(_game.TrafficCarsPlayer2[2].Position) ||
                 _game.Players[1].Bus.Position.Intersects(_game.TrafficCarsPlayer2[3].Position))
                _lossModel.IsLose = true;

            if (_lossModel.IsLose)
                GameStateManager.Instance.ChangeState(GameState.Loss);

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
}
