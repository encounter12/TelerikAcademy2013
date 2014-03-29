using System;
using System.Linq;

namespace DocumentSystem
{
    class TextDocument : Document, IEditable
    {
        private string charset;

        public TextDocument(string name) : base(name)
        {
        }

        public string Charset
        {
            get
            {
                return this.charset;
            }
            set
            {
                this.charset = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}