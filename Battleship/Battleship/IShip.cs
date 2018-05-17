namespace Battleship
{
    public interface IShip {
        int ShipLength { get; set; }
        Point StartPoint { get; set; }
        string Direction { get; set; }
        string Description { get; set; }
        bool IsSunk { get; set; }
        Point[] ShipPoints { get; set; }
        int NumPointsHit { get; set; }

        string GenerateDirection();
    }
}
