namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Disposer of objects of given type.
    /// </summary>
    /// <typeparam name="TPooledObject">The type of objects to dispose.</typeparam>
    public interface IDisposer<TPooledObject>
    {
        /// <summary>
        /// Disposes of the provided object.
        /// </summary>
        /// <param name="objectToBeDisposed">The object to be disposed.</param>
        void Dispose(TPooledObject objectToBeDisposed);
    }
}