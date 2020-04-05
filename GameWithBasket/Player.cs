
using System.Collections.Generic;


namespace GameWithBasket
{
    public abstract class Player
    {
        protected const int minValue = 40;
        protected const int maxValue = 140;

        internal abstract string TypeName { get; }
        public abstract int GetValue(List <int> trials);


        public override string ToString()
        {
            return $"{TypeName} won the game";
        }

    }
}
