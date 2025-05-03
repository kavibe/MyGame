using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.View;

namespace MyGame.Model
{
    public class Player
    {
        private readonly string _name;
        private float _points;
        private readonly Bus _bus;
        private readonly List<TrafficCar> _trafficCars;

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

        public List<TrafficCar> TrafficCar
        {
            get => _trafficCars;
        }

        public Player(string name, Bus bus, List<TrafficCar> trafficCars)
        {
            _name = name;
            _bus = bus;
            _trafficCars = trafficCars;
        }
    }

    public class BackgroundModel
    {
        public Texture2D Texture { get; set; }
        public float ScrollSpeed { get; set; } = 200f;

        private Vector2 _position1;
        private Vector2 _position2;

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
        private const float TurningSpeed = 250f;
        private const float BoostSpeed = 320f;
        private Vector2 _position;
        private Rectangle _bounds;
        private Rectangle _positionRectangle;

        public Rectangle PositionRectangle
        {
            get => _positionRectangle;
            set => _positionRectangle = value;
        }

        public Vector2 Position
        {
            get => _position; 
            set => _position = value;
        }

        public Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        public Bus(Vector2 startPosition, Rectangle personalBounds)
        {
            Position = startPosition;
            Bounds = personalBounds;
        }


        public void Drive(float deltaTime, DriveDirection direction)
        {
            Vector2 turnLeftVector = new Vector2(-TurningSpeed * deltaTime, 0);
            Vector2 turnRightVector = new Vector2(TurningSpeed * deltaTime, 0);
            Vector2 goStraightVector = new Vector2(0, -(BoostSpeed-60f) * deltaTime);
            Vector2 goBackVector = new Vector2(0, BoostSpeed * deltaTime);

            if (Position.X > Bounds.X && Position.X < Bounds.X + Bounds.Width)
            {
                Position += direction switch
                {
                    DriveDirection.Left => turnLeftVector,
                    DriveDirection.Right => turnRightVector,
                    DriveDirection.Straight => goStraightVector,
                    DriveDirection.Back => goBackVector,
                };
            }

            if (Position.X <= Bounds.X)
                Position += turnRightVector;

            if (Position.X >= Bounds.X + Bounds.Width)
                Position += turnLeftVector;

           if (Position.Y >= Bounds.Y)
                Position += goStraightVector;

            if (Position.Y <= Bounds.Y + Bounds.Height)
                Position += goBackVector;


        }
    }

    public class TrafficCar
    {
        private Vector2 _position;
        private Rectangle _bounds;
        private Texture2D _texture;
        private Rectangle _positionRectangle;
        public const float CarSpeed = 300f;

        public Rectangle PositionRectangle
        {
            get => _positionRectangle;
            set => _positionRectangle = value;
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public TrafficCar(Vector2 startPosition, Rectangle personalBounds)
        {
            Position = startPosition;
            Bounds = personalBounds;
        }
    }


    public class TrafficSystem
    {
        public class TrafficLight
        {
            private enum State { Red, Yellow, Green }
            private State CurrentState { get; set; } //текущее состояние
            private float Timer { get; set; }
            private Vector2 StopLinePosition { get; set; } // Координаты стоп-линии
            private float ActivationDistance { get; set; } = 10; // Дистанция срабатывания

            public bool CheckBusRedTrafficLights()
            {
                return true;
            }
        }
    }
}
