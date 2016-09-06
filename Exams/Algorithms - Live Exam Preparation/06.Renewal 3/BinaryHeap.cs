using System;
using System.Collections.Generic;

namespace _06.Renewal_3
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
            this.heap = new List<T>();
            this.Heapify();
        }

        private void Heapify()
        {
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }
        }

        public int Count => this.heap.Count;

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[this.Count - 1];
            this.heap.RemoveAt(this.Count - 1);

            if (this.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Insert(T node)
        {
            this.heap.Add(node);
            this.HeapifyUp(this.Count - 1);
        }

        private void HeapifyUp(int i)
        {
            int parent = (i - 1) / 2;
            while (parent >= 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                this.Swap(ref parent, ref i);
                this.HeapifyUp(parent);
            }
        }

        private void HeapifyDown(int i)
        {
            int leftChildIndex = (i * 2) + 1;
            int rightChildIndex = (i * 2) + 2;
            int smallest = i;
            if (leftChildIndex < this.Count &&
                this.heap[leftChildIndex].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = leftChildIndex;
            }

            if (rightChildIndex < this.Count &&
                this.heap[rightChildIndex].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = rightChildIndex;
            }

            if (smallest != i)
            {
                Swap(ref smallest, ref i);
                this.HeapifyDown(smallest);
            }
        }

        private void Swap(ref int firstIndex, ref int secondindex)
        {
            T temp = this.heap[firstIndex];
            this.heap[firstIndex] = this.heap[secondindex];
            this.heap[secondindex] = temp;
        }
    }
}