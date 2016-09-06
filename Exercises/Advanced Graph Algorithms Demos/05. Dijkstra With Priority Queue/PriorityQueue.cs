using System;
using System.Collections.Generic;

namespace _05.Dijkstra_With_Priority_Queue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;
        private Dictionary<T, int> searchCollection;

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
        }

        public int Count() => this.heap.Count;

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[this.Count() - 1];
            this.heap.RemoveAt(this.Count() - 1);
            if (this.Count() > 0)
            {
                this.HeapifyDown(0);
            }

            this.searchCollection.Remove(min);
            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Enqueue(T element)
        {
            this.searchCollection.Add(element, this.heap.Count);
            this.heap.Add(element);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyUp(int i)
        {
            int parent = (i - 1)/2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.searchCollection[this.heap[i]] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1)/2;
            }
        }

        private void HeapifyDown(int i)
        {
            int left = (i*2) + 1;
            int right = (i*2) + 2;
            int smallest = i;
            if (left < this.Count() && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.Count() && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.searchCollection[this.heap[i]] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;

                this.HeapifyDown(smallest);
            }
        }

        public void DecreaseKey(T element)
        {
            int index = this.searchCollection[element];
            this.HeapifyUp(index);
        }
    }
}