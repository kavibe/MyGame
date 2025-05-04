using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyGame.Model;

namespace MyGame.Controller
{
    public class MenuController
    {
        private readonly MenuModel _model;

        public MenuController(MenuModel model)
        {
            _model = model;
        }

        public void Update(GameTime gameTime)
        {
            if (GameStateManager.Instance.CurrentState == GameState.Menu && Keyboard.GetState().IsKeyDown(Keys.Enter))
                GameStateManager.Instance.CurrentState = GameState.Playing;

            if (Keyboard.GetState().IsKeyDown(Keys.F4) && (GameStateManager.Instance.CurrentState == GameState.Menu))
                ExitGame?.Invoke();
        }

        public event Action ExitGame;
    }
}
