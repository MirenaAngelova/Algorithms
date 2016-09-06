using System;

using Sortable_Collection.Interfaces;
using Sortable_Collection.Sorters;

namespace Sortable_Collection
{
    using System.Runtime.CompilerServices;

    public class SortableCollectionPlayground
    {
        private static readonly ISorter<int> TestSorter = new InPlaceMergeSorter<int>();

        private static readonly Random Random = new Random();

        public static void Main()
        {
            const int NumberOfElementsToSort = 40;
            const int MaxValue = 150;
            const int MinValue = -150;

            var array = new int[NumberOfElementsToSort];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Next(MinValue, MaxValue);
            }

            var collection = new SortableCollection<int>(array);
            Console.WriteLine("Original:");
            Console.WriteLine(collection);

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter {Max = MaxValue, Min = MinValue});

            Console.WriteLine("Bucket sort:");
            Console.WriteLine(collectionToSort);
            
            collection.Sort(TestSorter);
            Console.WriteLine("Test Sort({0}):", TestSorter.GetType().Name);
            Console.WriteLine(collection);

            SortableCollection<int> shuffleCollection = new SortableCollection<int>(1, 2, 3, 4, 5);
            Console.WriteLine("Original:");
            Console.WriteLine(shuffleCollection);

            Console.WriteLine("Shuffle:");
            for (int i = 0; i < 10; i++)
            {
                shuffleCollection.Shuffle();
                Console.WriteLine(shuffleCollection);
            }
        }
    }
}
