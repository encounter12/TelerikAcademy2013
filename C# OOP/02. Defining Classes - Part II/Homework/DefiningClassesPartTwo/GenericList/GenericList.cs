using System;
using System.Collections.Generic;

namespace GenericListClass
{
    public class GenericList<T> where T : IComparable
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int count;
        private int capacity;

        public GenericList(int startCapacity)
        {
            this.items = new T[startCapacity];          
        }

        public GenericList(): this(DefaultCapacity) 
        {
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                this.capacity = items.Length * 2;

                T[] newItems = new T[this.capacity];
                Array.Copy(items, 0, newItems, 0, count);
                items = newItems;
            }

            items[count] = item;
            count++;
        }

        public T this[int index]
        { 
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("The index is out of range");
                }

                return this.items[index]; 
            }

            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("The index is out of range");
                }

                this.items[index] = value;
            } 
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            count--;

            if (index < count)
            {
                Array.Copy(items, index + 1, items, index, count - index);
            }

            items[count] = default(T);
        }

        public void Insert(int index, T item)
        {
            if (index > count || index < 0)
            {
                throw new ArgumentOutOfRangeException("The index is out of range");
            }

            if (count == items.Length)
            {
                this.capacity *= 2;
                T[] newItems = new T[this.capacity];
                Array.Copy(items, 0, newItems, 0, count);
                items = newItems;
            }

            if (index < count)
            {
                Array.Copy(items, index, items, index + 1, count - index);
            }

            items[index] = item;
            count++;
        }

        public void Clear()
        {
            if (count > 0)
            {
                Array.Clear(items, 0, count);
                count = 0;
            }
        }

        public int FindIndex(T item)
        {
            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (Comparer<T>.Equals(items[i], item) == true)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public override string ToString()
        {
            string[] info = new string[this.count];

            for (int i = 0; i < this.count; i++)
            {
                info[i] = this.items[i].ToString();
            }

            return "{ " + string.Join(", ", info) + " }";
        }

        public T Min()
        {
            if (this.count == 0)
            {
                throw new Exception("List is empty");
            }

            int minIndex = 0;

            for (int i = 1; i < this.count; i++)
            {
                if (this.items[i].CompareTo(this.items[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }

            return this.items[minIndex];
        }

        public T Max()
        {
            if (this.count == 0)
            {
                throw new Exception("List is empty");
            }

            int maxIndex = 0;

            for (int i = 1; i < this.count; i++)
            {
                if (this.items[i].CompareTo(this.items[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }

            return this.items[maxIndex];
        }
    }

}
