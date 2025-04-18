﻿using System;
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
                _game.Players[0].Bus.Turn(deltaTime, Bus.TurnDirection.Left);
            if (keyboardState.IsKeyDown(Keys.D))
                _game.Players[0].Bus.Turn(deltaTime, Bus.TurnDirection.Right);

            if (keyboardState.IsKeyDown(Keys.Left))
                _game.Players[1].Bus.Turn(deltaTime, TurnDirection.Left);
            if (keyboardState.IsKeyDown(Keys.Right))
                _game.Players[1].Bus.Turn(deltaTime, TurnDirection.Right);


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
