using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Board
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        private string _difficulty;
        public Point[,] _board;
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
            DrawHorizontalNumbers(BoardWidth);
            DrawHorizontal(BoardWidth);
            for (int row = 0; row < BoardWidth; row++)
            {
                if(row + 1 > 9)
                    Console.Write("{0}| ", row+1);
                else
                    Console.Write("{0} | ", row + 1);
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
            Console.Write("  ");
            for (int i = 0; i < BoardWidth + 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine();
        }

        private void DrawHorizontalNumbers(int BoardWidth)
        {
            Console.Write("    ");
            for (int i = 1; i <= BoardWidth; i++)
            {
                if (i > 9)
                    Console.Write("{0}", i);
                else
                    Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }

        public void PlaceShips(List<IShip> ships)
        {
            foreach (var ship in ships)
                PlaceShip(ship);
        }

        private void PlaceShip(IShip ship)
        {
            var placed = false;
            Random rand = new Random();
            while (!placed)
            {
                var xCoord = rand.Next(0, BoardWidth);
                var yCoord = rand.Next(0, BoardHeight);

                if(!_board[xCoord, yCoord].IsOccupied)
                {
                    if(ship.Direction == "horizontal")
                    {
                        if((xCoord + ship.ShipLength) < BoardWidth)
                        {
                            for(int row=xCoord; row<xCoord + ship.ShipLength; row++)
                            {
                                if(!_board[row, yCoord].IsOccupied)
                                {
                                    _board[row, yCoord].IsOccupied = true;
                                    ship.StartPoint = _board[xCoord, yCoord];
                                    placed = true;
                                }
                            }
                        } else
                        {
                            xCoord = rand.Next(0, BoardWidth);
                            yCoord = rand.Next(0, BoardHeight);
                        }
                    } else
                    {
                        if((yCoord + ship.ShipLength) < BoardHeight)
                        {
                            for(int col=yCoord; col<yCoord + ship.ShipLength; col++)
                            {
                                if(!_board[xCoord, col].IsOccupied)
                                {
                                    _board[xCoord, col].IsOccupied = true;
                                    ship.StartPoint = _board[xCoord, yCoord];
                                    placed = true;
                                }
                            }
                        } else
                        {
                            xCoord = rand.Next(0, BoardWidth);
                            yCoord = rand.Next(0, BoardHeight);
                        }
                    }
                }
            }
        }

        public void UpdateDraw()
        {
            DrawHorizontalNumbers(BoardWidth);
            DrawHorizontal(BoardWidth);
            for (int row = 0; row < BoardWidth; row++)
            {
                if (row + 1 > 9)
                    Console.Write("{0}| ", row + 1);
                else
                    Console.Write("{0} | ", row + 1);
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
