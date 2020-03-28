using System;
using System.Collections.Generic;
using System.Linq;
using Game.extensions;

namespace Game.classes
{
    public class Cheater : Player
    {
        private int[] _array;
        public Cheater(string name) : base(name)
        {
            _array = new int[MAX_VALUE - MIN_VALUE];
            for (int i = MIN_VALUE; i < MAX_VALUE; i++)
            {
                _array[i - MIN_VALUE] = i;
            }
            var rng = new Random();
            rng.Shuffle(_array);
        }
        
        public override int GetNumber(List<int> attempts)
        {
            foreach (var item in attempts)
            {
                _array = _array.Where(val => val != item).ToArray();
            }
            var attempt = _array[0];
            _array = _array.Where(val => val != attempt).ToArray();
            
            return attempt;
        }
    }
}