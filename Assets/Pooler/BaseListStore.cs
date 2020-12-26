using System;
using System.Collections;
using System.Collections.Generic;

namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Implementation of the <see cref="IStore" /> interface which uses a list as the container.
    /// </summary>
    /// <typeparam name="TCachedObject"></typeparam>
    public class BaseListStore<TCachedObject> : IStore<TCachedObject>
    {
        private readonly List<TCachedObject> _cacheList;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseListStore()
        {
            _cacheList = new List<TCachedObject>();
        }

        /// <inheritdoc />
        public int Count
        {
            get
            {
                return _cacheList.Count;
            }
        }

        /// <inheritdoc />
        public void Add(TCachedObject objectToCache)
        {
            _cacheList.Add(objectToCache);
        }

        /// <inheritdoc />
        public void Clear()
        {
            _cacheList.Clear();
        }

        /// <inheritdoc />
        public bool Contains(TCachedObject objectToCheck)
        {
            return _cacheList.Contains(objectToCheck);
        }

        /// <inheritdoc />
        public TCachedObject Pop()
        {
            if (_cacheList.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty cache.");
            }
            TCachedObject cachedObject = _cacheList[0];
            _cacheList.Remove(cachedObject);
            return cachedObject;
        }

        /// <inheritdoc />
        public void Remove(TCachedObject objectToRemove)
        {
            _cacheList.Remove(objectToRemove);
        }

        /// <inheritdoc />
        public IEnumerator<TCachedObject> GetEnumerator()
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