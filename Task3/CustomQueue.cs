using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CustomQueue<T>: IEnumerable<T>
    {
        private T[] array;
        private int size;
        private int head;
        private int tail;

        private T this[int index]
        {
            get { return array[(head + index) % array.Length]; }
        }

        public int Count
        {
            get { return size; }
        }

        public CustomQueue()
        {
            array = new T[0];
        }

        public CustomQueue(int capacity)
        {
            array = new T[capacity];
            size = 0;
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (size == array.Length)
            {
                int newCapacity = array.Length * 2;
                ChangeQueueCapacity(newCapacity);
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException("Queue is empty");

            T deleted = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            size--;

            return deleted;
        }

        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("Queue is empty");

            return array[head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomQueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ChangeQueueCapacity(int newCapacity)
        {
            T[] newArray = new T[newCapacity];

            if (size > 0)
            {
                if (head < tail)
                    Array.Copy(array, head, newArray, 0, size);
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }
            }

            array = newArray;
            head = 0;
            tail = size;
        }

        public class CustomQueueEnumerator : IEnumerator<T>
        {
            private CustomQueue<T> customQueue;
            private int i;
            private T currentItem;

            internal CustomQueueEnumerator(CustomQueue<T> queue)
            {
                customQueue = queue;
                i = -1;
                currentItem = default(T);
            }

            public T Current
            {
                get 
                {
                    if (i < 0)
                        throw new InvalidOperationException("Cannot enumerate");

                    return currentItem;
                }
            }

            public void Dispose()
            {
                i = -2;
                currentItem = default(T);
            }

            object IEnumerator.Current
            {
                get 
                {
                    return Current;
                }
            }

            public bool MoveNext()
            {
                if (i == -2)
                    return false;

                i++;
                if (i == customQueue.size)
                    return false;
                currentItem = customQueue[i];
                return true;
            }

            public void Reset()
            {
                i = -1;
                currentItem = default(T);
            }
        }
    }
}
