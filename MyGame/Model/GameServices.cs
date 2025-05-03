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
        private bool _isFullScreen;
        private int _screenWidth = 1920;
        private int _screenHeight = 1080;
        private bool _isPaused  = false;

        public bool IsPaused
        {
            get => _isPaused; 
            set => _isPaused = value;
        }

        public int ScreenHeight
        {
            get => _screenHeight;
            set => _screenHeight = value;
        }

        public int ScreenWidth
        {
            get => _screenWidth;
            set => _screenWidth = value;
        }

        public bool IsFullScreen
        {
            get => _isFullScreen; 
            set => _isFullScreen = value;
        }
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
