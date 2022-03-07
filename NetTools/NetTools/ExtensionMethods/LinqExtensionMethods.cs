using System;
using System.Collections.Generic;
using System.Linq;

namespace NetTools.ExtensionMethods
{
    /// <summary>
    /// Linq Extension Methods Class
    /// </summary>
    public static class LinqExtensionMethods
    {

        /// <summary>
        /// Updates a each collection member (it has to return the modified object to save it)
        /// </summary>
        /// <typeparam name="TSource">Collection item type</typeparam>
        /// <param name="source">Collection itself</param>
        /// <param name="predicate">Function to execute</param>
        /// <returns>Modified collection</returns>
        public static IEnumerable<TSource> Update<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource> predicate)
        {
            if (source != null)
            {
                foreach (TSource item in source)
                {
                    predicate(item);
                }
            }

            return source;
        }

        /// <summary>
        /// Updates a propety for each member
        /// </summary>
        /// <typeparam name="TSource">Collection item type</typeparam>
        /// <param name="source">Collection itself</param>
        /// <param name="predicate">Action to execute</param>
        /// <returns>Modified collection</returns>
        public static IEnumerable<TSource> Update<TSource>(this IEnumerable<TSource> source, Action<TSource> predicate)
        {
            if (source != null)
            {
                foreach (TSource item in source)
                {
                    predicate(item);
                }
            }

            return source;
        }

        /// <summary>
        /// Consolidates a collection of collections of {TSource} into a single collection of distinct {TSource}
        /// </summary>
        /// <typeparam name="TSource">Collection item type</typeparam>
        /// <param name="source">Collection itself</param>
        /// <returns>A consolidated collection of {TSource}</returns>
        public static IEnumerable<TSource> Consolidate<TSource>(this IEnumerable<IEnumerable<TSource>> source)
        {
            IEnumerable<TSource> result = null;
            //IEnumerable<TSource> result = new List<TSource>();

            foreach (var item in source)
            {

                if (result == null)
                {
                    result = item;
                }
                else
                {
                    result = result.Concat(item);
                }
            }

            result = result.Distinct();

            return result;
        }
    }
}
