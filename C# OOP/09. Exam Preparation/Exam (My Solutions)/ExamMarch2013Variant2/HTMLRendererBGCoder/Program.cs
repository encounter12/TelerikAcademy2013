using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace HTMLRenderer
{    
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

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

        public HTMLElement(string name, string textContent)
            : this(name)
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

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

    class HTMLTable : HTMLElement, ITable
    {
        private int rows;
        private int cols;
        private const string TableName = "table";
        private IElement[,] cells;

        public HTMLTable(int rows, int cols)
            : base(TableName)
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



    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        public static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        public static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}