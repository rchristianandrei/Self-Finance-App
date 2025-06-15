using MySql.Data.MySqlClient;
using WinFormsClient.Models;

namespace WinFormsClient.Repositories;

internal class ExpenseTypeRepo
{
    private readonly string connString = "Server=localhost;Database=self_finance_app;Uid=root;Pwd=admin1234;";

    public async Task<List<ExpenseTypeModel>> Get()
    {
        List<ExpenseTypeModel> types = [];

        var conn = new MySqlConnection(connString);
        try
        {
            await conn.OpenAsync();
            var command = new MySqlCommand("SELECT * FROM tbl_expense_types ORDER BY name;", conn);
            var reader = await command.ExecuteReaderAsync();

            while (reader.Read()) {
                int id = (int)reader["id"];
                string name = (string)reader["name"];
                DateTime timestamp = (DateTime)reader["timestamp"];

                types.Add(new ExpenseTypeModel()
                {
                    Id = id, Name = name, Timestamp = timestamp
                });
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            await conn.CloseAsync();
        }

        return types;
    }
}
