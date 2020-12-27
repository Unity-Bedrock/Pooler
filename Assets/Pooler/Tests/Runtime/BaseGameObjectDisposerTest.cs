using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Com.UnityBedrock.Pooler.GameObjects.Tests
{
    [TestFixture]
    public class BaseGameObjectDisposerTest
    {
        private BaseGameObjectDisposer _baseGameObjectDisposer;

        private Transform _parent;

        [SetUp]
        public void SetUp()
        {
            _parent = new GameObject().transform;
            _baseGameObjectDisposer = new BaseGameObjectDisposer();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_parent.gameObject);
        }

        [UnityTest]
        public IEnumerator Dispose_DestroysGameObject()
        {
            GameObject newGameObject = new GameObject();
            newGameObject.transform.SetParent(_parent);
            Assert.AreEqual(1, _parent.childCount);

            _baseGameObjectDisposer.Dispose(newGameObject);
            yield return null;

            Assert.AreEqual(0, _parent.childCount);
        }
    }
}
