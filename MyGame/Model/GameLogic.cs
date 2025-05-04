using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MyGame.Model
{
    public class GameLogic
    {
        private readonly List<Bus> _buses = new List<Bus>();
        private readonly List<Player> _players = new List<Player>();
        private readonly List<TrafficCars> _trafficCarsList = new List<TrafficCars>();
        private List<TrafficCars> TrafficCarsPlayer1 {  get; } = new List<TrafficCars>();
        private List<TrafficCars> TrafficCarsPlayer2 { get; } = new List<TrafficCars>();

        private readonly BackgroundModel _backgroundModel;
        
        public List<Bus> Buses
        {
            get => _buses;
        }

        public List<Player> Players
        {
            get => _players;
        }

        public List<TrafficCars> TrafficCarsList
        {
            get => _trafficCarsList;
        }

        public GameLogic(BackgroundModel backgroundModel)
        {
            _backgroundModel = backgroundModel;

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
            var car11 = new TrafficCars(new Rectangle(820, 0, 150, 150));
            var car12 = new TrafficCars(new Rectangle(600, -500, 150, 150));
            var car13 = new TrafficCars(new Rectangle(600, -1000, 150, 150));
            var car14 = new TrafficCars(new Rectangle(600, -1500, 150, 150));

            var car21 = new TrafficCars(new Rectangle(1270, 0, 150, 150));
            var car22 = new TrafficCars(new Rectangle(1400, -500, 150, 150));
            var car23 = new TrafficCars(new Rectangle(1600, -1000, 150, 150));
            var car24 = new TrafficCars(new Rectangle(1750, -1500, 150, 150));

            TrafficCarsList.Add(car11);
            TrafficCarsList.Add(car12);
            TrafficCarsList.Add(car13);
            TrafficCarsList.Add(car14);
            TrafficCarsList.Add(car21);
            TrafficCarsList.Add(car22);
            TrafficCarsList.Add(car23);
            TrafficCarsList.Add(car24);

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

        public void LoadContentModel(ContentManager content)
        {
            PauseModel.Background = content.Load<Texture2D>("road2");
            PauseModel.Font = content.Load<SpriteFont>("font");
            MenuModel.Font = content.Load<SpriteFont>("font");
            MenuModel.Background = content.Load<Texture2D>("road2");
            Bus.Texture = content.Load<Texture2D>("bus");
            TrafficCars.Texture = content.Load<Texture2D>("car");
            _backgroundModel.Texture = content.Load<Texture2D>("road2");
            _backgroundModel.Position1 = Vector2.Zero;
            _backgroundModel.Position2 = new Vector2(0, _backgroundModel.Texture.Height);
        }
    }
}
