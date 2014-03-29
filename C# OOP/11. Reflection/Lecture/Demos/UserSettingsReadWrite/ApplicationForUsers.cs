namespace UserSettingsReadWrite
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class ApplicationForUsers
    {
        public static void Main()
        {
            Console.WriteLine("Enter your data");

            SaveUserProfile();

            var user = LoadUserProfile();

            Console.WriteLine("\nLoaded user: \n" + user.ToString());
        }

        private static User LoadUserProfile()
        {
            var userResult = new User();

            var assembly = Assembly.GetExecutingAssembly();

            var userType =
                assembly.GetType("UserSettingsReadWrite.User");

            var fileReader = new StreamReader("userdata.ud");

            using (fileReader)
            {
                var line = fileReader.ReadLine();

                while (line != null)
                {
                    var currentProperty = userType.GetProperty(line);
                    var currentPropertyType = currentProperty.PropertyType;

                    var convertedValue = 
                        Convert.ChangeType(fileReader.ReadLine(), currentPropertyType);

                    currentProperty.SetValue(userResult, convertedValue);

                    line = fileReader.ReadLine();
                }
            }

            return userResult;
        }

        private static void SaveUserProfile()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var userTypeProperties =
                assembly.GetType("UserSettingsReadWrite.User").GetProperties();

            var fileWriter = new StreamWriter("userdata.ud");

            using (fileWriter)
            {
                foreach (var property in userTypeProperties)
                {
                    var displayName = Helpers.GetName(property);

                    Console.Write("Enter {0}: ", displayName);
                    var value = Console.ReadLine();

                    fileWriter.WriteLine(property.Name);
                    fileWriter.WriteLine(value);
                }
            }
        }
    }
}
