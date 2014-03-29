using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class HTMLElement : IElement
    {
        private string name;
        private string textContent;
        private ICollection<IElement> childElements;        

        public HTMLElement(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public HTMLElement(string name, string textContent) : this(name)
        {
            this.TextContent = textContent;
        }
        
        public string Name
        {
            get 
            { 
                return this.name; 
            }
            set
            {
                this.name = value;
            }
        }

        public string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                this.textContent = value;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get
            { 
                return this.childElements; 
            }            
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (!string.IsNullOrWhiteSpace(this.TextContent))
            {
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    char symbol = this.TextContent[i];
                    switch (symbol)
                    {
                        case '<':
                            output.Append("&lt;");
                            break;
                        case '>':
                            output.Append("&gt;");
                            break;
                        case '&':
                            output.Append("&amp;");
                            break;
                        default:
                            output.Append(symbol);
                            break;
                    }
                }
            }
            if (this.ChildElements != null)
            {
                foreach (var child in this.ChildElements)
                {
                    output.Append(child.ToString());
                }
                
            }
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }                       
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }
}