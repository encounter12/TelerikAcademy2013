using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class HTMLTable: HTMLElement, ITable
    {
        private int rows;
        private int cols;
        private const string TableName = "table";
        private IElement[,] cells;

        public HTMLTable(int rows, int cols) : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.cells = new IElement[rows, cols];
        }
        public int Rows
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

        public int Cols
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

        public IElement this[int row, int col]
        {
            get
            {
                return this.cells[row, col];
            }
            set
            {
                this.cells[row, col] = value;
            }
        }

        public string Name
        {
            get 
            {
                return TableName; 
            }
        }

        public string TextContent
        {
            get
            {
                throw new InvalidOperationException();
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get 
            {
                throw new InvalidOperationException("HTML tables do not have child elements!");
            }
        }

        public void AddElement(IElement element)
        {
            throw new InvalidOperationException("HTML tables do not have child elements so such cannot be added!");
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    output.AppendFormat("{0}", this.cells[row, col].ToString());
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.AppendFormat("</{0}>", this.Name);
        }        
    }
}