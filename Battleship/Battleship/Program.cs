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
            List<IShip> ships = new List<IShip>() { new SmallShip(), new SmallShip(), new SmallShip(), new SmallShip(), new SmallShip() };
            board.PlaceShips(ships);
            //foreach(var ship in ships)
            //    Console.WriteLine(ship.Direction);
            Console.WriteLine("------------------");
            board.UpdateDraw();
        }
    }
}
