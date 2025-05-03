using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGame.Model
{
    public class GameServices
    {
        public bool IsFullScreen { get; set; }
        public int ScreenWidth { get; set; } = 1920;
        public int ScreenHeight { get; set; } = 1080;
        public bool IsPaused { get; set; } = false;

        public void ToggleFullScreen()
        {
            IsFullScreen = !IsFullScreen;
        }

        public void PutPause()
        {
            IsPaused = !IsPaused;
        }
    }
}
