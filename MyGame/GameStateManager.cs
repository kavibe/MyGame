using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MyGame.Controller;
using MyGame.Model;
using MyGame.View;

namespace MyGame
{
    public enum GameState{ Menu, Playing, Paused, Loss}
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

        public static void UpdateController(MenuController _menuController, GameController _controller, BackgroundTrafficController _backgroundController, 
            GameTime gameTime, GameServices _model, LossController _lossController, Song _music)
        {
            switch (Instance.CurrentState)
            {
                case GameState.Menu:
                    
                    _menuController.Update(gameTime);
                    _controller.Update(gameTime);
                    MediaPlayer.Play(_music);
                    MediaPlayer.IsRepeating = true;
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

                case GameState.Loss:
                    gameTime = new GameTime(gameTime.TotalGameTime, TimeSpan.Zero);
                    _lossController.Update();
                    break;

            }
        }

        public static void UpdateDraw(MenuView _menuView, GameView _view, PauseView _pauseView, LossView _lossView)
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

                case GameState.Loss:
                    _view.Draw();
                    _lossView.Draw();
                    break;
            }
        }

        public static void HandleGameStateChange(GameState newState)
        {
            // Дополнительная логика при смене состояния
            switch (newState)
            {
                case GameState.Playing:
                    break;
            }
        }
    }
}
