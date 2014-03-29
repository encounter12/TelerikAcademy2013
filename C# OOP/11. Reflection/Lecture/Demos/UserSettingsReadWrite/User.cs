namespace UserSettingsReadWrite
{
    using System;
    using System.Reflection;
    using System.Text;

    public class User
    {
        [Description("First name")]
        public string FirstName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            var userTypeProperties = this.GetType().GetProperties();

            foreach (var property in userTypeProperties)
            {
                result.AppendFormat("{0}: {1}\n", 
                    Helpers.GetName(property), property.GetValue(this));
            }

            return result.ToString();
        }
    }
}
