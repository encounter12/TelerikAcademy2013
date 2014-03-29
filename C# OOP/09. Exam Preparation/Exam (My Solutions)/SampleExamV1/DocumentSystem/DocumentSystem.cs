using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystem
    {
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
}