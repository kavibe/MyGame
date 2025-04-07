using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MyGame.Model
{
    public class Player
    {
        public string Name { get; set; }
        public float Points { get; set; }

        public Player(string name, float points)
        {
            Name = name;
            Points = points;
        }
    }

    public class Bus
    {
        public float CurrentSpeed { get; private set; } = 60f; // Постоянная скорость (км/ч)
        public bool IsBraking { get; set; } = false;
        public float BrakeDeceleration { get; set; } = 5f; // Замедление (км/ч в секунду)
        public Vector2 Position
        { 
            get { return Position; }
            set { Position = value; }
        }



        public void UpdateSpeed(float deltaTime)
        {
            if (IsBraking)
            {
                // Плавное торможение до полной остановки
                CurrentSpeed = Math.Max(0, CurrentSpeed - BrakeDeceleration * deltaTime);
            }
            else
            {
                // Возврат к постоянной скорости
                CurrentSpeed = 60f;
            }
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
