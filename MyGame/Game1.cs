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
            _controller = new GameController(_model, _graphics);
            _controller.ExitGame += () => Exit();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _view = new GameView(_spriteBatch, GraphicsDevice);
            _view.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.HandleInput(gameTime); // Обработка ввода
            //_view.HandleInput(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _view.Draw(); // Отрисовка
            base.Draw(gameTime);
        }
    }

}
