using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractAllDatesFromText
{
    class ExtractAllDatesFromText
    {
        /*Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
         * Display them in the standard date format for Canada.*/

        
        static void Main(string[] args)
        {
            string text = "It was year 1723 when the armies of the west moved to the shores of Britania. " + 
                "On 05.09.1723 Admiral Perkins gave order for attack. Two weeks later 20.09.1723 the resistance has fallen.";
            
            Console.WriteLine("Excerpt:\n{0}", text);

            List<string> dates = ExtractDatesFromText(text, "en-CA");

            Console.WriteLine("Extracted dates (Canada format):");

            foreach (string date in dates)
            {
                Console.WriteLine(date);
            }
        }

        public static List<string> ExtractDatesFromText(string text, string culture)
        {
            string datePattern = @"\d{2}\.\d{2}\.\d{4}";

            List<string> dates = new List<string>();
            
            DateTime dateValue;
            string format = "d.MM.yyyy"; // or "dd.MM.yyyy"

            foreach (Match m in Regex.Matches(text, datePattern))
            {
                if (DateTime.TryParseExact(m.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                {
                    dates.Add(dateValue.ToString(new CultureInfo(culture).DateTimeFormat.ShortDatePattern));
                }
            }
            return dates;
        }
       
        /*foreach (Match m in Regex.Matches(text, datePattern))
        {
            Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
        }*/
        /*string myTime = DateTime.Parse("12/1/2011")
                   .ToString(CultureInfo.GetCultureInfo("en-GB").DateTimeFormat.ShortDatePattern);*/
        //culture = CultureInfo.CreateSpecificCulture("en-US"); styles = DateTimeStyles.None;
    }
}
