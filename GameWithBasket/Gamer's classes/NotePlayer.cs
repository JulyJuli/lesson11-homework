using System;
using System.Collections.Generic;

namespace GameWithBasket
{
    public class NotePlayer :Player
    {
        private readonly List<int> notes ;
        public NotePlayer ()
        {
            notes = new List<int>();
        }
        internal override string TypeName { get => "NotePlayer"; }
        public override int GetValue(List<int> trials)
        {
            int randValue = new Random().Next(minValue, maxValue);
            var counter = 1;

            while (notes.Contains(randValue))
            {
                if (counter<6)
                {
                    randValue = new Random().Next(minValue, maxValue);
                    counter++;
                }
               
            }
            
            notes.Add(randValue);
            return randValue;
        }
    }
}
