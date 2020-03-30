using System;

namespace HomeWork11GameLibrary
{
    public class FruitBasket 
    {
        int MinWeight = 40;
        int MaxWeight = 140;
        public FruitBasket()
        {
            Weight = new Random().Next(MinWeight, MaxWeight);
        }

        public static int Weight { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"The weight of the basket is: {Weight}";
        }
    }
}