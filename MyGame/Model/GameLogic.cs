using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MyGame.Model
{
    public class GameLogic
    {
        public List<Bus> Buses { get; } = new List<Bus>();
        public List<Player> Players { get; } = new List<Player>();

        public GameLogic()
        {
            // Создаём автобусы (данные)
            var bus1 = new Bus(new Vector2(400, 400));
            var bus2 = new Bus(new Vector2(500, 500));

            Buses.Add(bus1);
            Buses.Add(bus2);

            // Создаём игроков и связываем с автобусами
            Players.Add(new Player("Игрок 1", bus1));
            Players.Add(new Player("Игрок 2", bus2));
        }
    }
}
