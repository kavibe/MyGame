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
        private const float BoostSpeed = 350f;
        private Rectangle _position;
        private Rectangle _bounds;

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

        public void Drive(float deltaTime, DriveDirection direction)
        {
            // Рассчитываем смещения
            float moveLeft = -TurningSpeed * deltaTime;
            float moveRight = TurningSpeed * deltaTime;
            float moveUp = -(BoostSpeed - 60f) * deltaTime; // "Straight" (вперёд)
            float moveDown = (BoostSpeed+50f) * deltaTime; // "Back" (назад)

            // Создаём временный прямоугольник для проверки границ
            Rectangle newPosition = Position;

            // Применяем движение в зависимости от направления
            switch (direction)
            {
                case DriveDirection.Left:
                    newPosition.X += (int)moveLeft;
                    break;
                case DriveDirection.Right:
                    newPosition.X += (int)moveRight;
                    break;
                case DriveDirection.Straight:
                    newPosition.Y += (int)moveUp;
                    break;
                case DriveDirection.Back:
                    newPosition.Y += (int)moveDown;
                    break;
            }

            // Проверяем границы и корректируем позицию
            if (newPosition.X < Bounds.X)
                newPosition.X = Bounds.X;
            else if (newPosition.X + newPosition.Width > Bounds.X + Bounds.Width)
                newPosition.X = Bounds.X + Bounds.Width - newPosition.Width;

            if (newPosition.Y < Bounds.Y)
                newPosition.Y = Bounds.Y;
            else if (newPosition.Y + newPosition.Height > Bounds.Y + Bounds.Height)
                newPosition.Y = Bounds.Y + Bounds.Height - newPosition.Height;

            // Обновляем позицию
            Position = newPosition;
        }
    }

    public class TrafficCar
    {
        private Rectangle _position;
        private Texture2D _texture;
        public const float CarSpeed = 300f;

        public Rectangle Position
        {
            get => _position;
            set => _position = value;
        }

        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public TrafficCar(Rectangle startPosition)
        {
            Position = startPosition;
        }
    }
}
