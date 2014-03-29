using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentSystem
{
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
}