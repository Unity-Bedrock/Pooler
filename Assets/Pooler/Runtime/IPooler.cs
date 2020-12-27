namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Pool for objects of given type.
    /// </summary>
    /// <typeparam name="TPooledObject">The type of objects to be pooled.</typeparam>
    public interface IPooler<TPooledObject>
    {
        /// <summary>
        /// Fetches an object from the pool of available objects. 
        /// If the pool does not have a free object, a new one will be created.
        /// </summary>
        /// <returns>An available object from the pool.</returns>
        TPooledObject GetObject();

        /// <summary>
        /// Adds the provided object to the pool of unused objects.
        /// </summary>
        /// <param name="objectToRelease">The object to be added to the pool of available objects.</param>
        void ReturnObject(TPooledObject objectToRelease);

        /// <summary>
        /// Ensures that there is a certain number of objects available.
        /// </summary>
        /// <param name="requestedCapacity">The number of objects to be made available.</param>
        void EnsureCapacity(int requestedCapacity);

        /// <summary>
        /// Disposes all available objects.
        /// </summary>
        void ClearAvailableObjects();
    }
}