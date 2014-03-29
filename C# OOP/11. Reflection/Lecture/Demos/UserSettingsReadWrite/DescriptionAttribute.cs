namespace UserSettingsReadWrite
{
    using System;

    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
