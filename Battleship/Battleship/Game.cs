using System.Collections.Generic;

namespace Battleship
{
    public class Game
    {
        private string _difficulty;
        private Board _board;
        private List<IShip> _ships;

        public Game(string difficulty)
        {
            _difficulty = difficulty;
        }

        public void StartGame()
        {
            _board = new Board(_difficulty);
            _ships = new List<IShip>();
            switch(_difficulty)
            {
                case "easy":
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new MediumShip());
                    _board.PlaceShips(_ships);
                    break;
                default:
                    break;
            }
        }
    }
}
