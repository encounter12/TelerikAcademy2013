using System;
using System.Linq;

namespace DocumentSystem
{
    class BinaryDocument : Document
    {
        private string size;

        public BinaryDocument(string name) : base(name)
        {
        }
     
        public string Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}