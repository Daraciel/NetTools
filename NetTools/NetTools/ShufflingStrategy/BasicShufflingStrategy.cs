using NetTools.Interfaces;
using System;
using System.Collections.Generic;

namespace NetTools.ShufflingStrategy
{
    public class BasicShufflingStrategy<T> : IShufflingStrategy<T>
    {
        public override ICollection<T> Shuffle(ICollection<T> collection)
        {
            int rnd_start_position = 0;
            int rnd_end_position = 0;
            int collectionCount = 0;
            T auxStorage;
            T[] array = collection as T[];

            //Do Shuffling
            if (array != null)
            {
                collectionCount = array.Length;
                if (collectionCount > 0)
                {
                    for (int i = 0; i <= collectionCount; i++)
                    {
                        rnd_start_position = _rnd.Next(0, collectionCount);
                        rnd_end_position = _rnd.Next(0, collectionCount);

                        auxStorage = array[rnd_start_position];
                        array[rnd_start_position] = array[rnd_end_position];
                        array[rnd_end_position] = auxStorage;
                    }
                }
            }

            return array;
        }
    }
}
