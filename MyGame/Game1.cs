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
        private BackgroundController _backgroundController;

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
            _gameLogic = new GameLogic();
            _backgroundModel = new BackgroundModel();

            // Настройка графики
            _graphics.PreferredBackBufferWidth = _model.ScreenWidth;
            _graphics.PreferredBackBufferHeight = _model.ScreenHeight;
            _graphics.ApplyChanges();

            // Инициализация контроллеров
            _controller = new GameController(_model, _graphics, _gameLogic);
            _controller.ExitGame += () => Exit();
            _backgroundController = new BackgroundController(_backgroundModel);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Загрузка контента для фона
            _backgroundModel.Texture = Content.Load<Texture2D>("road2");
            _backgroundModel.Position1 = Vector2.Zero;
            _backgroundModel.Position2 = new Vector2(0, _backgroundModel.Texture.Height);

            // Инициализация представления
            _view = new GameView(_spriteBatch, GraphicsDevice, _backgroundModel);
            _view.LoadContent(Content, _gameLogic);
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.HandleInput(gameTime);
            _backgroundController.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _view.Draw();
            base.Draw(gameTime);
        }
    }
}