using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

namespace Com.UnityBedrock.Pooler.GameObjects.Tests
{
    [TestFixture]
    public class BaseGameObjectFactoryTest
    {
        private GameObject _gameObjectPrefab;
        private Transform _parent;
        private BaseGameObjectFactory _baseGameObjectFactory;

        private GameObject _newGameObject;

        [SetUp]
        public void SetUp()
        {
            _gameObjectPrefab = new GameObject();
            _parent = new GameObject().transform;
            _baseGameObjectFactory = 
                new BaseGameObjectFactory(_gameObjectPrefab, _parent);
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_gameObjectPrefab);
            Object.Destroy(_parent.gameObject);

            if (_newGameObject != null)
            {
                Object.Destroy(_newGameObject);
            }
        }

        [Test]
        public void Create_InstantiatesNewObject()
        {
            _newGameObject = _baseGameObjectFactory.Create();

            Assert.IsNotNull(_newGameObject);
        }

        [Test]
        public void Create_InstantiatesNewObjectUnderTheParent()
        {
            _newGameObject = _baseGameObjectFactory.Create();

            bool parentSet = _newGameObject.transform.IsChildOf(_parent);

            Assert.IsTrue(parentSet);
        }
    }
}
