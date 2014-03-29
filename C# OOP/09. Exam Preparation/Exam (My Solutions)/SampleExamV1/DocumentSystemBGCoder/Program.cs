using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentSystem
{
    public interface IDocument
    {
        string Name { get; }

        string Content { get; }

        void LoadProperty(string key, string value);

        void SaveAllProperties(IList<KeyValuePair<string, object>> output);

        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool Isencrypted { get; }

        void Encrypt();

        void Decrypt();
    }

    public class DocumentSystem
    {
        static void Main()
        {
            IList<string> allCommands = DocumentSystem.ReadAllCommands();
            DocumentSystem.ExecuteCommands(allCommands);
        }

        private static IList<Document> documents = new List<Document>();

        static IList<Document> Documents
        {
            get
            {
                return documents;
            }
            set
            {
                documents = value;
            }
        }

        public static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        public static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPDFDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static Dictionary<string, string> ParseProperties(string[] attributes, out string name)
        {
            name = null;
            Dictionary<string, string> properties = new Dictionary<string, string>();

            foreach (string attribute in attributes)
            {
                string[] keyValue = attribute.Split('=');

                if (keyValue[0] == "name")
                {
                    name = keyValue[1];
                }
                else
                {
                    properties.Add(keyValue[0], keyValue[1]);
                }
            }

            return properties;
        }

        private static void CreateDocument(string name, Dictionary<string, string> properties, string documentType)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                Console.WriteLine("Document has no name");
            }
            else
            {
                // dynamically create Document instance of type documentType
                // http://stackoverflow.com/questions/15449800/create-object-instance-of-a-class-having-its-name-in-string-variable
                string namespaceName = "DocumentSystem";
                Type docType = Type.GetType(namespaceName + "." + documentType);
                Document document = (Document)Activator.CreateInstance(docType, new object[] { name });

                foreach (KeyValuePair<string, string> property in properties)
                {
                    document.LoadProperty(property.Key, property.Value);
                }

                documents.Add(document);

                Console.WriteLine("Document added: {0}", name);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "TextDocument");
        }

        private static void AddPDFDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "PDFDocument");
        }

        private static void AddWordDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "WordDocument");
        }

        private static void AddExcelDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "ExcelDocument");
        }

        private static void AddAudioDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "AudioDocument");
        }

        private static void AddVideoDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "VideoDocument");
        }

        private static void ListDocuments()
        {
            if (Documents.Count > 0)
            {
                foreach (var document in Documents)
                {
                    Console.WriteLine(document);
                }
            }
            else
            {
                Console.WriteLine("No documents found");
            }
        }

        private static void EncryptDocument(string name)
        {
            bool documentFound = false;

            foreach (Document document in Documents)
            {
                if (document.Name == name)
                {
                    documentFound = true;
                    if (document is IEncryptable)
                    {
                        IEncryptable encryptableDocument = (IEncryptable)document;
                        encryptableDocument.Encrypt();
                        Console.WriteLine("Document encrypted: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", document.Name);
                    }
                }
            }

            if (documentFound == false)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool documentFound = false;

            foreach (Document document in Documents)
            {
                if (document.Name == name)
                {
                    documentFound = true;
                    if (document is IEncryptable)
                    {
                        IEncryptable encryptableDocument = (IEncryptable)document;
                        encryptableDocument.Decrypt();
                        Console.WriteLine("Document decrypted: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", document.Name);
                    }
                }
            }

            if (documentFound == false)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool encryptableDocumentFound = false;

            foreach (Document document in Documents)
            {
                if (document is IEncryptable)
                {
                    encryptableDocumentFound = true;
                    IEncryptable encryptableDocument = (IEncryptable)document;
                    encryptableDocument.Encrypt();
                }
            }

            if (encryptableDocumentFound == true)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool documentFound = false;

            foreach (var document in Documents)
            {
                if (document.Name == name)
                {
                    documentFound = true;
                    if (document is IEditable)
                    {
                        IEditable editableDocument = (IEditable)document;
                        editableDocument.ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}", document.Name);
                    }
                }
            }

            if (documentFound == false)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }
    }

    class Document : IDocument
    {
        private string name;
        private string content;
        private IList<KeyValuePair<string, object>> properties;

        public Document(string name)
        {
            this.Name = name;
        }

        private Document()
        {
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

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        public IList<KeyValuePair<string, object>> Properties
        {
            get
            {
                return this.properties;
            }
            set
            {
                this.properties = value;
            }
        }

        public void LoadProperty(string key, string value)
        {
            string keyFirstCharUpper = FirstCharToUpper(key);
            PropertyInfo propertyInfo = this.GetType().GetProperty(keyFirstCharUpper);
            propertyInfo.SetValue(this, value);
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                output.Add(new KeyValuePair<string, object>(property.Name.ToString(), property.GetValue(this)));
            }
        }

        public override string ToString()
        {
            string docType = this.GetType().Name;

            IList<KeyValuePair<string, object>> output = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(output);

            StringBuilder sb = new StringBuilder();
            sb.Append(docType).Append("[");

            if (this is IEncryptable)
            {
                IEncryptable encryptableDoc = (IEncryptable)this;
                if (encryptableDoc.Isencrypted == true)
                {
                    sb.Append("encrypted");
                }
                else
                {
                    AppendAttributes(sb, output);
                }
            }
            else
            {
                AppendAttributes(sb, output);
            }

            sb.Append("]");

            return sb.ToString();
        }

        private void AppendAttributes(StringBuilder sb, IList<KeyValuePair<string, object>> output)
        {
            var ordered = output.OrderBy(f => f.Key);
            foreach (var pair in ordered)
            {
                if (pair.Value != null && pair.Key != "Isencrypted")
                {
                    sb.AppendFormat("{0}={1};", pair.Key.ToLower(), pair.Value);
                }
            }

            sb.Length--;
        }

        private static string FirstCharToUpper(string input)
        {
            char[] array = input.ToCharArray();
            array[0] = char.ToUpper(array[0]);
            string result = new string(array);
            return result;
        }
    }

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

    class AudioDocument : MultimediaDocument
    {
        private string samplerate;

        public AudioDocument(string name) : base(name)
        {
        }

        public string Samplerate
        {
            get
            {
                return this.samplerate;
            }
            set
            {
                this.samplerate = value;
            }
        }
    }

    class VideoDocument : MultimediaDocument
    {
        private string framerate;

        public VideoDocument(string name) : base(name)
        {
        }

        public string Framerate
        {
            get
            {
                return this.framerate;
            }
            set
            {
                this.framerate = value;
            }
        }
    }
}