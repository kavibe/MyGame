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
    public class GameLogic
    {
        public List<Bus> Buses { get; } = new List<Bus>();
        public List<Player> Players { get; } = new List<Player>();
        public List<TrafficCar> TrafficCars { get; } = new List<TrafficCar>();
        private List<TrafficCar> TrafficCarsPlayer1 {  get; } = new List<TrafficCar>();
        private List<TrafficCar> TrafficCarsPlayer2 { get; } = new List<TrafficCar>();

        private readonly GraphicsDevice _graphicsDevice;
        

        public GameLogic(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;

            // Создаём автобусы (данные)
            var bus1 = new Bus(new Vector2(0, 0), // Начальное местоположение
                                new Rectangle(280, 170, 580, 900)); //Границы движения

            var bus2 = new Bus(new Vector2(1800, 900), // Начальное местоположение
                                new Rectangle(1270, 170, 590, 900)); //Границы движения


            var car11 = new TrafficCar(new Vector2(820, 0),
                                        new Rectangle(280, 170, 580, 900));

            var car12 = new TrafficCar(new Vector2(600, -500),
                                       new Rectangle(280, 170, 580, 900));

            var car13 = new TrafficCar(new Vector2(600, -1000),
                                       new Rectangle(280, 170, 580, 900));

            var car14 = new TrafficCar(new Vector2(600, -1500),
                                       new Rectangle(280, 170, 580, 900));


            var car21 = new TrafficCar(new Vector2(1270, 0),
                                        new Rectangle(280, 170, 580, 900));

            var car22 = new TrafficCar(new Vector2(1400, -500),
                                       new Rectangle(280, 170, 580, 900));

            var car23 = new TrafficCar(new Vector2(1600, -1000),
                                       new Rectangle(280, 170, 580, 900));

            var car24 = new TrafficCar(new Vector2(1750, -1500),
                                       new Rectangle(280, 170, 580, 900));

            TrafficCars.Add(car11);
            TrafficCars.Add(car12);
            TrafficCars.Add(car13);
            TrafficCars.Add(car14);
            TrafficCars.Add(car21);
            TrafficCars.Add(car22);
            TrafficCars.Add(car23);
            TrafficCars.Add(car24);

            TrafficCarsPlayer1.Add(car11);
            TrafficCarsPlayer1.Add(car12);
            TrafficCarsPlayer1.Add(car13);
            TrafficCarsPlayer1.Add(car14);

            TrafficCarsPlayer2.Add(car21);
            TrafficCarsPlayer2.Add(car22);
            TrafficCarsPlayer2.Add(car23);
            TrafficCarsPlayer2.Add(car24);

            Buses.Add(bus1);
            Buses.Add(bus2);

            // Создаём игроков и связываем с автобусами
            Players.Add(new Player("Игрок 1", bus1, [car11, car12, car13, car14]));
            Players.Add(new Player("Игрок 2", bus2, [car21, car22, car23, car24]));
        }

        public void UpdateTrafficCar(GameTime gameTime, float backgroundSpeed)
        {
            foreach (var car in TrafficCars)
            {
                float delta = GetTrafficCarSpeed(backgroundSpeed) * (float)gameTime.ElapsedGameTime.TotalSeconds;

                car.Position = new Vector2(car.Position.X, car.Position.Y + delta);

                if (car.Position.Y > _graphicsDevice.Viewport.Height+100)
                    RespawnCar(car);
            }
        }

        private void RespawnCar(TrafficCar car)
        {
            Random random = new Random();

            if (TrafficCarsPlayer1.Contains(car))
                car.Position = new Vector2(random.Next(280, 820), 0);

            else
                car.Position = new Vector2(random.Next(1270, 1860), 0);
        }

        private float GetTrafficCarSpeed(float backgroundSpeed)
        {
            Random random = new Random();
            return backgroundSpeed + random.Next(50, 150); 
        }

        //public void Intersects()
        //{
        //    if (Players[0].Bus.Position.Intersects())
        //}
    }
}
