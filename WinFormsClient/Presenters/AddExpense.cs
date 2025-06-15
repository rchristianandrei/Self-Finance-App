using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Forms;
using WinFormsClient.Models;

namespace WinFormsClient.Presenters;

internal class AddExpense
{
    public readonly AddExpenseForm AddExpenseForm = new();

    public AddExpense()
    {
        this.AddExpenseForm.Date = DateTime.Now;
        this.AddExpenseForm.Add += AddExpenseForm_Add;
    }

    private void AddExpenseForm_Add(object? sender, EventArgs e)
    {
        var amount = this.AddExpenseForm.Amount;
        double dAmount;
        var type = this.AddExpenseForm.Type;
        var date = this.AddExpenseForm.Date;
        var description = this.AddExpenseForm.Description;

        if (string.IsNullOrWhiteSpace(amount))
        {
            MessageBox.Show("Amount cannot be empty", "Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        else if(!Double.TryParse(amount, out dAmount))
        {
            MessageBox.Show("Amount is not a number", "Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        else if(dAmount <= 0)
        {
            MessageBox.Show("Amount must be greater then 0.00", "Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }


        if (string.IsNullOrWhiteSpace(type))
        {
            MessageBox.Show("Type cannot be empty", "Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var output = MessageBox.Show("Are you sure you want to add this entry?", "Add Expense", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (output == DialogResult.No) return;

        MessageBox.Show("Entry Added!" + dAmount);

        var expenseEntry = new ExpenseEntryModel()
        {
            Amount = dAmount,
            Type = type,
            Description = description,
            Date= date,
        };
    }
}
