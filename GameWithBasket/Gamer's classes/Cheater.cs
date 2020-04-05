using System;
using System.Collections.Generic;

namespace GameWithBasket
{
    public class Cheater : Player
    {
        internal override string TypeName { get => "Cheater"; }
        public override int GetValue(List<int> trials)
        {
            int value = new Random().Next(minValue, maxValue);
            var counter = 1;
            while (trials.Contains(value))
            {
                if (counter < 15)
                {
                    counter++;
                    value = new Random().Next(minValue, maxValue);
                }
            }
            return value;
        }
    }
}

