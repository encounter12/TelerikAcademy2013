namespace VersionAttributes
{
    using System;

 
    /// Custom Version attribute. Consists of major and minor version
    [AttributeUsage(
        AttributeTargets.Struct | 
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Method |
        AttributeTargets.Enum
    )]
    public class VersionAttribute : Attribute
    {
        private readonly int major;
        private readonly int minor;

        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public string GetVersion
        {
            get
            {
                return major + "." + minor;
            }
        }
    }
}
