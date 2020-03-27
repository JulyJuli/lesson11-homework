using GameFruitBasket.Classes;
using System;

namespace GameFruitBasket
{
    class Program
    {
        static void Main(string[] args)
        {           
            //Basket basket = new Basket();            
            //Console.WriteLine(basket);

            var firstPlayer = new RegularPlayer(EnumTypesOfPlayer.RegularPlayer, "Ulua_1");            
            Library.GetNewVariant(firstPlayer);

            var secondPlayer = new NotepadPlayer(EnumTypesOfPlayer.NotepadPlayer, "Anisia_2");
            //Library.GetNewVariant(secondPlayer);

            var thirdPlayer = new UberPlayer(EnumTypesOfPlayer.UberPlayer, "Petr_3");
            //Library.GetNewVariant(thirdPlayer);

            var fourthPlayer = new UberCheaterPlayer(EnumTypesOfPlayer.UberCheaterPlayer, "Petya_3");
            //Library.GetNewVariant(fourthPlayer);

            var fifthPlayer = new CheaterPlayer(EnumTypesOfPlayer.CheaterPlayer, "Pavel");
            //Library.GetNewVariant(fifthPlayer);

            var sixPlayer = new UberCheaterPlayer(EnumTypesOfPlayer.UberCheaterPlayer, "Mama");
            //Library.GetNewVariant(sixPlayer);

            var sevenPlayer = new RegularPlayer(EnumTypesOfPlayer.RegularPlayer, "Papa"); 

            Console.WriteLine("\n\tЛист игроков");
            for (int i = 0; i < AllLists.allPlayers.Count; i++)
            {
                Console.WriteLine(" " + AllLists.allPlayers[i] + " ");
            }
            Console.WriteLine();
            Library.ChangeConsole(-25,2);
            Library.Game();
        }
    }
}  

