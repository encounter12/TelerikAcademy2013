namespace System.Collections.Generic 
{ 

    //Implements a variable-size List that uses an array of objects to store the
    // elements. A List has a capacity, which is the allocated length 
    // of the internal array. As elements are added to a List, the capacity
    // of the List is automatically increased as required by reallocating the
    // internal array.
        
    public class List<T> : IList<T>, System.Collections.IList, IReadOnlyList<T>
    { 
        private const int DefaultCapacity = 4;

        private T[] items;
        private int size;
        private int version; 
        static readonly T[] emptyArray = new T[0];

        // Constructs a List. The list is initially empty and has a capacity
        // of zero. Upon adding the first element to the list the capacity is 
        // increased to 16, and then increased in multiples of two as required.

        public List() 
        { 
            items = emptyArray;
        }

         public List(int capacity) 
        {
            if (capacity < 0) 
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }
            
            Contract.EndContractBlock(); 

            if (capacity == 0)
            {            
                items = emptyArray;
            }                
            else
            {
                items = new T[capacity];
            }                
        }

        // Adds the given object to the end of this list. The size of the list is
        // increased by one. If required, the capacity of the list is doubled
        // before adding the new element. 
                
        public void Add(T item) 
        { 
            if (size == items.Length) 
            {
                EnsureCapacity(size + 1); 
            }
            
            items[size] = item;
            size++;
            version++; 
        }
        
        // Ensures that the capacity of this list is at least the given minimum 
        // value. If the currect capacity of the list is less than min, the
        // capacity is increased to twice the current capacity or to min, 
        // whichever is larger. 

        private void EnsureCapacity(int min) 
        {
            if (items.Length < min)
            { 
                int newCapacity;
                
                if (items.Length == 0)
                {
                    newCapacity = DefaultCapacity;
                }
                else
                {
                    newCapacity = items.Length * 2;
                }
                
                // Allow the list to grow to maximum possible capacity (~2G elements) before ensizeering overflow.
                // Note that this check works even when items.Length overflowed thanks to the (uint) cast
                
                if ((uint)newCapacity > Array.MaxArrayLength) 
                {
                    newCapacity = Array.MaxArrayLength; 
                }
                
                if (newCapacity < min) 
                { 
                    newCapacity = min;
                }
                Capacity = newCapacity; 
            } 
        }
        
        
        // Gets and sets the capacity of this list.  The capacity is the size of
        // the internal array used to hold items.  When set, the internal 
        // array of the list is reallocated to the given capacity.
        
        public int Capacity 
        { 
            get 
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return items.Length; 
            }
            set 
            { 
                if (value < size) 
                { 
                    ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
                } 
                Contract.EndContractBlock();

                if (value != items.Length) 
                {
                    if (value > 0) 
                    { 
                        T[] newItems = new T[value];
                        if (size > 0) 
                        { 
                            Array.Copy(items, 0, newItems, 0, size); 
                        }
                        items = newItems; 
                    }
                    else 
                    {
                        items = emptyArray;
                    } 
                }
            } 
        }
        
        // Sets or Gets the element at the given index. 
        public T this[int index] 
        {
            get 
            {
                // Following trick can reduce the range check by one 
                if ((uint)index >= (uint)size) 
                {
                    ThrowHelper.ThrowArgumentOutOfRangeException(); 
                } 
                Contract.EndContractBlock();
                return items[index]; 
            }
            
            set 
            { 
                if ((uint)index >= (uint)size) 
                { 
                    ThrowHelper.ThrowArgumentOutOfRangeException();
                } 
                Contract.EndContractBlock();
                items[index] = value;
                version++;
            } 
        }
        
        // Removes the element at the given index. The size of the list is
        // decreased by one.
        // 
        public void RemoveAt(int index) 
        {
            if ((uint)index >= (uint)size) 
            { 
                ThrowHelper.ThrowArgumentOutOfRangeException(); 
            }
            
            Contract.EndContractBlock(); 
            size--;
            
            if (index < size) 
            {
                Array.Copy(items, index + 1, items, index, size - index);
            } 
            
            items[size] = default(T);
            version++; 
        } 
    }
}