using System.Collections.Generic;
using System.Linq;

namespace NetTools.ExtensionMethods
{
    public static class DeckExtensionMethods
    {

        public static Deck<T> ToDeck<T>(this ICollection<T> source)
        {
            Deck<T> result = null;
            T[] auxArray = null;

            if(source != null)
            {
                result = new Deck<T>();
                auxArray = source.ToArray();
                for (int i = 0; i < source.Count; i++)
                {
                    result.Add(auxArray[i]);
                }
            }

            return result;
        }
    }
}
