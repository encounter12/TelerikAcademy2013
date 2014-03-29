using System;

namespace MobilePhone.Library
{
    public class Display
    {
        private float? size;
        private uint? colorsNumber;

        public Display(float? size, uint? colorsNumber)
        {
            this.Size = size;
            this.ColorsNumber = colorsNumber;
        }

        public Display(): this(null, null)
        {         
        }

        public override string ToString()
        {
            return string.Format("Display Details\n Size: {0}\n Colors Number: {1}\n"
                , this.Size, this.ColorsNumber);
        }

        public float? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentException("Invalid argument: Size should be positive number.");
                }

                this.size = value;
            }
        }

        public uint? ColorsNumber
        {
            get
            {
                return this.colorsNumber;
            }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentException("Invalid argument: Number of colors should be a positive number.");
                }

                this.colorsNumber = value;
            }
        }
    }
}
