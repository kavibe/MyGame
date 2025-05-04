using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

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
    }

    public class PauseModel
    {
        private static Texture2D _background;
        private static SpriteFont _font;
        private Vector2 _position;
        private string _title = "Pause";

        public static Texture2D Background
        {
            get => _background;
            set => _background = value;
        }

        public static SpriteFont Font
        {
            get => _font;
            set => _font = value;
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }
    }

}
