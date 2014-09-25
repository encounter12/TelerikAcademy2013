namespace DataGenerator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    using Extensions;

    public static class Generate
    {
        private static readonly XDocument dataDocument;

        static Generate()
        {
            if (null == dataDocument)
            {
                using (Stream datafileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataGenerator.Data.xml"))
                {
                    if (datafileStream != null)
                    {
                        XmlTextReader xmlReader = new XmlTextReader(datafileStream);
                        dataDocument = XDocument.Load(xmlReader);
                    }
                }
            }
        }

        /// <summary>
        /// Random Number Generator
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <example>int myInt = GetRandomInt(5, 1000); // gives in random integer between 5 and 1000</example>
        public static int RandomInt(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        /// <summary>
        /// Returns a string representing a common name prefix, e.g. Mr., Mrs., Dr., etc.
        /// </summary>
        public static string RandomNamePrefix()
        {
            var randomPrefix = dataDocument.Descendants("data").Descendants("prefixes").Descendants("prefix").ToList().RandomItem(new Random());
            return randomPrefix.Value;
        }

        /// <summary>
        /// Returns a string representing a persons last name, randomly selected from actual first names.
        /// </summary>
        public static string RandomFirstName()
        {
            var randomName = dataDocument.Descendants("data").Descendants("names").Descendants("first").ToList().RandomItem(new Random());
            return randomName.Value;
        }

        /// <summary>
        /// Returns a string representing a persons last name, randomly selected from actual last names.
        /// </summary>
        public static string RandomLastName()
        {
            var randomName = dataDocument.Descendants("data").Descendants("names").Descendants("last").ToList().RandomItem(new Random());
            return randomName.Value;
        }

        /// <summary>
        /// Returns a string representing a persons full name, randomly selected from actual first and last names
        /// </summary>
        public static string RandomFullName()
        {
            return string.Format("{0} {1}", RandomFirstName(), RandomLastName());
        }

        /// <summary>
        /// Returns a string representing a common name suffix, e.g. III, Jr., M.D., etc.
        /// </summary>
        public static string RandomNameSuffix()
        {
            var randomSuffix = dataDocument.Descendants("data").Descendants("suffixes").Descendants("suffix").ToList().RandomItem(new Random());
            return randomSuffix.Value;
        }

        /// <summary>
        /// Returns a random company name based on a list of fake company names
        /// </summary>
        public static string RandomCompanyName()
        {
            var randomName = dataDocument.Descendants("data").Descendants("companies").Descendants("company").Descendants("name").ToList().RandomItem(new Random());
            return randomName.Value;
        }

        /// <summary>
        /// Returns a string representing a street address, e.g. 123 First Ave.
        /// </summary>
        public static string RandomStreetAddress()
        {
            var randomStreet = dataDocument.Descendants("data").Descendants("addresses").Descendants("streetNames").Descendants("streetName").ToList().RandomItem(new Random());
            var randomStreetSuffix = dataDocument.Descendants("data").Descendants("addresses").Descendants("streetSuffixes").Descendants("streetSuffix").ToList().RandomItem(new Random());
            return string.Format("{0} {1} {2}", RandomInt(1, 1999), randomStreet.Value, randomStreetSuffix.Value);
        }

        /// <summary>
        /// Returns a random name that could be a city
        /// </summary>
        public static string RandomCity()
        {
            var randomCity = dataDocument.Descendants("data").Descendants("cities").Descendants("city").Descendants("name").ToList().RandomItem(new Random());
            return randomCity.Value;
        }

        /// <summary>
        /// Returns a real US/Canadian State name at random, e.g Texas
        /// </summary>
        public static string RandomStateName()
        {
            var randomState = dataDocument.Descendants("data").Descendants("states").Descendants("state").Descendants("name").ToList().RandomItem(new Random());
            return randomState.Value;
        }

        /// <summary>
        /// Returns a real US/Canadian State code at random, e.g TX
        /// </summary>
        public static string RandomStateCode()
        {
            var randomState = dataDocument.Descendants("data").Descendants("states").Descendants("state").Descendants("code").ToList().RandomItem(new Random());
            return randomState.Value;
        }

        /// <summary>
        /// Returns a Random 5 digits between 11111 and 99999 to use for a zip code
        /// </summary>
        /// <remarks>Unlikely to produce many real zipcodes that the postoffice would recognize</remarks>
        public static string RandomZipCode()
        {
            return RandomInt(11111, 99999).ToString();
        }

        /// <summary>
        /// Returns a real country name at random
        /// </summary>
        public static string RandomCountry()
        {
            var randomCountry = dataDocument.Descendants("data").Descendants("countries").Descendants("country").Descendants("name").ToList().RandomItem(new Random());
            return randomCountry.Value;
        }

        /// <summary>
        /// Returns a real looking email address
        /// </summary>
        public static string RandomEmailAddress()
        {
            var randomDomain = dataDocument.Descendants("data").Descendants("domainNames").Descendants("domainName").ToList().RandomItem(new Random());
            var randomDomainSuffix = dataDocument.Descendants("data").Descendants("domainNameSuffixes").Descendants("suffix").ToList().RandomItem(new Random());
            return string.Format("{0}.{1}@{2}.{3}", RandomFirstName(), RandomLastName(), randomDomain.Value, randomDomainSuffix.Value);
        }

        /// <summary>
        /// Returns a 10 digit phone number in the format (###) ###-####
        /// </summary>
        /// <remarks>Area codes are unlikely to be real</remarks>
        public static string RandomPhone()
        {
            StringBuilder phone = new StringBuilder();

            // Lets generate 10 numbers
            while (phone.Length < 10)
            {
                int next = RandomInt(1, 999);
                phone.Append(next.ToString());
            }

            return String.Format("{0:(###) ###-####}", Convert.ToInt64(phone.ToString().Substring(0, 10)));
        }
    }
}
