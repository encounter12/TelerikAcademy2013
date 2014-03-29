using System;
using System.Linq;

namespace DocumentSystem
{
    class OfficeDocument : BinaryDocument, IEncryptable
    {
        private string version;
        private bool isEncrypted;

        public OfficeDocument(string name) : base(name)
        { 
        }
        
        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        public bool Isencrypted
        {
            get
            {
                return this.isEncrypted;
            }
            private set
            {
                this.isEncrypted = value;
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