namespace NewProductInsertion
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    internal class NewProductInsertion
    {
        private const string DbConnectionString =
            "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";

        private static void Main()
        {
            string productName = "Grandma's bread";
            decimal unitPrice = 1.3m;
            Product product = new Product(productName, unitPrice);

            SqlConnection dbConnection = ConnectToDatabase(DbConnectionString);
            InsertNewProduct(product, dbConnection);
            DisconnectFromDB(dbConnection);
        }

        private static SqlConnection ConnectToDatabase(string dbConnectionString)
        {
            SqlConnection dbConnection = new SqlConnection(dbConnectionString);
            dbConnection.Open();
            return dbConnection;
        }

        private static void InsertNewProduct(Product product, SqlConnection dbConnection)
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO Products ([ProductName], [UnitPrice]) VALUES (@name, @unitPrice)", dbConnection);

            command.Parameters.AddWithValue("@name", product.ProductName);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product inserted successfully.");
            }
            catch (SqlException exception)
            {
                Console.WriteLine("SQL Error occured: " + exception);
            }
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
