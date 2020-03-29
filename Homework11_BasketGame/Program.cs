﻿using Basket_Lib;
using System;

namespace Homework11_BasketGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Set a default constructor for an unfair game.
            Game game = new Game(20, 60, 58);

            game.SetMessageHandler(PrintMessage);
            game.AddPlayer(new UsualPlayer("Usual1"));
            game.AddPlayer(new NotePlayer("Note1"));
            game.AddPlayer(new UberPlayer("Uber1"));
            game.AddPlayer(new CheatPlayer("Cheat1"));
            game.AddPlayer(new UberCheatPlayer("UberCheat1"));

            game.Go();

            Console.Write("\nAny key to quit...");
            Console.ReadKey();
        }

        public static void PrintMessage(string str)
        {
            Console.WriteLine(str);
        }
    }
}
