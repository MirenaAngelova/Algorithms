using System;
using System.Collections.Generic;

namespace _06.Connected_Areas_in_Matrix_2
{
    public class DescendingComparer<T> : IComparer<T> where T: IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
}