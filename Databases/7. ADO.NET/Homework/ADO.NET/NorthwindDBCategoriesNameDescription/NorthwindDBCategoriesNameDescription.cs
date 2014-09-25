namespace NorthwindDBCategoriesNameDescription
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    internal class NorthwindDBCategoriesNameDescription
    {
        private const string DbConnectionString =
            "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";

        private static void Main()
        {
            SqlConnection dbConnection = ConnectToDatabase(DbConnectionString);
            string tableName = "Categories";
            string[] columns = new string[] { "CategoryName", "Description" };
            string selectedColumnsRecords = RetrieveTableColumns(dbConnection, tableName, columns);

            Console.WriteLine(selectedColumnsRecords);
        }

        private static SqlConnection ConnectToDatabase(string dbConnectionString)
        {
            SqlConnection dbConnection = new SqlConnection(dbConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

        private static string RetrieveTableColumns(SqlConnection dbConnection, string tableName, string[] columns)
        {
            string selectedColumns = string.Empty;
            string commandString = "SELECT " + string.Join(", ", columns) + " FROM " + tableName;

            using (dbConnection)
            {
                SqlCommand cmdSelectedColumns = new SqlCommand(commandString, dbConnection);

                SqlDataReader reader = cmdSelectedColumns.ExecuteReader();
                using (reader)
                {
                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        string columnEntry;
                        foreach (var column in columns)
                        {
                            columnEntry = (string)reader[column];
                            sb.Append(columnEntry).Append(" - ");
                        }
                        sb.Remove(sb.Length - 3, 3).AppendLine();
                    }

                    selectedColumns = sb.ToString().TrimEnd();
                }
            }

            return selectedColumns;
        }
    }
}