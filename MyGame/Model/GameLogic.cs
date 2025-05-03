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
        private readonly GameServices _model;
        

        public GameLogic(GraphicsDevice graphicsDevice, GameServices gameServices)
        {
            _graphicsDevice = graphicsDevice;
            _model = gameServices;

            CreateBuses();

            CreateTraffic();

            CreatePlayers();
            

        }

        private void CreateBuses()
        {
            var bus1 = new Bus(new Rectangle(350, 1000, 250, 250), // Начальное местоположение
                                new Rectangle(300, 220, 810, 1150)); //Границы движения

            var bus2 = new Bus(new Rectangle(1800, 1000, 250, 250), // Начальное местоположение
                                new Rectangle(1300, 220, 810, 1150)); //Границы движения

            Buses.Add(bus1);
            Buses.Add(bus2);
        }

        private void CreateTraffic()
        {
            var car11 = new TrafficCar(new Rectangle(820, 0, 150, 150));
            var car12 = new TrafficCar(new Rectangle(600, -500, 150, 150));
            var car13 = new TrafficCar(new Rectangle(600, -1000, 150, 150));
            var car14 = new TrafficCar(new Rectangle(600, -1500, 150, 150));

            var car21 = new TrafficCar(new Rectangle(1270, 0, 150, 150));
            var car22 = new TrafficCar(new Rectangle(1400, -500, 150, 150));
            var car23 = new TrafficCar(new Rectangle(1600, -1000, 150, 150));
            var car24 = new TrafficCar(new Rectangle(1750, -1500, 150, 150));

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
        }

        private void CreatePlayers()
        {
            Players.Add(new Player("Игрок 1", Buses[0], TrafficCarsPlayer1));
            Players.Add(new Player("Игрок 2", Buses[1], TrafficCarsPlayer2));
        }

        public void UpdateTrafficCar(GameTime gameTime, float backgroundSpeed)
        {
            //Intersects();
            foreach (var car in TrafficCars)
            {
                float delta = GetTrafficCarSpeed(backgroundSpeed) * (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Обновляем позицию через Rectangle
                car.Position = new Rectangle(
                    car.Position.X,
                    car.Position.Y + (int)delta,
                    car.Position.Width,
                    car.Position.Height
                );

                if (car.Position.Y > _graphicsDevice.Viewport.Height + 100)
                    RespawnCar(car);
            }
        }

        private void RespawnCar(TrafficCar car)
        {
            Random random = new Random();

            if (TrafficCarsPlayer1.Contains(car))
            {
                car.Position = new Rectangle(
                    random.Next(280, 820),
                    0 - car.Position.Height,  // Появляемся над экраном
                    car.Position.Width,
                    car.Position.Height
                );
            }
            else
            {
                car.Position = new Rectangle(
                    random.Next(1220, 1860),
                    0 - car.Position.Height,
                    car.Position.Width,
                    car.Position.Height
                );
            }
        }

        private float GetTrafficCarSpeed(float backgroundSpeed)
        {
            Random random = new Random();
            return backgroundSpeed + random.Next(50, 150); 
        }

        //public void Intersects()
        //{
        //    if (Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[0].Position) ||
        //        Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[1].Position) ||
        //        Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[2].Position) ||
        //        Players[0].Bus.Position.Intersects(TrafficCarsPlayer1[3].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[0].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[1].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[2].Position) ||
        //        Players[1].Bus.Position.Intersects(TrafficCarsPlayer2[3].Position)) 
        //        _model.PutPause();
        //}
    }
}
