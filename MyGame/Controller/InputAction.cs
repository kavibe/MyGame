using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Controller
{
    public class InputAction
    {
        private readonly Keys[] _keys;
        private readonly bool _singleTrigger;
        private bool _wasPressed;

        public bool IsTriggered { get; private set; }

        public InputAction(Keys[] keys, bool singleTrigger = false)
        {
            _keys = keys;
            _singleTrigger = singleTrigger;
        }

        public void Update()
        {
            IsTriggered = false;
            bool isPressed = _keys.Any(key => Keyboard.GetState().IsKeyDown(key));

            if (isPressed && (!_wasPressed || !_singleTrigger))
                IsTriggered = true;

            _wasPressed = isPressed;
        }
    }
}
