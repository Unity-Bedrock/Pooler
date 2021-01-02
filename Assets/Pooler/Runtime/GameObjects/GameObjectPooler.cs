using UnityEngine;

namespace Com.UnityBedrock.Pooler.GameObjects
{
    /// <summary>
    /// MonoBehaviour used for pooling game objects.
    /// </summary>
    public class GameObjectPooler : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The prefab to instantiate when creating a new game object.")]
        private GameObject _gameObjectPrefab;

        [SerializeField]
        [Tooltip("The parent of the instantiated objects. "
            + "If null this game object will be used as the parent.")]
        private Transform _parent;

        [SerializeField]
        [Tooltip("If greater than 0, will ensure the pool is initialized with that many objects.")]
        private int _initialCapacity;

        [SerializeField]
        [Tooltip("If greater than 0, will enforce a maximum capacity on the pooler.")]
        private int _maximumCapacity;

        private Transform Parent
        {
            get
            {
                if (_parent != null)
                {
                    return _parent;
                }
                else
                {
                    return transform;
                }
            }
        }

        /// <summary>
        /// Access to the initialized <see cref="Pooler" /> object.
        /// </summary>
        /// <value>An instance of the <see cref="Pooler" /> class which works with <see cref="GameObject" />s.</value>
        public IPooler<GameObject> Pooler { get; private set; }

        private void Awake()
        {
            IFactory<GameObject> objectFactory = new BaseGameObjectFactory(_gameObjectPrefab, Parent);
            IStore<GameObject> unusedObjectStore = new BaseListStore<GameObject>();
            IStore<GameObject> usedObjectStore = new BaseListStore<GameObject>();
            IDisposer<GameObject> objectDisposer = new BaseGameObjectDisposer();
            int maximumCapacity = _maximumCapacity > 0 ? _maximumCapacity : int.MaxValue;
            Pooler = new BasePooler<GameObject>(
                objectFactory,
                unusedObjectStore,
                usedObjectStore,
                objectDisposer,
                maximumCapacity);
            if (_initialCapacity > 0)
            {
                Pooler.EnsureCapacity(_initialCapacity);
            }
        }
    }
}