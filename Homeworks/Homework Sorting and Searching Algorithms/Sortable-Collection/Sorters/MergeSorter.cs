using System;
using System.Collections.Generic;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection.Sorters
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var tempArray = new T[collection.Count];
            this.MergeSort(collection, tempArray, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> collection, T[] tempArray, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end)/2;
                this.MergeSort(collection, tempArray, start, mid);
                this.MergeSort(collection, tempArray, mid + 1, end);

                this.Merge(collection, tempArray, start, mid, end);
            }
        }

        private void Merge(List<T> collection, T[] tempArray, int start, int mid, int end)
        {
            int leftStart = start;
            int rightStart = mid + 1;
            int tempIndex = 0;

            while (leftStart <= mid && rightStart <= end)
            {
                if (collection[leftStart].CompareTo(collection[rightStart]) <= 0)
                {
                    tempArray[tempIndex++] = collection[leftStart++];
                }
                else
                {
                    tempArray[tempIndex++] = collection[rightStart++];
                }
            }

            while (leftStart <= mid)
            {
                tempArray[tempIndex++] = collection[leftStart++];
            }

            while (rightStart <= end)
            {
                tempArray[tempIndex++] = collection[rightStart++];
            }

            leftStart = start;
            tempIndex = 0;

            while (tempIndex < tempArray.Length && leftStart <= end)
            {
                collection[leftStart++] = tempArray[tempIndex++];
            }
        }
    }
}