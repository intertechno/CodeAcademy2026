using Microsoft.Data.SqlClient;

string connStr = "Server=localhost\\SQLEXPRESS;Database=Northwind;" +
                 "Trusted_Connection=True;Encrypt=false;";
using SqlConnection conn = new(connStr);
conn.Open();

string sql = """
    SELECT CompanyName, ContactName
    FROM Customers
    WHERE Country = 'Finland'
    """;

using SqlCommand cmd = new(sql, conn);
using SqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    string companyName = reader["CompanyName"].ToString() ?? "";
    string contactName = reader["ContactName"].ToString() ?? "";
    Console.WriteLine($"{companyName} ({contactName})");
}
