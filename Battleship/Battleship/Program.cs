using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board("easy");
            board.Draw();
            List<IShip> ships = new List<IShip>() { new SmallShip(), new SmallShip(), new MediumShip() };
            board.PlaceShips(ships);
            Console.WriteLine("------------------");
            board.UpdateDraw();
        }
    }
}
