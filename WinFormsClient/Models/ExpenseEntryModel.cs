using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Models;

internal class ExpenseEntryModel
{
    public int Id { get; set; } = 0;

    public double Amount { get; set; }

    public string Type { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string Description { get; set; } = String.Empty;
}
