using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship. What would you like to do? ");
            List<string> options = new List<string>();
            options.Add("1) Play game");
            options.Add("2) See last game's stats");
            options.Add("3) Quit");
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
            var input = Console.ReadLine();
            switch (input)
            {
                default:
                case "1":
                    Console.Write("Enter the difficulty you would like to play: (easy, medium, hard, very hard): ");
                    var difficulty = Console.ReadLine();
                    var game = new Game(difficulty);
                    game.StartGame();
                    break;
                case "2":
                    Console.WriteLine("Retrieving last game's stats");
                    break;
                case "3":
                    Console.WriteLine("Thanks for playing.");
                    break;
            }
        }
    }
}
