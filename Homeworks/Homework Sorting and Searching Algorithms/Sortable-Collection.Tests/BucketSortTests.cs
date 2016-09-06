using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sortable_Collection.Sorters;

namespace Sortable_Collection.Tests
{
    [TestClass]
    public class BucketSortTests
    {
        private const int NumberOfTests = 1000;

        private const int MinNumberOfElementsToSort = 1;
        private const int MaxNumberOfElementsToSort = 10000;

        private const int MaxValueCeiling = int.MaxValue;
        private const int MinValueCeiling = int.MinValue;

        private static readonly Random Random = new Random();

        [TestMethod]
        public void BucketSort_WithMultipleRandomElements()
        {
            for (int i = 0; i < NumberOfTests; i++)
            {
                int numberOfElements = 
                    Random.Next(MinNumberOfElementsToSort, MaxNumberOfElementsToSort + 1);
                int maxValue = Random.Next(MaxValueCeiling);
                int minValue = Random.Next(MinValueCeiling, 0);

                int[] elements = new int[numberOfElements];

                for (int j = 0; j < numberOfElements; j++)
                {
                    elements[j] = Random.Next(maxValue);
                }

                var collection = new SortableCollection<int>(elements);

                Array.Sort(elements);
                collection.Sort(new BucketSorter() {Max = maxValue});

                CollectionAssert.AreEqual(elements, collection.ToArray());
            }
        }
    }
}
