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
                    Console.WriteLine("Enter the type of game you would like to play: ");
                    List<string> gameTypes = new List<string>();
                    gameTypes.Add("1) Free Play (Easier)");
                    gameTypes.Add("2) Move Based (Harder)");
                    foreach(var gameType in gameTypes)
                        Console.WriteLine(gameType);
                    var GameType = Console.ReadLine();
                    switch(GameType)
                    {
                        default:
                        case "1":
                            Console.Write("Enter the difficulty you would like to play: (easy, medium, hard, very hard): ");
                            var easyGameDifficulty = Console.ReadLine();
                            var game = new Game(easyGameDifficulty);
                            game.StartGame();
                            break;
                        case "2":
                            Console.Write("Enter the difficulty you would like to play: (easy, medium, hard, very hard): ");
                            var hardGameDifficulty = Console.ReadLine();
                            var hardGame = new Game(hardGameDifficulty, "limited");
                            hardGame.StartGame();
                            break;
                    }
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
