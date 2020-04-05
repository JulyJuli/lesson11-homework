
using System.Collections.Generic;


namespace GameWithBasket
{
    public class UberCheater :Player
    {
        private int value = minValue;

        internal override string TypeName { get => "UberCheater"; }
        public override int GetValue(List<int> trials)
        {
            var counter = 1;
            while (trials.Contains(value))
            {
                if (counter < 6)
                {
                    counter++;
                    value++;
                }
            }
            return value;
        }
       
    }
}
