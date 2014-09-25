namespace CategoriesAndProductNames
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    internal class CategoriesAndProductNames
    {
        private const string DbConnectionString =
            "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";

        private static void Main()
        {
            SqlConnection dbConnection = ConnectToDatabase(DbConnectionString);
            string categoriesAndNames = GroupByCategoriesAndNames(dbConnection);
            DisconnectFromDB(dbConnection);
            Console.WriteLine(categoriesAndNames);
        }

        private static SqlConnection ConnectToDatabase(string dbConnectionString)
        {
            SqlConnection dbConnection = new SqlConnection(dbConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

        private static string GroupByCategoriesAndNames(SqlConnection dbConnection)
        {
            string commandString = "SELECT c.CategoryName, p.ProductName " + 
                                   "FROM Products p " + 
	                               "INNER JOIN Categories c ON p.CategoryID = c.CategoryID " + 
                                   "GROUP BY c.CategoryName, p.ProductName";
            SqlCommand command = new SqlCommand(commandString, dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            string productCategoriesAndNames = string.Empty;
            using (reader)
            {
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    sb.AppendFormat("{0} - {1}", (string)reader["CategoryName"], (string)reader["ProductName"]).AppendLine();
                }
                productCategoriesAndNames = sb.ToString();
            }

            return productCategoriesAndNames;
        }

        private static void DisconnectFromDB(SqlConnection dbConnection)
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }
    }
}