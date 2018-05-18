using System;

namespace Battleship
{
    internal class LargeShip : IShip
    {
        public int ShipLength { get; set; }
        public Point StartPoint { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }

        public LargeShip()
        {
            Direction = GenerateDirection();
            ShipLength = 4;
            Description = "Destroyer";
        }

        public string GenerateDirection()
        {
            Random rand = new Random();
            var dir = rand.Next(0, 2);
            return dir == 0 ? "horizontal" : "vertical";
        }
    }
}