using System;
using System.Collections.Generic;

namespace Sortable_Collection.Interfaces
{
    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(List<T> collection);
    }
}