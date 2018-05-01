namespace Battleship
{
    public interface IShip {
        int ShipLength { get; set; }
        Point StartPoint { get; set; }
        string Direction { get; set; }
        string Description { get; set; }

        string GenerateDirection();
    }
}
