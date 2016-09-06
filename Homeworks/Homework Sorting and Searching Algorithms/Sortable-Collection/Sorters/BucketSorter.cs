using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection.Sorters
{
    public class BucketSorter : ISorter<int>
    {
        private long totalElements;

        public long Max { get; set; }

        public long Min { get; set; }

        public void Sort(List<int> collection)
        {
            this.totalElements = collection.Count;

            // choose sorting algorithm depending on sign of the numbers
            if (this.Min < 0)
            {
                this.ComplexBucketSort(collection);
            }
            else
            {
                this.PositiveBucketSort(collection);
            }
        }

        private void PositiveBucketSort(List<int> collection)
        {
            SortableCollection<int>[] buckets = new SortableCollection<int>[this.totalElements + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new SortableCollection<int>();
            }

            for (int i = 0; i < collection.Count; i++)
            {
                buckets[this.GetBucketNumber(collection[i])].Add(collection[i]);
            }

            int tempIndex = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort(new InsertionSorter<int>());
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    collection[tempIndex++] = buckets[i].Items[j];
                }
            }
        }

        private void ComplexBucketSort(List<int> collection)
        {
            SortableCollection<int>[] positiveBuckets = 
                new SortableCollection<int>[this.totalElements + 1];
            SortableCollection<int>[] negativeBuckets =
                new SortableCollection<int>[this.totalElements + 1];

            for (int i = 0; i < positiveBuckets.Length; i++)
            {
                positiveBuckets[i] = new SortableCollection<int>();
                negativeBuckets[i] = new SortableCollection<int>();
            }

            for (int i = 0; i < collection.Count; i++)
            {
                this.AddNumberToBucket(collection[i], positiveBuckets, negativeBuckets);
            }

            collection.Clear();
            for (int i = negativeBuckets.Length - 1; i >= 0; i--)
            {
                positiveBuckets[i].Sort(new InsertionSorter<int>());
                negativeBuckets[i].Sort(new InsertionSorter<int>());
                collection.AddRange(negativeBuckets[i].Items);   
            }

            for (int i = 0; i < positiveBuckets.Length; i++)
            {
                collection.AddRange(positiveBuckets[i].Items);
            }
        }

        private void AddNumberToBucket(
            int number, 
            SortableCollection<int>[] positiveBuckets, 
            SortableCollection<int>[] negativeBuckets)
        {
            if (number < 0)
            {
                long index = number*this.totalElements/this.Min;
                negativeBuckets[index].Add(number);
            }
            else
            {
                positiveBuckets[this.GetBucketNumber(number)].Add(number);
            }
        }

        // simple method for getting bucket number, works only with positive numbers
        private long GetBucketNumber(int number)
        {
            return number*this.totalElements/this.Max;
        }
    }
}