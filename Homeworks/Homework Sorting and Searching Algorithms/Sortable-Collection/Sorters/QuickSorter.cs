using System;
using System.Collections.Generic;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection.Sorters
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                int pivot = this.Partition(collection, start, end);
                this.QuickSort(collection, start, pivot);
                this.QuickSort(collection, pivot + 1, end);
            }
        }

        private int Partition(List<T> collection, int start, int end)
        {
            int midIndex = (start + end) /2;
            T pivot = collection[midIndex];
            int low = start - 1;
            int high = end + 1;
            while (true)
            {
                do
                {
                    low++;
                } while (collection[low].CompareTo(pivot) < 0);

                do
                {
                    high--;
                } while (collection[high].CompareTo(pivot) > 0);

                if (low < high)
                {
                    Swap(collection, low, high);
                }
                else
                {
                    return high;
                }
            }
        }

        private static void Swap(List<T> collection, int low, int high)
        {
            T temp = collection[low];
            collection[low] = collection[high];
            collection[high] = temp;
        }
    }
}