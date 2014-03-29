using System;
using System.Linq;

namespace DocumentSystem
{
    class PDFDocument : BinaryDocument, IEncryptable
    {
        private string pages;
        private bool isencrypted;

        public PDFDocument(string name) : base(name)
        {
        }
        
        public string Pages
        {
            get
            {
                return this.pages;
            }
            set
            {
                this.pages = value;
            }
        }

        public bool Isencrypted
        {
            get
            {
                return this.isencrypted;
            }
            private set
            {
                this.isencrypted = value;
            }
        }

        public void Encrypt()
        {
            this.Isencrypted = true;
        }

        public void Decrypt()
        {
            this.Isencrypted = false;
        }
    }
}