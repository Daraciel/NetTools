using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NetTools
{
    public class Deck<T> : ICollection<T> where T : class
    {
        /// <summary>
        /// inner ArrayList object
        /// </summary>
        protected ICollection<T> _innerCollection;

        /// <summary>
        /// flag for setting collection to read-only mode (not used in this example)
        /// </summary>
        protected bool _IsReadOnly;


        public Deck()
        {
            _innerCollection = new List<T>();
        }

        protected Deck(ICollection<T> collection)
        {
            // Let derived classes specify the exact type of ICollection<T> to wrap.
            _innerCollection = collection;
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

        }

        public T Draw()
        {
            T result = null;

            if(_innerCollection != null)
            {
                result = _innerCollection.First();

                if(result != null)
                {
                    _innerCollection.Remove(result);
                }
            }

            return result;
        }
    }
}
