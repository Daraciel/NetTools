using System;
using System.Collections;
using System.Collections.Generic;

namespace NetTools.Interfaces
{
    public abstract class IShufflingStrategy<T>
    {
        protected readonly Random _rnd;
        public IShufflingStrategy(Random rnd = null)
        {
            _rnd = rnd ?? new Random();
        }

        public abstract ICollection<T> Shuffle(ICollection<T> a);
    }
}
