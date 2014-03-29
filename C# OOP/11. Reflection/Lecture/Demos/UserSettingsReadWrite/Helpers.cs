namespace UserSettingsReadWrite
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Helpers
    {
        internal static string GetName(PropertyInfo property)
        {
            var descriptionAttribute = property.GetCustomAttributes()
                .FirstOrDefault(attr => attr.GetType().Name == "DescriptionAttribute");

            if (descriptionAttribute == null)
            {
                return property.Name;
            }
            else
            {
                return descriptionAttribute
                    .GetType().GetProperty("Name").GetValue(descriptionAttribute).ToString();
            }
        }
    }
}
