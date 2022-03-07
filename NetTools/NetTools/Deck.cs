using NetTools.Interfaces;
using NetTools.ShufflingStrategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NetTools
{
    public class Deck<T> : ICollection<T>
    {
        protected Random _rnd;

        /// <summary>
        /// inner ArrayList object
        /// </summary>
        protected ICollection<T> _innerCollection;

        /// <summary>
        /// flag for setting collection to read-only mode (not used in this example)
        /// </summary>
        protected bool _IsReadOnly;

        protected List<T> _collection;

        protected IShufflingStrategy<T> _shuffler;


        public Deck() : this(null, null)
        {
            _collection = _innerCollection as List<T>;
            _shuffler = new BasicShufflingStrategy<T>();
        }

        public Deck(Random rnd) : this(rnd, null)
        {
            _collection = _innerCollection as List<T>;
        }


        public Deck(int seed) : this(null, null, seed)
        {
            _collection = _innerCollection as List<T>;
        }


        protected Deck(Random rnd = null, ICollection<T> collection = null, int? seed = null)
        {
            if(rnd != null)
            {
                _rnd = rnd;
            }
            else if(seed != null)
            {
                _rnd =  new Random(seed.Value);
            }
            else
            {
                _rnd = new Random();
            }
            _innerCollection = collection ?? new List<T>();
        }

        #region ICollection

        /// <summary>
        /// /¡Number of elements in the collection
        /// </summary>
        public virtual int Count
        {
            get
            {
                return _innerCollection.Count;
            }
        }

        /// <summary>
        /// Flag sets whether or not this collection is read-only
        /// </summary>
        public virtual bool IsReadOnly
        {
            get
            {
                return _IsReadOnly;
            }
        }

        // Add a business object to the collection
        public virtual void Add(T newObject)
        {
            _innerCollection.Add(newObject);
        }
        public bool Remove(T item)
        {
            return _innerCollection.Remove(item);
        }

        public bool Contains(T item)
        {
            return _innerCollection.Contains(item);
        }

        // Copy objects from this collection into another array
        public virtual void CopyTo(T[] array, int index)
        {
            _innerCollection.CopyTo(array, index);
        }

        // Clear the collection of all it's elements
        public virtual void Clear()
        {
            _innerCollection.Clear();
        }

        // Returns custom generic enumerator for this BusinessObjectCollection
        public virtual IEnumerator<T> GetEnumerator()
        {
            //return a custom enumerator object instantiated
            //to use this BusinessObjectCollection 
            return _innerCollection.GetEnumerator();
        }

        // Explicit non-generic interface implementation for IEnumerable
        // extended and required by ICollection (implemented by ICollection<T>)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }


        #endregion

        public void Shuffle()
        {
            _innerCollection = _shuffler.Shuffle(_innerCollection.ToArray());

            Cut();
        }

        public void Cut()
        {
            IEnumerable<T> top = null;
            int placeToCut = 0;

            placeToCut = _rnd.Next(0, _collection.Count);
            top = _collection.Take(placeToCut).ToList();
            _collection.RemoveRange(0, placeToCut);
            _collection.AddRange(top);
        }


        public T Seek()
        {

            return _collection.First();
        }

        public T Draw()
        {
            T result;

            result = Seek();

            if (result != null)
            {
                _collection.Remove(result);
            }

            return result;
        }


        public IEnumerable<T> Seek(int amount)
        {
            IEnumerable<T> result = null;

            if (_collection != null)
            {
                result = _collection.Take(amount);
            }

            return result;
        }

        public IEnumerable<T> Draw(int amount)
        {
            IEnumerable<T> result = null;

            result = Seek(amount);

            if (result != null)
            {
                _collection.RemoveRange(0, amount);
            }

            return result;
        }
    }
}
