using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using Sortable_Collection.Interfaces;

namespace Sortable_Collection
{
    public class SortableCollection<T> where T : IComparable<T>
    {
         private static Random random = new Random();

        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items) : this(items.AsEnumerable())
        { 
        }

        public List<T> Items { get; private set; }

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public void Add(T element)
        {
            this.Items.Add(element);
        }

        public int BinarySearch(T item)
        {
            int start = 0;
            int end = this.Items.Count - 1;
            while (start <= end)
            {
                int mid = (start + end)/2;
                if (item.CompareTo(this.Items[mid]) == 0)
                {
                    return mid;
                }

                if (item.CompareTo(this.Items[mid]) > 0)
                {
                    start = mid + 1;
                }

                if (item.CompareTo(this.Items[mid]) < 0)
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        // no simple way to implement Interpolation search for generics (primitive numeric types 
        //will not be able to implement a custom interface and it's impossible to declare operator 
        //overloads in an interface), thus you'll need at least 2 implementations of the collection 
        //one for primitive numeric types and one for types implementing the interface

        public int InterpolationSearch(int item)
        {
            List<int> items = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                items.Add(Convert.ToInt32(this.Items[i]));
            }

            int start = 0;
            int end = this.Count - 1;
            if (start > end)
            {
                return -1;
            }

            while (items[start] <= item && items[end] >= item)
            {
                int mid = start + ((item - items[start])*(end - start))/(items[end] - items[start]);
                if (items[mid] > item)
                {
                    end = mid - 1;
                }
                else if (items[mid] < item)
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public void Shuffle()
        {
            int len = this.Items.Count;
            for (int i = 0; i < len; i++)
            {
                int r = i + random.Next(0, len - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }
    }
}