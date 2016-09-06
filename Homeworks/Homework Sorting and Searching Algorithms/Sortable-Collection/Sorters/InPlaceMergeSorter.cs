using System;
using System.Collections.Generic;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection.Sorters
{
    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InPlaceMergeSort(collection, 0, collection.Count);
        }

        private void InPlaceMergeSort(List<T> collection, int start, int end)
        {
            if (end - start > 1)
            {
                int mid = start + (end - start)/2;
                int workingStart2 = start + end - mid;
                // choose the first half of the current collection and sorted with recursion
                this.SortWorkingArea(collection, start, mid, workingStart2);

                // this while is for merging the unsorted and sorted part 
                // (it's only called for pieces bigger than 2 elements)
                while (workingStart2 - start > 2)
                {
                    int workingStart1 = workingStart2;
                    workingStart2 = start + (workingStart1 - start + 1)/2;

                    // a this point half the collection is sorted, we sort the 3rd quarter with this
                    this.SortWorkingArea(collection, workingStart2, workingStart1, start);
                    this.Merge(
                        collection, 
                        start, 
                        start + workingStart1 - workingStart2,
                        workingStart1, 
                        end, 
                        workingStart2);
                }

                // this is reversed Insertion Sort (the quarter collection(i.e. the unsorted part)
                // gets sorted into the main one with this)
                for (int mainElement = workingStart2; mainElement > start; mainElement--)
                {
                    for (int subElement = mainElement; subElement < end && 
                        collection[subElement].CompareTo(collection[subElement - 1]) < 0; subElement++)
                    {
                        Swap(collection, subElement, subElement - 1);
                    }
                }
            }
        }

        private void SortWorkingArea(List<T> collection, int start, int end, int workingStart)
        {
            if (end - start > 1)
            {
                int mid = start + (end - start)/2;
                this.InPlaceMergeSort(collection, start, mid);
                this.InPlaceMergeSort(collection, mid, end);
                this.Merge(collection, start, mid, mid, end, workingStart);
            }
        }

        // merge 2 sorted subarrays in place by taking 3/4 ths and repouring them in the array 
        // while sorting them
        private void Merge(List<T> collection, int start1, int end1, int start2, int end2, int workingStart)
        {
            while (start1 < end1 && start2 < end2)
            {
                Swap(
                    collection,
                    workingStart++,
                    collection[start1].CompareTo(collection[start2]) <= 0 ? start1++ : start2++);
            }

            while (start1 < end1)
            {
                Swap(collection, workingStart++, start1++);
            }

            while (start2 < end2)
            {
                Swap(collection, workingStart++, start2++);
            }
        }

        private static void Swap(List<T> collection, int a, int b)
        {
            T temp = collection[a];
            collection[a] = collection[b];
            collection[b] = temp;
        }
    }
}