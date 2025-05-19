using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyGame.Model;
using Microsoft.Xna.Framework.Media;

namespace MyGame.Controller
{
    public class MenuController
    {

        public MenuController()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (GameStateManager.Instance.CurrentState == GameState.Menu && Keyboard.GetState().IsKeyDown(Keys.Space))
                GameStateManager.Instance.CurrentState = GameState.Playing;

            if (Keyboard.GetState().IsKeyDown(Keys.F4) && (GameStateManager.Instance.CurrentState == GameState.Menu))
                ExitGame?.Invoke();

            
        }

        public event Action ExitGame;
    }
}
