using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFruitBasket.Classes
{
    public class Basket
    {
        //Цель игры угадать вес корзины с фруктами. Вес корзины находится в диапазоне от 40 до 140 кг. 
        static int _weight;
        
        private Random randNumber=new Random(new Random().Next(15));        
        public Basket()
        {
            Weight = randNumber.Next(40, 140);
        }
        public static int Weight        
        {
            get => _weight;
            set { _weight = value; }
        }

        public override string ToString()
        {
            return $"\n\tWeight of basket is {Weight}\n";
        }

    }
}
