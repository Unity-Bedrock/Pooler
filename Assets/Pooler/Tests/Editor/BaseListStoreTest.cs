using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Com.UnityBedrock.Pooler.Tests
{
    [TestFixture]
    public class BaseListStoreTest
    {
        private BaseListStore<string> _baseListStore;

        [SetUp]
        public void SetUp()
        {
            _baseListStore = new BaseListStore<string>();
        }

        [Test]
        public void Constructing_InitializesWithEmptyList()
        {
            Assert.AreEqual(0, _baseListStore.Count);
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void Add_Items_UpdatesList(int numberOfItemsToAdd)
        {
            AddItemsToStore(numberOfItemsToAdd);

            Assert.AreEqual(numberOfItemsToAdd, _baseListStore.Count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        public void Clear_EmptiesList(int numberOfItemsToAdd)
        {
            AddItemsToStore(numberOfItemsToAdd);

            _baseListStore.Clear();

            Assert.AreEqual(0, _baseListStore.Count);
        }

        [Test]
        public void Contains_ExistingItem_ReturnsTrue()
        {
            string item = "item";
            _baseListStore.Add(item);

            bool isContained = _baseListStore.Contains(item);

            Assert.IsTrue(isContained);
        }

        [Test]
        public void Contains_OnEmptyList_ReturnsFalse()
        {
            bool isContained = _baseListStore.Contains("non-existing item");

            Assert.IsFalse(isContained);
        }

        [Test]
        public void Contains_NonExistingItem_ReturnsFalse()
        {
            string item = "item";
            _baseListStore.Add(item);

            bool isContained = _baseListStore.Contains("other item");

            Assert.IsFalse(isContained);
        }

        [Test]
        public void Pop_OnEmptyList_ThrowsException()
        {
            var elementPoppedOnEmptyList = _baseListStore.Pop();
            
            Assert.IsNull(elementPoppedOnEmptyList);
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void Pop_OnNonEmptyList_ReturnsItemAndRemovesFromStore(int numberOfItemsToAdd)
        {
            AddItemsToStore(numberOfItemsToAdd);

            string poppedItem = _baseListStore.Pop();

            Assert.IsNotNull(poppedItem);
            bool isContained = _baseListStore.Contains(poppedItem);
            Assert.IsFalse(isContained);
        }

        [Test]
        public void Remove_OnExistingObject_RemovesObject()
        {
            string item = "item";
            _baseListStore.Add(item);

            _baseListStore.Remove(item);

            bool isContained = _baseListStore.Contains(item);
            Assert.IsFalse(isContained);
        }

        [Test]
        [TestCase(5)]
        public void Remove_OnNonExistingObject_DoesNothing(int numberOfItemsToAdd)
        {
            AddItemsToStore(numberOfItemsToAdd);

            _baseListStore.Remove("non-existing item");

            Assert.AreEqual(numberOfItemsToAdd, _baseListStore.Count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void CanBeIteratedInForeachLoop(int numberOfItemsToAdd)
        {
            AddItemsToStore(numberOfItemsToAdd);

            foreach (var item in _baseListStore)
            {
                Assert.IsNotNull(item);
            }
        }

        [Test]
        public void ReturnsNonNullEnumerator()
        {
            IEnumerator<string> enumerator = _baseListStore.GetEnumerator();

            Assert.NotNull(enumerator);
        }

        private void AddItemsToStore(int numberOfItemsToAdd)
        {
            for (int i = 0; i < numberOfItemsToAdd; i++)
            {
                _baseListStore.Add(i.ToString());
            }
        }
    }
}