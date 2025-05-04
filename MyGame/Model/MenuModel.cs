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
        private static SpriteFont _font;
        private Vector2 _position;
        private string _title = "World of bus";

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
