using System;

namespace GameFruitBasket.Classes
{
    public abstract class Player
    {
        public abstract int StartRandom { get; set; }//- число для того чтобы кажая попытка начиналась с нового рандомного числа      
        public string Name { get; set; }
        public abstract EnumTypesOfPlayer TypeOfPlayer { get; set; }
        internal abstract int GetNumber();

        public void PrintNumber1()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"|{Name,-10} is {TypeOfPlayer,-15}";
        }
    }
}
