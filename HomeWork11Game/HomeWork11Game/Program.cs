using System;
using System.Collections.Generic;
using HomeWork11GameLibrary;

namespace HomeWork11Game
{
    class Program
    {
        public static List<ProcessGuessing> allPlayersAndGuessings = new List<ProcessGuessing>();

        public static void AddPlayerAndWeight(ProcessGuessing playerAndWeight)
        {
            allPlayersAndGuessings.Add(playerAndWeight);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Let's start the game!\n");

            FruitBasket fruitBasket = new FruitBasket();
            fruitBasket.PrintInfo();
            Console.WriteLine();

            var Mike = new OrdinaryPlayer("Mike", TypeOfPlayer.ordinary);

            var Odry = new UberPlayer("Odry", TypeOfPlayer.uber);
            Odry.UberInitialized = Odry.AddValues(Odry.UberInitialized);

            var Alex = new NotepadPlayer("Alex", TypeOfPlayer.notepad);

            var Arnold = new CheaterPlayer("Arnold", TypeOfPlayer.cheater);

            var Max = new UberCheaterPlayer("Max", TypeOfPlayer.uberCheater);
            Max.AddValues(Max.UberCheaterInitialized);


            for (int i = 0; i < Player.MaxAttempts / 5; i++)
            {
                Mike.Guessing();        
                Player.AllListsNumbers = Mike.JaggedList(Player.AddGuessNumbers(Mike.OrdinaryGuessed, Mike.Guessed));
                Mike.PrintMassege();
                Player.isGuessed = Mike.CheckGuessedNumbers(Mike.Guessed);

                var mikeGuessing = new ProcessGuessing(Mike, Mike.Guessed);
                AddPlayerAndWeight(mikeGuessing);
             
                Player.Attempts++;

                if (Player.isGuessed == true)
                {
                    WinMessage(Mike.Name, Mike.Guessed);
                    break;
                }

                Odry.Guessed = Odry.Guessing();
                Player.AllListsNumbers = Odry.JaggedList(Player.AddGuessNumbers(Odry.UberGuessed, Odry.Guessed));
                Odry.PrintMassege();
                Player.isGuessed = Odry.CheckGuessedNumbers(Odry.Guessed);

                var odryGuessing = new ProcessGuessing(Odry, Odry.Guessed);
                AddPlayerAndWeight(odryGuessing);

                Player.Attempts++;

                if (Player.isGuessed == true)
                {
                    WinMessage(Odry.Name, Odry.Guessed);
                    break;
                }


                Alex.Guessed = Alex.Guessing();
                Player.AllListsNumbers = Alex.JaggedList(Player.AddGuessNumbers(Alex.NotepadGuessed, Alex.Guessed));
                Alex.PrintMassege();
                Player.isGuessed = Alex.CheckGuessedNumbers(Alex.Guessed);

                var alexGuessing = new ProcessGuessing(Alex, Alex.Guessed);
                AddPlayerAndWeight(alexGuessing);

                Player.Attempts++;

                if (Player.isGuessed == true)
                {
                    WinMessage(Alex.Name, Alex.Guessed);
                    break;
                }


                Arnold.Guessed = Arnold.Guessing();
                Player.AllListsNumbers = Arnold.JaggedList(Player.AddGuessNumbers(Arnold.CheaterGuessed, Arnold.Guessed));
                Arnold.PrintMassege();
                Player.isGuessed = Arnold.CheckGuessedNumbers(Arnold.Guessed);

                var arnoldGuessing = new ProcessGuessing(Arnold, Arnold.Guessed);
                AddPlayerAndWeight(arnoldGuessing);

                Player.Attempts++;

                if (Player.isGuessed == true)
                {
                    WinMessage(Arnold.Name, Arnold.Guessed);
                    break;
                }


                Max.Guessed = Max.Guessing();
                Player.AllListsNumbers = Max.JaggedList(Player.AddGuessNumbers(Max.UberCheaterGuessed, Max.Guessed));
                Max.PrintMassege();
                Player.isGuessed = Max.CheckGuessedNumbers(Max.Guessed);

                var maxGuessing = new ProcessGuessing(Max, Max.Guessed);
                AddPlayerAndWeight(maxGuessing);

                Player.Attempts++;

                if (Player.isGuessed == true)
                {
                    WinMessage(Max.Name, Max.Guessed);
                    break;
                }
            }       

            if(Player.isGuessed==false)
            {
                Console.WriteLine($"The winner: {SearchWinner().ToString()}");
            }

            //Console.WriteLine("List of players");
            //foreach(var item in ProcessGuessing.allPlayersAndGuessings)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            Console.ReadKey();
        }
        public static void WinMessage(string name, int guessednumber)
        {
            Console.WriteLine($"Congratulations! {name} - WIN! Correct answer is {guessednumber}");
        }


        public static ProcessGuessing SearchWinner()
        {
            ProcessGuessing searchWinner=null;

            int min = Math.Abs(FruitBasket.Weight - allPlayersAndGuessings[0].Weight);

            for (int i=0;i< allPlayersAndGuessings.Count;i++)
            {
                if (min > Math.Abs(FruitBasket.Weight - allPlayersAndGuessings[i].Weight))
                {
                    min = Math.Abs(FruitBasket.Weight - allPlayersAndGuessings[i].Weight);
                    searchWinner = allPlayersAndGuessings[i];
                }
            }

            return searchWinner;
        }
    }
}
