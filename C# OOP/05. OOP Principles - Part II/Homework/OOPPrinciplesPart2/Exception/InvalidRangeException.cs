using System;

namespace Exception
{
    public class InvalidRangeException<T> : ApplicationException
    {
        private T startRange;
        private T endRange;
        private T value;

        public InvalidRangeException(T startRange, T endRange, T value)
            : base()
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
            this.Value = value;
        }

        //public InvalidRangeException(T startRange, T endRange, T value, string msg, Exception innerEx)
        //    : base(msg, innerEx)
        //{
        //    this.StartRange = startRange;
        //    this.EndRange = endRange;
        //    this.Value = value;
        //}

        public T StartRange
        {
            get
            {
                return this.startRange;
            }
            set
            {
                this.startRange = value;
            }
        }

        public T EndRange
        {
            get
            {
                return this.endRange;
            }
            set
            {
                this.endRange = value;
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public override string Message
        {
            get
            {
                return string.Format("The input value {0} is out of the range [{1}, {2}]", this.Value, this.StartRange, this.EndRange);
            }
        }
    }
}