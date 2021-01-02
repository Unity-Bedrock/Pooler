using System.Collections.Generic;

namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Store for objects of given type.
    /// </summary>
    /// <typeparam name="TStoredObject">The type of objects the store can keep.</typeparam>
    public interface IStore<TStoredObject> : IEnumerable<TStoredObject>
    {
        /// <summary>
        /// The number of objects the store currently keeps.
        /// </summary>
        /// <value>Number of stored objects.</value>
        int Count { get; }

        /// <summary>
        /// Checks if the object is contained in the store.
        /// </summary>
        /// <param name="objectToCheck">The object to use for the check.</param>
        /// <returns>True if the object is contained in the store, false otherwise.</returns>
        bool Contains(TStoredObject objectToCheck);

        /// <summary>
        /// Adds the provided object to the store.
        /// </summary>
        /// <param name="objectToStore">The object to be added to the store.</param>
        void Add(TStoredObject objectToStore);

        /// <summary>
        /// Removes the provided object from the store.
        /// </summary>
        /// <param name="objectToRemove">The object to be removed from the store.</param>
        void Remove(TStoredObject objectToRemove);

        /// <summary>
        /// Removes an object from the store.
        /// </summary>
        /// <returns>The removed object or null if no object could be removed.</returns>
        TStoredObject Pop();

        /// <summary>
        /// Clears all objects from the store.
        /// </summary>
        void Clear();
    }
}