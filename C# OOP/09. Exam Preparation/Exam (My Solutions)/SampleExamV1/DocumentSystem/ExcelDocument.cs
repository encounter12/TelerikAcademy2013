using System;
using System.Linq;

namespace DocumentSystem
{
    class ExcelDocument : OfficeDocument
    {
        private string rows;
        private string cols;

        public ExcelDocument(string name) : base(name)
        { 
        }
        
        public string Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.rows = value;
            }
        }

        public string Cols
        {
            get
            {
                return this.cols;
            }
            set
            {
                this.cols = value;
            }
        }
    }
}