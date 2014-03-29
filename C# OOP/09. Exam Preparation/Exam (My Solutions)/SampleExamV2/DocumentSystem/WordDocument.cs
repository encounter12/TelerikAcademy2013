using System;
using System.Linq;

namespace DocumentSystem
{
    class WordDocument : OfficeDocument, IEditable
    {
        private string chars;

        public WordDocument(string name) : base(name)
        { 
        }
    
        public string Chars
        {
            get
            {
                return this.chars;
            }
            set
            {
                this.chars = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}