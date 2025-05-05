using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Model
{
    public class MenuModel
    {
        private static Texture2D _background;

        public static Texture2D Background
        {
            get => _background;
            set => _background = value;
        }
    }

    public class PauseModel
    {
        private static Texture2D _background;

        public static Texture2D Background
        {
            get => _background;
            set => _background = value;
        }
    }

    public class LossModel
    {
        private static Texture2D _background;
        private bool _isLose = false;

        public bool IsLose
        {
            get => _isLose;
            set => _isLose = value;
        }

        public static Texture2D Background
        {
            get => _background;
            set => _background = value;
        }
    }
}
