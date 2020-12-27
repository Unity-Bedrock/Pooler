using UnityEngine;

namespace Com.UnityBedrock.Pooler.GameObjects
{
    /// <summary>
    /// Simple factory for creating <see cref="GameObject" />s.
    /// </summary>
    public class BaseGameObjectFactory : IFactory<GameObject>
    {
        private readonly GameObject _gameObjectPrefab;
        private readonly Transform _parent;

        public BaseGameObjectFactory(GameObject gameObjectPrefab, Transform parent)
        {
            _gameObjectPrefab = gameObjectPrefab;
            _parent = parent;
        }

        /// <inheritdoc />
        public GameObject Create()
        {
            return Object.Instantiate(_gameObjectPrefab, Vector3.zero, Quaternion.identity, _parent);
        }
    }
}