using System;
using System.Collections.Generic;

namespace _04.Fast_and_Furious
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(T[] elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        public BinaryHeap(List<T> elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        public int Count => this.heap.Count;

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return min;
        }
        
        public T Peek()
        {
            return this.heap[0];
        }

        public void Insert(T node)
        {
            this.heap.Add(node);
            this.HeapifyUp(this.heap.Count -1);
        }

        public void Reorder(T element)
        {
            int index = this.heap.IndexOf(element);
            this.HeapifyUp(index);
        }

        private void HeapifyUp(int index)
        {
            int parent = (index - 1)/2;
            while (index > 0 && this.heap[index].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[index];
                this.heap[index] = this.heap[parent];
                this.heap[parent] = old;

                index = parent;
                parent = (index - 1)/2;
            }
        }

        private void HeapifyDown(int index)
        {
            int left = (index*2) + 1;
            int right = (index*2) + 2;
            int smallest = index;
            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != index)
            {
                T old = this.heap[index];
                this.heap[index] = this.heap[smallest];
                this.heap[smallest] = old;
                this.HeapifyDown(smallest);
            }
        }
    }
}