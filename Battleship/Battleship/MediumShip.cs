using System;

namespace Battleship
{
    public class MediumShip : IShip
    {
        public int ShipLength { get; set; }
        public Point StartPoint { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }

        public MediumShip()
        {
            Direction = GenerateDirection();
            ShipLength = 3;
            Description = "Cruiser";
        }

        public string GenerateDirection()
        {
            Random rand = new Random();
            var dir = rand.Next(0, 2);
            return dir == 0 ? "horizontal" : "vertical";
        }
    }
}
