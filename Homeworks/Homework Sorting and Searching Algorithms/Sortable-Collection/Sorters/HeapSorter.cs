using System;
using System.Collections.Generic;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection.Sorters
{
    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap<T>(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = heap.ExtractMin();
            }
        }
    }
}