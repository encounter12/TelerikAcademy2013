using System;
using System.Linq;
using System.Text;
using Company.Data;

namespace Company.SampleDataGenerator
{
    class ReportDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportDataGenerator(IRandomDataGenerator randomDataGenerator, Company20140908Entities company20140908Entities, int countOfGeneratedObjects)
            : base(randomDataGenerator, company20140908Entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding reports");
            
            for (int i = 0; i < this.Count; i++)
            {
                var datetimeSb = new StringBuilder();
                datetimeSb.Append(this.Random.GetRandomNumber(1950, 2020));
                datetimeSb.Append("-");
                datetimeSb.Append(this.Random.GetRandomNumber(1, 12));
                datetimeSb.Append("-");
                datetimeSb.Append(this.Random.GetRandomNumber(1, 28));
                datetimeSb.Append(" ");
                datetimeSb.Append(this.Random.GetRandomNumber(0, 23));
                datetimeSb.Append(":");
                datetimeSb.Append(this.Random.GetRandomNumber(0, 59));
                datetimeSb.Append(":");
                datetimeSb.Append(this.Random.GetRandomNumber(0, 59));

                var report = new Report 
                {
                    ReportTime = DateTime.Parse(datetimeSb.ToString())
                };

                this.Database.Reports.Add(report);

                if (i % 500 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nReports added");
        }
    }
}
