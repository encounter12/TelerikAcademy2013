namespace NorthwindCategoriesRowsNumber
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    internal class NorthwindCategoriesRowsNumber
    {
        private const string DbConnectionString =
            "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";

        private static void Main()
        {
            SqlConnection dbConnection = ConnectToDatabase(DbConnectionString);
            string tableName = "Categories";
            int rowsCount = CountRowsInTable(dbConnection, tableName);
            Console.WriteLine("The number of rows in Northwind Categories table is: {0}", rowsCount);
        }

        private static SqlConnection ConnectToDatabase(string dbConnectionString)
        {
            SqlConnection dbConnection = new SqlConnection(dbConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

        private static int CountRowsInTable(SqlConnection dbConnection, string tableName)
        {
            int rowsCount;
            using (dbConnection)
            {
                string rowsCountCommandString = "SELECT COUNT(*) FROM " + tableName;
                SqlCommand rowsCountCommand = new SqlCommand(rowsCountCommandString, dbConnection);
                rowsCount = (int)rowsCountCommand.ExecuteScalar();
            }

            return rowsCount;
        }
    }
}