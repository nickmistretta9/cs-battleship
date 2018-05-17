using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Game
    {
        private string _difficulty;
        private Board _board;
        private List<IShip> _ships;
        private Player _player;
        public bool GameOver;

        public Game(string difficulty)
        {
            _difficulty = difficulty;
            GameOver = false;
        }

        public void StartGame()
        {
            Console.WriteLine("{0} game started. Good luck!", _difficulty);
            _board = new Board(_difficulty);
            _ships = new List<IShip>();
            switch(_difficulty)
            {
                case "easy":
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new MediumShip());
                    _board.Draw();
                    _board.PlaceShips(_ships);
                    _player = new Player
                    {
                        NumberOfTurns = 12
                    };
                    TakeGuesses();
                    break;
                case "medium":
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new MediumShip());
                    _ships.Add(new MediumShip());
                    _board.Draw();
                    _board.PlaceShips(_ships);
                    _player = new Player
                    {
                        NumberOfTurns = 16
                    };
                    TakeGuesses();
                    break;
                case "hard":
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new MediumShip());
                    _ships.Add(new MediumShip());
                    _board.Draw();
                    _board.PlaceShips(_ships);
                    _player = new Player
                    {
                        NumberOfTurns = 20
                    };
                    TakeGuesses();
                    break;
                default:
                    break;
            }
        }

        private void TakeGuesses()
        {
            var guesses = 0;
            while(guesses < _player.NumberOfTurns)
            {
                Console.Write("Enter the point of guess {0}, separated by a comma (ex: 3,4): ", guesses + 1);
                var input = Console.ReadLine();
                var coords = input.Split(',');
                var convertedX = int.TryParse(coords[0], out var xCoord);
                var convertedY = int.TryParse(coords[1], out var yCoord);
                try
                {
                    if (convertedX && convertedY)
                    {
                        if (_board._board[yCoord - 1, xCoord - 1].IsOccupied)
                        {
                            _board._board[yCoord - 1, xCoord - 1].Contents = "X";
                            foreach(var ship in _ships)
                            {
                                if(ship.ShipPoints.Contains(_board._board[yCoord - 1, xCoord - 1]))
                                {
                                    ship.NumPointsHit++;
                                }
                            }
                        }
                        else
                        {
                            _board._board[yCoord - 1, xCoord - 1].Contents = "o";
                        }
                        guesses++;
                    } else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Not a valid input. Please try again: {0}", ex.Message);
                }
                _board.UpdateDraw();
            }
        }

        private bool CheckShip(IShip ship)
        {
            if(ship.NumPointsHit >= ship.ShipPoints.Length)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
