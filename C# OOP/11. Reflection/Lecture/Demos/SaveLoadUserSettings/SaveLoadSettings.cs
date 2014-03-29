using System;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace SaveLoadUserSettings
{
    public class RegisterUserName
    {
        string MailOrUserName { get; set; }

        string Password { get; set; }
    }

    public class UserSettings
    {
        [Description("First name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                result.AppendLine(property.Name + ": " + property.GetValue(this));
            }

            return result.ToString();
        }
    }

    public class SaveLoadSettings
    {
        static void Main()
        {
            SaveSettings();

            var loadedSettings = LoadSettings();

            Console.WriteLine("\nLoaded settings");
            Console.WriteLine(loadedSettings);
        }

        static void SaveSettings()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var userSettings = assembly.GetTypes().FirstOrDefault(type => type.Name == "UserSettings");

            var userSettingsTypeProperties = userSettings.GetProperties();

            var file = new StreamWriter("settings.txt");

            using (file)
            {
                foreach (var property in userSettingsTypeProperties)
                {
                    var displayName = string.Empty;

                    var name = property.GetCustomAttributes().FirstOrDefault(attr => attr.GetType().Name == "DescriptionAttribute");
                    
                    if (name == null)
                    {
                        displayName = property.Name;
                    }
                    else
                    {
                        displayName = name.GetType().GetProperties().FirstOrDefault(prop => prop.Name == "Name").GetValue(name).ToString();
                    }

                    Console.Write(displayName + ": ");
                    var value = Console.ReadLine();

                    file.WriteLine(property.Name);
                    file.WriteLine(value);
                }
            }
        }

        static UserSettings LoadSettings()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var userSettings = assembly.GetTypes().FirstOrDefault(type => type.Name == "UserSettings");

            var file = new StreamReader("settings.txt");

            var currentSettings = Activator.CreateInstance(userSettings);

            using (file)
            {
                string line = file.ReadLine();

                while (line != null)
                {
                    var property = userSettings.GetProperty(line);
                    var type = property.PropertyType;
                    var value = file.ReadLine();

                    var newValue = Convert.ChangeType(value, type);

                    property.SetValue(currentSettings, newValue);

                    line = file.ReadLine();
                }
            }

            return currentSettings as UserSettings;
        }
    }
}
