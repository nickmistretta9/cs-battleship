namespace Battleship
{
    public class Point
    {
        public bool IsOccupied { get; set; }
        public string Contents { get; set; }
        public bool IsHit { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public Point()
        {
            IsOccupied = false;
            IsHit = false;
            Contents = "*";
        }
    }
}
