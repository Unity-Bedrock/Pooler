using UnityEngine;

namespace Com.UnityBedrock.Pooler.GameObjects
{
    /// <summary>
    /// Simple disposer for <see cref="GameObject" />s.
    /// </summary>
    public class BaseGameObjectDisposer : IDisposer<GameObject>
    {
        /// <inheritdoc />
        public void Dispose(GameObject objectToBeDisposed)
        {
            Object.Destroy(objectToBeDisposed);
        }
    }
}