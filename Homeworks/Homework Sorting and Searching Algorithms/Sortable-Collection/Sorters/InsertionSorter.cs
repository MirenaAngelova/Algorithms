using System;
using System.Collections.Generic;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection.Sorters
{
    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (collection[j - 1].CompareTo(collection[j]) > 0)
                    {
                        T temp = collection[j];
                        collection.RemoveAt(j);
                        collection.Insert(j - 1, temp);
                    }
                }
            }
        }
    }
}