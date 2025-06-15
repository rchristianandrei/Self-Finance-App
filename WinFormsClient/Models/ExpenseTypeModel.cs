using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Models;

internal class ExpenseTypeModel
{

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}
