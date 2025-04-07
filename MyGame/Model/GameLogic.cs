using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MyGame.Model
{
    public static class GameLogic
    {
        public static Vector2 Position = new Vector2(400, 400);
        
        public static Vector2 DriveBus(Bus bus, Vector2 vector)
        {
            Bus bus1 = new Bus();
            bus1.Position = new Vector2(400, 400);

            Position = bus1.Position;

            return bus1.Position;
        }

    }
}
