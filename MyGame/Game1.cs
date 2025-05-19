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
        private MenuModel _menuModel;
        private LossModel _lossModel;
        private GameLogic _gameLogic;
        private BackgroundModel _backgroundModel;
        private GameView _view;
        private MenuView _menuView;
        private PauseView _pauseView;
        private LossView _lossView;
        private GameController _controller;
        private BackgroundTrafficController _backgroundController;       
        private MenuController _menuController;     
        private LossController _lossController;
        

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
            _lossModel = new LossModel();


            // Настройка графики
            _graphics.PreferredBackBufferWidth = _model.ScreenWidth;
            _graphics.PreferredBackBufferHeight = _model.ScreenHeight;
            _graphics.ApplyChanges();

            // Инициализация контроллеров
            _controller = new GameController(_model, _graphics, _gameLogic, _lossModel);
            _backgroundController = new BackgroundTrafficController(_backgroundModel, _gameLogic, GraphicsDevice);
            _menuController = new MenuController();
            _lossController = new LossController();

            _controller.ExitGame += () => Exit();
            _menuController.ExitGame += () => Exit();
            
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameLogic.LoadContentModel(Content);

            _view = new GameView(_spriteBatch, GraphicsDevice, _backgroundModel, _gameLogic);
            _menuView = new MenuView(_spriteBatch);
            _pauseView = new PauseView(_spriteBatch);
            _lossView = new LossView(_spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            GameStateManager.UpdateController(_menuController, _controller, _backgroundController, gameTime, _model, _lossController, GameServices.Music);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameStateManager.UpdateDraw(_menuView, _view, _pauseView, _lossView);

            base.Draw(gameTime);
        }

        
    }
}