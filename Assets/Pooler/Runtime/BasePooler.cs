using System;

namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Default implementation of the <see cref="IPooler" /> interface.
    /// </summary>
    /// <typeparam name="TPooledObject"></typeparam>
    public class BasePooler<TPooledObject> : IPooler<TPooledObject>
    {
        protected IFactory<TPooledObject> ObjectFactory { get; private set; }
        protected IStore<TPooledObject> UnusedObjectStore { get; private set; }
        protected IStore<TPooledObject> UsedObjectStore { get; private set; }
        protected IDisposer<TPooledObject> ObjectDisposer { get; private set; }
        protected int MaximumObjects { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="objectFactory">Factory for creating new objects.</param>
        /// <param name="unusedObjectStore">Cache for the unused objects.</param>
        /// <param name="usedObjectStore">Cache for the used objects.</param>
        /// <param name="objectDisposer">Optional disposer for objects which are no longer needed.</param>
        /// <param name="maximumObjects">The maximum number of objects that can be created in the pool.</param>
        public BasePooler(
            IFactory<TPooledObject> objectFactory,
            IStore<TPooledObject> unusedObjectStore,
            IStore<TPooledObject> usedObjectStore,
            IDisposer<TPooledObject> objectDisposer = null,
            int maximumObjects = int.MaxValue)
        {
            ObjectFactory = objectFactory;
            UnusedObjectStore = unusedObjectStore;
            UsedObjectStore = usedObjectStore;
            ObjectDisposer = objectDisposer;
            MaximumObjects = maximumObjects;
        }

        /// <inheritdoc />
        public virtual void ClearAvailableObjects()
        {
            if (ObjectDisposer != null)
            {
                foreach (var unusedObject in UnusedObjectStore)
                {
                    ObjectDisposer.Dispose(unusedObject);
                }
            }

            UnusedObjectStore.Clear();
        }

        /// <inheritdoc />
        public virtual void EnsureCapacity(int requestedCapacity)
        {
            while (UnusedObjectStore.Count < requestedCapacity)
            {
                if (UnusedObjectStore.Count + UsedObjectStore.Count == MaximumObjects)
                {
                    return;
                }

                TPooledObject newPooledObject = ObjectFactory.Create();
                UnusedObjectStore.Add(newPooledObject);
            }
        }

        /// <inheritdoc />
        public virtual TPooledObject GetObject()
        {
            EnsureCapacity(1);
            TPooledObject newPooledObject = UnusedObjectStore.Pop();
            if (newPooledObject != null)
            {
                UsedObjectStore.Add(newPooledObject);
            }

            return newPooledObject;
        }

        /// <inheritdoc />
        public virtual void ReturnObject(TPooledObject objectToRelease)
        {
            if (UsedObjectStore.Contains(objectToRelease))
            {
                UsedObjectStore.Remove(objectToRelease);
            }

            UnusedObjectStore.Add(objectToRelease);
        }
    }
}