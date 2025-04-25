using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyGame.View;

namespace MyGame.Model
{
    public class Player
    {
        private readonly string _name;
        private float _points;
        private readonly Bus _bus;

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

        public Player(string name, Bus bus)
        {
            _name = name;
            _bus = bus;
        }
    }

    public class Bus
    {
        public enum TurnDirection { Left, Right }
        private const float TurningSpeed = 200f;
        private Vector2 _position;
        private Rectangle _bounds;

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

        public void Turn(float deltaTime, TurnDirection direction)
        {
            Vector2 turnLeftVector = new Vector2(-TurningSpeed * deltaTime, 0);
            Vector2 turnRightVector = new Vector2(TurningSpeed * deltaTime, 0);

            if (Position.X > Bounds.X && Position.X < Bounds.X + Bounds.Width)
            {
                Position += direction switch
                {
                    TurnDirection.Left => turnLeftVector,
                    TurnDirection.Right => turnRightVector,
                };
            }

            if (Position.X <= Bounds.X)
            {
                Position += turnRightVector;
            }

            if (Position.X >= Bounds.X + Bounds.Width)
            {
                Position += turnLeftVector;
            }


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

    public class Passenger
    {
        private bool IsInBus;

        public void ToggleBusStatus()
        {
            IsInBus = !IsInBus;
        }
    }
}
