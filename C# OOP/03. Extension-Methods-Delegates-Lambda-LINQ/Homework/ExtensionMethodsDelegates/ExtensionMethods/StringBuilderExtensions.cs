using System;
using System.Text;

namespace ExtensionMethods
{
    public static class StringBuilderExtensions
    {
        //extension method for StringBuilder corresponding to Substring method in System.String class: http://msdn.microsoft.com/en-us/library/hxthx5h6.aspx
        //The sub-StringBuilder starts at a specified character position (zero-based) and continues to the end of the StringBuilder.
        //Return type: StringBuilder 

        public static StringBuilder Substring(this StringBuilder sb, int startIndex)
        {
            StringBuilder substring = new StringBuilder();
            string str = sb.ToString();
            return substring.Append(str, startIndex, str.Length - startIndex);
        }

        //extension method for StringBuilder corresponding to Substring method in System.String class: http://msdn.microsoft.com/en-us/library/aka44szs.aspx
        //The sub-StringBuilder starts at a specified character position (startIndex) and has a specified length (count).
        //Return type: StringBuilder

        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int count)
        {
            StringBuilder substring = new StringBuilder();
            return substring.Append(sb.ToString(), startIndex, count);
        }

        
    }
}
