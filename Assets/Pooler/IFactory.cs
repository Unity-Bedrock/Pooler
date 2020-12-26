namespace Com.UnityBedrock.Pooler
{
    /// <summary>
    /// Factory for creating objects of a given type.
    /// </summary>
    /// <typeparam name="TObject">The type of objects to be created by the factory.</typeparam>
    public interface IFactory<TObject>
    {
        /// <summary>
        /// Creates a new object.
        /// </summary>
        /// <returns>The newly created object.</returns>
        TObject Create();
    }
}