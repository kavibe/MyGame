using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using MyGame.Model;
using static MyGame.Model.Bus;

namespace MyGame.Controller
{
    public class LossController
    {
        public LossController()
        {
           
        }

        public void Update()
        {
            var keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.F4))
                GameStateManager.Instance.ChangeState(GameState.Menu);
        }
    }
}
