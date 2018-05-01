namespace Battleship
{
    public class Player
    {
        public int NumberOfTurns { get; set; }
        public bool WonGame { get; set; }

        public Player()
        {
            WonGame = false;
        }
    }
}