using System;
using System.Linq;

namespace DocumentSystem
{
    class MultimediaDocument : BinaryDocument
    {
        private string length;

        public MultimediaDocument(string name) : base(name)
        {
        }
       
        public string Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }
    }
}