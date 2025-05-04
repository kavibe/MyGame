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
        private GameState CurrentState { get; set; } = GameState.Menu;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // MVC Компоненты
        private GameServices _model;
        private GameView _view;
        private GameController _controller;
        private GameLogic _gameLogic;
        private BackgroundModel _backgroundModel;
        private BackgroundTrafficController _backgroundController;
        private MenuModel _menuModel;
        private MenuController _menuController; 
        private MenuView _menuView;
        private PauseView _pauseView;

        private Viewport _viewport;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameStateManager.Instance.OnStateChanged += GameStateManager.HandleGameStateChange;

            // Инициализация моделей
            _model = new GameServices();
            _backgroundModel = new BackgroundModel();
            _gameLogic = new GameLogic(_backgroundModel);
            _menuModel = new MenuModel();

            // Настройка графики
            _graphics.PreferredBackBufferWidth = _model.ScreenWidth;
            _graphics.PreferredBackBufferHeight = _model.ScreenHeight;
            _graphics.ApplyChanges();

            // Инициализация контроллеров
            _controller = new GameController(_model, _graphics, _gameLogic);
            _controller.ExitGame += () => Exit();
            _backgroundController = new BackgroundTrafficController(_backgroundModel, _gameLogic, GraphicsDevice);
            _menuController = new MenuController(_menuModel);
            _menuController.ExitGame += () => Exit();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameLogic.LoadContentModel(Content);

            _view = new GameView(_spriteBatch, GraphicsDevice, _backgroundModel, _gameLogic);
            _menuView = new MenuView(_menuModel, _spriteBatch);
            _viewport = new Viewport();
            _pauseView = new PauseView(_spriteBatch, _viewport);
        }

        protected override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);

            GameStateManager.UpdateController(_menuController, _controller, _backgroundController, gameTime, _model);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_model.IsPaused)
            {
                gameTime = new GameTime(gameTime.TotalGameTime, TimeSpan.Zero);
            }

            GameStateManager.UpdateDraw(_menuView, _view, _pauseView);

            base.Draw(gameTime);
        }

        
    }
}