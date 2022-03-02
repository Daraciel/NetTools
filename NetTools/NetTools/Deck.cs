using System;
using System.Collections;
using System.Collections.Generic;

namespace NetTools
{
    public class Deck<T> : ICollection<T> where T : class
    {
        /// <summary>
        /// inner ArrayList object
        /// </summary>
        protected ArrayList _innerArray;

        /// <summary>
        /// flag for setting collection to read-only mode (not used in this example)
        /// </summary>
        protected bool _IsReadOnly;


        public Deck()
        {
            _innerArray = new ArrayList();
        }

        /// <summary>
        /// Default accessor for the collection 
        /// </summary>
        /// <param name="index">searched item index</param>
        /// <returns>an object at selected position</returns>
        public virtual T this[int index]
        {
            get
            {
                return (T)_innerArray[index];
            }
            set
            {
                _innerArray[index] = value;
            }
        }

        /// <summary>
        /// /¡Number of elements in the collection
        /// </summary>
        public virtual int Count
        {
            get
            {
                return _innerArray.Count;
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
            _innerArray.Add(newObject);
        }
        // Remove first instance of a business object from the collection 
        public virtual bool Remove(T BusinessObject)
        {
            bool result = false;

            //loop through the inner array's indices
            for (int i = 0; i < _innerArray.Count; i++)
            {
                //store current index being checked
                T obj = (T)_innerArray[i];

                //compare the BusinessObjectBase UniqueId property
                if (obj.UniqueId == BusinessObject.UniqueId)
                {
                    //remove item from inner ArrayList at index i
                    _innerArray.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }

        // Returns true/false based on whether or not it finds
        // the requested object in the collection.
        public bool Contains(T BusinessObject)
        {
            //loop through the inner ArrayList
            foreach (T obj in _innerArray)
            {
                //compare the BusinessObjectBase UniqueId property
                if (obj.UniqueId == BusinessObject.UniqueId)
                {
                    //if it matches return true
                    return true;
                }
            }
            //no match
            return false;
        }

        // Copy objects from this collection into another array
        public virtual void CopyTo(T[] BusinessObjectArray, int index)
        {
            throw new Exception(
              "This Method is not valid for this implementation.");
        }

        // Clear the collection of all it's elements
        public virtual void Clear()
        {
            _innerArray.Clear();
        }

        // Returns custom generic enumerator for this BusinessObjectCollection
        public virtual IEnumerator<T> GetEnumerator()
        {
            //return a custom enumerator object instantiated
            //to use this BusinessObjectCollection 
            return new BusinessObjectEnumerator<T>(this);
        }

        // Explicit non-generic interface implementation for IEnumerable
        // extended and required by ICollection (implemented by ICollection<T>)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BusinessObjectEnumerator<T>(this);
        }
    }
}
