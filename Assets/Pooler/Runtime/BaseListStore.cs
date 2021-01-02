using System;
using System.Collections;
using System.Collections.Generic;

namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Implementation of the <see cref="IStore" /> interface which uses a list as the container.
    /// </summary>
    /// <typeparam name="TStoredObject"></typeparam>
    public class BaseListStore<TStoredObject> : IStore<TStoredObject>
        where TStoredObject : class
    {
        private readonly List<TStoredObject> _cacheList;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseListStore()
        {
            _cacheList = new List<TStoredObject>();
        }

        /// <inheritdoc />
        public int Count
        {
            get { return _cacheList.Count; }
        }

        /// <inheritdoc />
        public void Add(TStoredObject objectToCache)
        {
            _cacheList.Add(objectToCache);
        }

        /// <inheritdoc />
        public void Clear()
        {
            _cacheList.Clear();
        }

        /// <inheritdoc />
        public bool Contains(TStoredObject objectToCheck)
        {
            return _cacheList.Contains(objectToCheck);
        }

        /// <inheritdoc />
        public TStoredObject Pop()
        {
            if (_cacheList.Count == 0)
            {
                return null;
            }

            TStoredObject cachedObject = _cacheList[0];
            _cacheList.Remove(cachedObject);
            return cachedObject;
        }

        /// <inheritdoc />
        public void Remove(TStoredObject objectToRemove)
        {
            _cacheList.Remove(objectToRemove);
        }

        /// <inheritdoc />
        public IEnumerator<TStoredObject> GetEnumerator()
        {
            return _cacheList.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cacheList.GetEnumerator();
        }
    }
}