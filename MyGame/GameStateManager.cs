using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Controller;
using MyGame.Model;
using MyGame.View;

namespace MyGame
{
    public enum GameState{ Menu, Playing, Paused}
    public class GameStateManager
    {
        private static GameStateManager _instance;
        public static GameStateManager Instance => _instance ??= new GameStateManager();

        public GameState CurrentState { get; set; }

        public event Action<GameState> OnStateChanged;

        private GameStateManager() { }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            OnStateChanged?.Invoke(newState);
        }

        public static void UpdateController(MenuController _menuController, GameController _controller, BackgroundTrafficController _backgroundController, GameTime gameTime, GameServices _model)
        {
            switch (Instance.CurrentState)
            {
                case GameState.Menu:
                    _menuController.Update(gameTime);
                    break;

                case GameState.Playing:
                    _controller.Update(gameTime);
                    _backgroundController.Update(gameTime);
                    break;

                case GameState.Paused:
                    if (_model.IsPaused)
                        gameTime = new GameTime(gameTime.TotalGameTime, TimeSpan.Zero);

                    _controller.Update(gameTime);
                    _backgroundController.Update(gameTime);
                    break;
            }
        }

        public static void UpdateDraw(MenuView _menuView, GameView _view, PauseView _pauseView)
        {
            switch (Instance.CurrentState)
            {
                case GameState.Menu:
                    _menuView.Draw();
                    break;

                case GameState.Playing:
                    _view.Draw();
                    break;

                case GameState.Paused:
                    _view.Draw();
                    _pauseView.Draw();

                    

                    break;
            }
        }

        public static void HandleGameStateChange(GameState newState)
        {
            // Дополнительная логика при смене состояния
            switch (newState)
            {
                case GameState.Playing:
                    // Инициализация новой игры
                    break;
            }
        }
    }
}
