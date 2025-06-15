using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsClient.Repositories;

internal class ExpenseEntryRepo
{
    private readonly string connString = "Server=localhost;Database=self_finance_app;Uid=root;Pwd=admin1234;";

    private readonly string Id = "id";
    private readonly string Username = "username";
    private readonly string Amount = "amount";
    private readonly string Type = "type";
    private readonly string Description = "description";
    private readonly string Date = "date";

    private readonly string ParameterId = "@id";
    private readonly string ParameterUsername = "@username";
    private readonly string ParameterAmount = "@amount";
    private readonly string ParameterType = "@type";
    private readonly string ParameterDescription = "@description";
    private readonly string ParameterDate = "@date";

    public async Task AddEntry(ExpenseEntryModel entry)
    {
        if (entry.Type == null) return;

        var isNew = entry.Id <= 0;
        var query = isNew ? 
            $"INSERT INTO tbl_expense_entries({Username}, {Amount}, {Type}, {Description}, {Date})\r\n" +
            $"VALUES({ParameterUsername}, {ParameterAmount}, {ParameterType}, {ParameterDescription}, {ParameterDate})\r\n":
            $"INSERT INTO tbl_expense_entries({Id}, {Username}, {Amount}, {Type}, {Description}, {Date})\r\n" +
            $"VALUES({ParameterId}, {ParameterUsername}, {ParameterAmount}, {ParameterType}, {ParameterDescription}, {ParameterDate})\r\n";

        query += "ON DUPLICATE KEY UPDATE\r\n" +
            $"{Amount} = VALUES({Amount}),\r\n" +
            $"{Type} = VALUES({Type}),\r\n" +
            $"{Description} = VALUES({Description}),\r\n" +
            $"{Date} = VALUES({Date:YYYY-MM-DD HH:MM:SS});";

        List<MySqlParameter> parameters = [
            new (ParameterUsername, "andrei"),
            new (ParameterAmount, entry.Amount),
            new (ParameterType, entry.Type.Id),
            new (ParameterDescription, entry.Description),
            new (ParameterDate, entry.Date)
        ];
        if (isNew) parameters.Add(new MySqlParameter(ParameterId, entry.Id));

        var conn = new MySqlConnection(connString);
        try
        {
            await conn.OpenAsync();
            var command = new MySqlCommand(query, conn);
            command.Parameters.AddRange(parameters.ToArray());
            await command.ExecuteNonQueryAsync();
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            await conn.CloseAsync();
        }
    }
}
