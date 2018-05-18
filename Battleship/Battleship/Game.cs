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
        private int ShipsDamaged;
        private int BoardShipsHealth;
        private bool GameWon;

        public Game(string difficulty)
        {
            _difficulty = difficulty;
            GameWon = false;
            ShipsDamaged = 0;
        }

        public void StartGame()
        {
            Console.WriteLine("{0} game started. Good luck!", _difficulty);
            _board = new Board(_difficulty);
            _ships = new List<IShip>();
            switch(_difficulty)
            {
                default:
                case "easy":
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new MediumShip());
                    _board.Draw();
                    _board.PlaceShips(_ships);
                    _player = new Player
                    {
                        NumberOfTurns = 20
                    };
                    BoardShipsHealth = TotalShipHealth();
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
                        NumberOfTurns = 30
                    };
                    BoardShipsHealth = TotalShipHealth();
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
                        NumberOfTurns = 40
                    };
                    BoardShipsHealth = TotalShipHealth();
                    TakeGuesses();
                    break;
                case "very hard":
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new SmallShip());
                    _ships.Add(new MediumShip());
                    _ships.Add(new MediumShip());
                    _ships.Add(new LargeShip());
                    _board.Draw();
                    _board.PlaceShips(_ships);
                    _player = new Player
                    {
                        NumberOfTurns = 60
                    };
                    BoardShipsHealth = TotalShipHealth();
                    TakeGuesses();
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
                            if (_board._board[yCoord - 1, xCoord - 1].Contents == "*")
                            {
                                _board._board[yCoord - 1, xCoord - 1].Contents = "X";
                                ShipsDamaged++;
                                Console.WriteLine("Hit at point {0},{1}!", xCoord, yCoord);
                                guesses++;
                            } else
                            {
                                Console.WriteLine("Point {0},{1} already guessed. Try a different point.", xCoord, yCoord);
                            }
                        }
                        else
                        {
                            if (_board._board[yCoord - 1, xCoord - 1].Contents == "*")
                            {
                                _board._board[yCoord - 1, xCoord - 1].Contents = "o";
                                Console.WriteLine("Miss at point {0},{1}.", xCoord, yCoord);
                                guesses++;
                            } else
                            {
                                Console.WriteLine("Point {0},{1} already guessed. Try a different point.", xCoord, yCoord);
                            }
                        }
                    } else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Not a valid input. Please try again: {0}", ex.Message);
                }
                _board.UpdateDraw();
                if (ShipsDamaged >= BoardShipsHealth)
                {
                    GameWon = true;
                    break;
                }
            }
            if(GameWon)
                Console.WriteLine("Congratulations, you won!");
            else
                Console.WriteLine("Sorry, you did not win. Better luck next time.");
        }

        private int TotalShipHealth()
        {
            int totalHealth = 0;
            foreach(var ship in _ships)
            {
                totalHealth += ship.ShipLength;
            }
            return totalHealth;
        }
    }
}
