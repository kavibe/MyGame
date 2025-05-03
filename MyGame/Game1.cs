using System;
using Microsoft.Xna.Framework;
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
        private GameLogic _gameLogic;
        private BackgroundModel _backgroundModel;
        private BackgroundTrafficController _backgroundController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Инициализация моделей
            _model = new GameServices();
            _backgroundModel = new BackgroundModel();
            _gameLogic = new GameLogic(_backgroundModel);

            // Настройка графики
            _graphics.PreferredBackBufferWidth = _model.ScreenWidth;
            _graphics.PreferredBackBufferHeight = _model.ScreenHeight;
            _graphics.ApplyChanges();

            // Инициализация контроллеров
            _controller = new GameController(_model, _graphics, _gameLogic);
            _controller.ExitGame += () => Exit();
            _backgroundController = new BackgroundTrafficController(_backgroundModel, _gameLogic, GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Инициализация представления
            _view = new GameView(_spriteBatch, GraphicsDevice, _backgroundModel, _gameLogic);
            _gameLogic.LoadContentModel(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (_model.IsPaused)
            {
                gameTime = new GameTime(gameTime.TotalGameTime, TimeSpan.Zero);
            }

            base.Update(gameTime);

            _controller.Update(gameTime);
            _backgroundController.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _view.Draw();


            if (_model.IsPaused)
            {
                gameTime = new GameTime(gameTime.TotalGameTime, TimeSpan.Zero);
            }

            base.Draw(gameTime);
        }
    }
}