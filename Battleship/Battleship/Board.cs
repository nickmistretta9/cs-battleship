using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Board
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        private string _difficulty;
        private Game _game;
        private Point[,] _board;

        public Board(string difficulty)
        {
            _difficulty = difficulty;
            switch (_difficulty)
            {
                case "easy":
                    BoardWidth = 6;
                    BoardHeight = 6;
                    break;
                case "medium":
                    BoardWidth = 10;
                    BoardHeight = 10;
                    break;
                case "hard":
                    BoardWidth = 14;
                    BoardHeight = 14;
                    break;
                case "very hard":
                    BoardWidth = 18;
                    BoardHeight = 18;
                    break;
                case "custom":
                    break;
                default:
                    BoardWidth = 6;
                    BoardHeight = 6;
                    break;
            }
            _board = new Point[BoardWidth, BoardHeight];
        }

        public void Draw()
        {
            DrawHorizontal(BoardWidth);
            for (int row = 0; row < BoardWidth; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < BoardWidth; col++)
                {
                    _board[row, col] = new Point();
                    Console.Write("{0} ", _board[row, col].Contents);
                }
                Console.Write("|\n");
            }
            DrawHorizontal(BoardWidth);
        }

        private void DrawHorizontal(int BoardWidth)
        {
            for (int i = 0; i < BoardWidth + 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine();
        }

        public void PlaceShips(List<IShip> ships)
        {
            Random rand = new Random();
            var amountPlaced = 0;
            while(amountPlaced < ships.Count)
            {
                foreach (var ship in ships)
                {
                    var xCoord = rand.Next(0, BoardWidth);
                    var yCoord = rand.Next(0, BoardHeight);
                    if (!_board[xCoord, yCoord].IsOccupied)
                    {
                        if (ship.Direction == "horizontal")
                        {
                            for (int row = xCoord; row < xCoord + ship.ShipLength; row++)
                            {
                                if (!_board[row, yCoord].IsOccupied)
                                {
                                    _board[row, yCoord].IsOccupied = true;
                                    _board[row, yCoord].Contents = "o";
                                    amountPlaced++;
                                }
                            }
                        }
                        else
                        {
                            for (int col = yCoord; col < yCoord + ship.ShipLength; col++)
                            {
                                if (!_board[xCoord, col].IsOccupied)
                                {
                                    _board[xCoord, col].IsOccupied = true;
                                    _board[xCoord, col].Contents = "o";
                                    amountPlaced++;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateDraw()
        {
            DrawHorizontal(BoardWidth);
            for (int row = 0; row < BoardWidth; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < BoardWidth; col++)
                {
                    Console.Write("{0} ", _board[row, col].Contents);
                }
                Console.Write("|\n");
            }
            DrawHorizontal(BoardWidth);
        }
    }
}
