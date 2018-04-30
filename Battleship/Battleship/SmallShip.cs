using System;

namespace Battleship
{
    public class SmallShip : IShip
    {
        public int ShipLength { get; set; }
        public Point StartPoint { get; set; }
        public string Direction { get; set; }

        public SmallShip()
        {
            Direction = GenerateDirection();
            ShipLength = 2;
        }

        public string GenerateDirection()
        {
            Random rand = new Random();
            var dir = rand.Next(0, 2);
            return dir == 0 ? "horizontal" : "vertical";
        }
    }
}
