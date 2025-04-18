﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Controller;
using MyGame.Model;
using MyGame.View;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // MVC Компоненты
        private GameServices _model;
        private GameView _view;
        private GameController _controller;
        private GameLogic _game;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Инициализация MVC
            _model = new GameServices();
            _game = new GameLogic();
            _controller = new GameController(_model, _graphics, _game);
            _controller.ExitGame += () => Exit();

            _graphics.PreferredBackBufferWidth = _model.ScreenWidth;  // Ширина окна
            _graphics.PreferredBackBufferHeight = _model.ScreenHeight; // Высота окна
            _graphics.ApplyChanges(); // Применяем изменения

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _view = new GameView(_spriteBatch, GraphicsDevice);
            _view.LoadContent(Content, _game);
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.HandleInput(gameTime); // Обработка ввода
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _view.Draw(); // Отрисовка
            base.Draw(gameTime);
        }
    }

}
