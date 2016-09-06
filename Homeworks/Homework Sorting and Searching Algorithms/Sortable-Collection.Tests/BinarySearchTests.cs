using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sortable_Collection.Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        private static readonly Random Random = new Random();

        [TestMethod]
        public void BinarySearch_WithEmptyCollection_ShouldReturnMissingElement()
        {
            var collection = new SortableCollection<int>();

            var actual = collection.BinarySearch(0);
            var expected = Array.BinarySearch(collection.ToArray(), 0);

            Assert.AreEqual(expected, actual,
                "No elements are present in an empty collection; method should return -1.");
        }

        [TestMethod]
        public void BinarySearch_WithMissingElement()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var actual = collection.BinarySearch(10);
            var expected = -1;

            Assert.AreEqual(expected, actual, "Missing element should return -1.");
        }

        [TestMethod]
        public void BinarySearch_WithItemAtMidpoint()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var actual = collection.BinarySearch(5);
            var expected = Array.BinarySearch(collection.ToArray(), 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_WithItemToTheRightOfMidpoint()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var actual = collection.BinarySearch(12);
            var expected = Array.BinarySearch(collection.ToArray(), 12);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_WithItemToTheLeftOfMidpoint()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var actual = collection.BinarySearch(1);
            var expected = Array.BinarySearch(collection.ToArray(), 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_WithMultipleMissingKeysSmallerThanMinimum()
        {
            const int NumberOfElements = 1000;
            const int NumberOfChecks = 10000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue/2, int.MaxValue/2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(int.MinValue, collection.Items[0]);

                int actual = collection.BinarySearch(item);

                Assert.AreEqual(-1, actual);
            }
        }

        [TestMethod]
        public void BinarySearch_WithMultipleMissingKeysLargerThanMaximum()
        {
            const int NumberOfElements = 1000;
            const int NumberOfChecks = 10000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(collection.Items[collection.Count - 1], int.MaxValue);

                int actual = collection.BinarySearch(item);

                Assert.AreEqual(-1, actual);
            }
        }

        [TestMethod]
        public void BinarySearch_WithMultipleKeys()
        {
            const int NumberOfElements = 10000;

            var elements = new int[NumberOfElements];
            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(-100, 100);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);

            foreach (var element in elements)
            {
                int actual = Array.BinarySearch(elements, element);
                int expected = collection.BinarySearch(element);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void BinarySearch_WithRepeatingItem_ShouldReturnFirstDiscoveredIndex()
        {
            var collection = new SortableCollection<int>(1, 2, 2, 2, 3);

            var actual = collection.BinarySearch(2);

            Assert.AreEqual(2, actual);
        }
    }
}
