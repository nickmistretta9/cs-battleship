namespace Battleship
{
    public class Point
    {
        public bool IsOccupied { get; set; }
        public string Contents { get; set; }

        public Point()
        {
            IsOccupied = false;
            Contents = "*";
        }
    }
}
