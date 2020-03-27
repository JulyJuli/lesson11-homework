using System;
using System.Collections.Generic;

namespace GameFruitBasket.Classes
{
    public static class Library
    {
        public static void AddTryToList(int number, List<int> tries)
        {
            tries.Add(number);
        }

        public static int GetTryNumber(out int number, int startRandom)
        {
            Random rnd = new Random(new Random().Next(5, startRandom));
            number = rnd.Next(40, 140);
            return number;
        }

        public static bool CheckList(int number, List<int> tries)
        {
            bool InMemory = false;
            for (int i = 0; i < tries.Count; i++)
            {
                if (tries[i].Equals(number))
                {
                    InMemory = true;
                }
            }
            return InMemory;
        }

        public static bool CheckListForCheater(int number)
        {
            bool InMemory = false;

            for (int i = 0; i < AllLists.allLists.Count; i++)
            {
                for (int j = 1; j < AllLists.allLists[i].Count; j++)
                {
                    if (AllLists.allLists[i][j].Equals(number))
                    {
                        InMemory = true;
                    }
                }
            }
            return InMemory;
        }

        public static bool CheckListForGame(int number)
        {
            bool InMemory = false;
            for (int r = 1; r < 7; r++)
            {
                int approxiBasketWeight1 = r + Basket.Weight;
                int approxiBasketWeight2 = Basket.Weight - 1;
                for (int i = 0; InMemory == false && i < AllLists.allLists.Count; i++)
                {
                   // Console.WriteLine($"{i + 1}List:");
                    for (int j = 0; InMemory == false && j < AllLists.allLists[i].Count; j++)
                    {
                        //Console.WriteLine($"{j}el={AllLists.allLists[i][j]} сравниваем с {r} ");

                        if (AllLists.allLists[i][j].Equals(approxiBasketWeight1) ||
                            AllLists.allLists[i][j].Equals(approxiBasketWeight2))
                        {
                            PrintVictoryMessage(AllLists.allPlayers[i], "approximate");
                            //Console.WriteLine("!!!!ну хоть приблизительно");  
                            InMemory = true;
                            break;
                        }
                        //else Console.WriteLine("Не равно");
                    }
                }
            }

            return InMemory;
        }

        public static void Game()
        {
            Basket basket = new Basket();
            Console.WriteLine(basket);
            bool HasGuessed = false;
            int number = 0;

            for (int i = 0; i < 100; i += 0)
            {
                for (int j = 0; HasGuessed == false && j < AllLists.allPlayers.Count; j++)
                {
                    GetNewVariant(AllLists.allPlayers[j], out number);
                    i++;
                    //Console.WriteLine(i.ToString());
                    if (i < 100 && number.Equals(Basket.Weight))
                    {

                        PrintVictoryMessage(AllLists.allPlayers[j], "100%");
                        PrintListListov();
                        HasGuessed = true;
                        break;
                    }
                }
            }
            if(HasGuessed==false)
            {
                PrintListListov();
            }

            CheckListForGame(number);

            //Console.WriteLine("Anyone!((");
        }
        public static void PrintListListov()
        {
            string message = " ";
            int num = 0;
            Console.WriteLine("\n\tЛист листов");
            for (int i = 0; i < AllLists.allLists.Count; i++)
            {
                Console.Write($"\nList of {i + 1} player:");
                for (int j = 0; j < AllLists.allLists[i].Count; j++)
                {
                    num = AllLists.allLists[i][j];

                    message = num < 100 ? " "+ num.ToString() + " " : num.ToString()+ " ";
                    //message = " " + num.ToString() + " ";
                    Console.Write(message);
                    //Console.Write(" " + AllLists.allLists[i][j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ChangeConsole(int delta1, int delta2)
        {
            int origWidth = Console.WindowWidth;
            int newConsoleWidth = origWidth + delta1;
            int origHeight = Console.WindowHeight;
            int newConsoleHeight = origHeight + delta2;
            Console.SetWindowSize(newConsoleWidth, newConsoleHeight);
        }
        private static void PrintVictoryMessage(Player player, string accuracy)
        {
            Console.WriteLine(player.ToString() + accuracy + " - VICTORY!!!\n");
        }

        public static void GetNewVariant(Player player, out int number)
        {
            number = player.GetNumber();
            Console.WriteLine($"{player.Name}'s answer is {number}");
        }

        public static void GetNewVariant(Player player)
        {
            Console.WriteLine($"{player.Name}'s answer is {player.GetNumber()}");
        }
    }
}
