namespace NorthwindDBImagesSavingToDisk
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class NorthwindDBImagesSavingToDisk
    {
        private const string DbConnectionString =
            "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";
        private const int ImageMetaDataEnd = 78;
        // the folder path is our project \bin\Debug folder
        private const string FolderPath = @".\";

        private static void Main()
        {
            // first element of selectedColumns should be the counter (in our case CategoryID)
            // last element of selectedColumns should be the image binary file column.
            string[] selectedColumns = new string[] { "CategoryID", "CategoryName", "Picture" };
            string tableName = "Categories";
            string fileExtension = ".jpg";

            ExtractImagesFromDB(tableName, selectedColumns, FolderPath, fileExtension);
        }

        private static void ExtractImagesFromDB(string tableName, string[] selectedColumns, string folderPath, string fileExtension)
        {
            SqlConnection dbConn = new SqlConnection(DbConnectionString);
            dbConn.Open();

            using (dbConn)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT " + string.Join(", ", selectedColumns) +
                    " FROM " + tableName
                    , dbConn);

                SqlDataReader reader = command.ExecuteReader();
                StringBuilder stringBuilder = new StringBuilder();
                int imageIndex = selectedColumns.Length - 1;

                using (reader)
                {
                    while (reader.Read())
                    {
                        string fileName = ConstructFileName(reader, stringBuilder, selectedColumns, fileExtension);
                        byte[] image = (byte[])reader[selectedColumns[imageIndex]];
                        WriteBinaryFile(folderPath + fileName, image);
                    }
                }  
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, ImageMetaDataEnd, fileContents.Length - ImageMetaDataEnd);
            }
        }

        private static string ConstructFileName(SqlDataReader reader, StringBuilder stringBuilder, string[] selectedColumns, string fileExtension)
        {
            string counter = reader[selectedColumns[0]].ToString();
            stringBuilder.Append(counter).Append(".");

            for (int i = 1; i < selectedColumns.Length - 1; i++)
            {
                stringBuilder.Append(reader[selectedColumns[i]]);
            }

            stringBuilder.Replace(@"/", "_").Append(fileExtension);

            string fileName = stringBuilder.ToString();
            stringBuilder.Clear();

            return fileName;
        }
    }
}