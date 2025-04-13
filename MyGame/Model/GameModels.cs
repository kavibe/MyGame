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
        public string Name { get; }
        public float Points { get; set; }

        public Bus Bus { get; }
        public Player(string name, Bus bus)
        {
            Name = name;
            Bus = bus;
        }
    }

    public class Bus
    {
        private const float TurningSpeed = 200f;
        public Vector2 Position { get; set; }
        public enum TurnDirection { Left, Right }

        public Bus(Vector2 startPosition)
        {

            Position = startPosition;
        }

        public void Turn(float deltaTime, TurnDirection direction)
        {
            Position += direction switch
            {
                TurnDirection.Left => new Vector2(-TurningSpeed * deltaTime, 0),
                TurnDirection.Right => new Vector2(TurningSpeed * deltaTime, 0),
            };
        }
    }

    public class TrafficSystem
    {
        public class TrafficLight
        {
            public enum State { Red, Yellow, Green }
            public State CurrentState { get; set; } //текущее состояние
            public float Timer { get; set; }
            public Vector2 StopLinePosition { get; set; } // Координаты стоп-линии
            public float ActivationDistance { get; set; } = 10; // Дистанция срабатывания

            public bool CheckBusRedTrafficLights()
            {
                return true;
            }
        }
    }

    public class Passenger
    {
        public bool IsInBus;

        public void ToggleBusStatus()
        {
            IsInBus = !IsInBus;
        }
    }
}
