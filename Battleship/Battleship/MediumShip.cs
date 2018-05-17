using System;

namespace Battleship
{
    public class MediumShip : IShip
    {
        public int ShipLength { get; set; }
        public Point StartPoint { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public bool IsSunk { get; set; }
        public Point[] ShipPoints { get; set; }
        public int NumPointsHit { get; set; }

        public MediumShip()
        {
            Direction = GenerateDirection();
            ShipLength = 3;
            Description = "Cruiser";
            IsSunk = false;
            NumPointsHit = 0;
        }

        public string GenerateDirection()
        {
            Random rand = new Random();
            var dir = rand.Next(0, 2);
            return dir == 0 ? "horizontal" : "vertical";
        }
    }
}
