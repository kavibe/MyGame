using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Model
{
    public class Player
    {
        private readonly string _name;
        private float _points;
        private readonly Bus _bus;
        private readonly List<TrafficCars> _trafficCars;

        public string Name
        {
            get => _name;
        }

        public float Points
        {
            get => _points;
            set => _points = value;
        }

        public Bus Bus
        {
            get => _bus;
        }

        public List<TrafficCars> TrafficCars
        {
            get => _trafficCars;
        }

        public Player(string name, Bus bus, List<TrafficCars> trafficCars)
        {
            _name = name;
            _bus = bus;
            _trafficCars = trafficCars;
        }
    }

    public class BackgroundModel
    {
        public Texture2D _texture;
        private float _scrollSpeed = 200f;

        private Vector2 _position1;
        private Vector2 _position2;

        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public float ScrollSpeed
        {
            get => _scrollSpeed;
        }

        public Vector2 Position1
        {
            get => _position1;
            set => _position1 = value;
        }

        public Vector2 Position2
        {
            get => _position2;
            set => _position2 = value;
        }
    }

    public class Bus
    {
        public enum DriveDirection { Left, Right, Straight, Back }
        private static float _turningSpeed = 250f;
        private static float _boostSpeed = 350f;
        private Rectangle _position;
        private Rectangle _bounds;
        private static Texture2D _texture;

        public static Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public static float TurningSpeed
        {
            get => _turningSpeed;
        }

        public static float BoostSpeed
        {
            get => _boostSpeed;
        }

        public Rectangle Position
        {
            get => _position;
            set => _position = value;
        }

        public Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        public Bus(Rectangle startPosition, Rectangle personalBounds)
        {
            Position = startPosition;
            Bounds = personalBounds;
        }
    }

    public class TrafficCars
    {
        private Rectangle _position;
        private static Texture2D _texture;
        public const float CarSpeed = 300f;

        public Rectangle Position
        {
            get => _position;
            set => _position = value;
        }

        public static Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public TrafficCars(Rectangle startPosition)
        {
            Position = startPosition;
        }
    }
}
