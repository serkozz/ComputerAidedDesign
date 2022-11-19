using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class DatabaseProcessor
{
    public const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Repositories\SAPR1\db\Database1.mdf;Integrated Security=True";
    SqlConnection connection = new SqlConnection(connectionString);

    public bool AddDocumentsDataToDB(Document document)
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            connection.Open();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Documents(document_name,document_creation_time,document_full_path,document_byte_array) VALUES (@name,@creation_time,@path,@pdf)";

            FileStream fs = File.OpenRead(document.FullPath);
            MemoryStream ms = new MemoryStream();
            fs.CopyTo(ms);

            cmd.Parameters.AddWithValue("@name", document.Name).Value = document.Name;
            cmd.Parameters.AddWithValue("@creation_time", SqlDbType.DateTime).Value = document.CreationTime;
            cmd.Parameters.AddWithValue("@path", document.FullPath).Value = document.FullPath;
            cmd.Parameters.AddWithValue("@pdf", SqlDbType.VarBinary).Value = ms.ToArray();

            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
        }
    }

    public void GetDocumentPDFFromDB(string DBpathToDoc, string localPathToDoc)
    {
        connection.Open();
        // string[] pathSeparated = DBpathToDoc.Split("\\");
        // string path = string.Empty;

        // foreach (string str in pathSeparated)
        // {
        //     path += str + @"\";
        // }

        string cmdText = $"SELECT document_byte_array FROM Documents WHERE document_full_path = N'{DBpathToDoc}'";

        FileStream fs = new FileStream(localPathToDoc, FileMode.OpenOrCreate, FileAccess.ReadWrite);

        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        {
            var result = cmd.ExecuteScalar();
            byte[] byteArray = (byte[])result;
            fs.Write(byteArray);
        }
        fs.Close();
        connection.Close();
    }
}
