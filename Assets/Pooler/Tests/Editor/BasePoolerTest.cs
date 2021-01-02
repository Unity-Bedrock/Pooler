// using NSubstitute;
// using NUnit.Framework;
// using System.Collections.Generic;
//
// namespace Com.UnityBedrock.Pooler.Tests
// {
//     [TestFixture]
//     public class BasePoolerTest
//     {
//         private IFactory<string> _objectFactory;
//         private IStore<string> _unusedObjectStore;
//         private IStore<string> _usedObjectStore;
//         private IDisposer<string> _objectDisposer;
//
//         private BasePooler<string> _basePooler;
//
//         [SetUp]
//         public void SetUp()
//         {
//             _objectFactory = Substitute.For<IFactory<string>>();
//             _unusedObjectStore = Substitute.For<IStore<string>>();
//             _usedObjectStore = Substitute.For<IStore<string>>();
//             _objectDisposer = Substitute.For<IDisposer<string>>();
//
//             _basePooler = GetBasePooler(
//                 _objectFactory,
//                 _unusedObjectStore,
//                 _usedObjectStore,
//                 _objectDisposer);
//         }
//
//         [Test]
//         public void ClearAvailableObjects_WithNoObjectDisposer_ClearsList()
//         {
//             BasePooler<string> basePooler =
//                 GetBasePooler(_objectFactory, _unusedObjectStore, _usedObjectStore);
//
//             basePooler.ClearAvailableObjects();
//
//             _unusedObjectStore.Received().Clear();
//             _unusedObjectStore.DidNotReceive().GetEnumerator();
//         }
//
//         [Test]
//         public void ClearAvailableObjects_WithObjectDisposer_ClearsListAndDisposesObjects()
//         {
//             string item1 = "item1";
//             string item2 = "item2";
//             List<string> itemsInStore = new List<string> { item1, item2 };
//             _unusedObjectStore.GetEnumerator().Returns(itemsInStore.GetEnumerator());
//
//             _basePooler.ClearAvailableObjects();
//
//             _unusedObjectStore.Received().GetEnumerator();
//             _objectDisposer.Received().Dispose(item1);
//             _objectDisposer.Received().Dispose(item2);
//             _unusedObjectStore.Received().Clear();
//         }
//
//         [Test]
//         [TestCase(3)] // Equal to requested capacity
//         [TestCase(5)] // Greater than requested capacity
//         public void EnsureCapacity_WithEnoughCapacity_DoesNothing(int unusedObjectCount)
//         {
//             int requestedCapacity = 3;
//             _unusedObjectStore.Count.Returns(unusedObjectCount);
//
//             _basePooler.EnsureCapacity(requestedCapacity);
//
//             _objectFactory.DidNotReceive().Create();
//             _unusedObjectStore.DidNotReceive().Add(Arg.Any<string>());
//         }
//
//         [Test]
//         public void EnsureCapacity_WithNotEnoughCapacity_InstantiatesNewItems()
//         {
//             int requestedCapacity = 2;
//             int currentCapacity = 0;
//             _unusedObjectStore.Count.Returns(
//                 currentCapacity,
//                 currentCapacity + 1,
//                 currentCapacity + 2);
//             string item1 = "item1";
//             string item2 = "item2";
//             _objectFactory.Create().Returns(item1, item2);
//
//             _basePooler.EnsureCapacity(requestedCapacity);
//
//             int newItemCount = requestedCapacity - currentCapacity;
//             _objectFactory.Received(newItemCount).Create();
//             _unusedObjectStore.Received().Add(item1);
//             _unusedObjectStore.Received().Add(item2);
//         }
//
//         [Test]
//         public void GetObject_EnsuresCapapacity()
//         {
//             _basePooler = Substitute.ForPartsOf<BasePooler<string>>(
//                 _objectFactory,
//                 _unusedObjectStore,
//                 _usedObjectStore,
//                 _objectDisposer);
//             _basePooler
//                 .When(bp => bp.EnsureCapacity(1))
//                 .DoNotCallBase();
//
//             _basePooler.GetObject();
//
//             _basePooler.Received().EnsureCapacity(1);
//         }
//
//         [Test]
//         public void GetObject_PopsAndAddsObjectToUsedStorage()
//         {
//             _unusedObjectStore.Count.Returns(1);
//             string item = "item";
//             _unusedObjectStore.Pop().Returns(item);
//
//             _basePooler.GetObject();
//
//             _unusedObjectStore.Received().Pop();
//             _usedObjectStore.Received().Add(item);
//         }
//
//         [Test]
//         public void GetObject_PopsAndReturnsObject()
//         {
//             _unusedObjectStore.Count.Returns(1);
//             string item = "item";
//             _unusedObjectStore.Pop().Returns(item);
//
//             string objectFromPool = _basePooler.GetObject();
//
//             _unusedObjectStore.Received().Pop();
//             Assert.AreEqual(item, objectFromPool);
//         }
//
//         [Test]
//         public void ReturnObject_WhichIsNotUsed_IsAddedToUnusedOnly()
//         {
//             string item = "item";
//             _usedObjectStore.Contains(item).Returns(false);
//
//             _basePooler.ReturnObject(item);
//
//             _usedObjectStore.Received().Contains(item);
//             _usedObjectStore.DidNotReceive().Remove(item);
//             _unusedObjectStore.Received().Add(item);
//         }
//
//         [Test]
//         public void ReturnObject_WhichIsUsed_IsRemovedFromUsed()
//         {
//             string item = "item";
//             _usedObjectStore.Contains(item).Returns(true);
//
//             _basePooler.ReturnObject(item);
//
//             _usedObjectStore.Received().Contains(item);
//             _usedObjectStore.Received().Remove(item);
//             _unusedObjectStore.Received().Add(item);
//         }
//
//         private BasePooler<T> GetBasePooler<T>(
//             IFactory<T> objectFactory,
//             IStore<T> unusedObjectStore,
//             IStore<T> usedObjectStore,
//             IDisposer<T> objectDisposer = null)
//         {
//             return new BasePooler<T>(
//                 objectFactory,
//                 unusedObjectStore,
//                 usedObjectStore,
//                 objectDisposer);
//         }
//     }
// }
