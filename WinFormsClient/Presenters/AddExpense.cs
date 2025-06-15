using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Forms;
using WinFormsClient.Models;
using WinFormsClient.Repositories;

namespace WinFormsClient.Presenters;

internal class AddExpense
{
    public readonly AddExpenseForm AddExpenseForm = new();

    private readonly ExpenseTypeRepo expenseTypeRepo = new();
    private readonly ExpenseEntryRepo expenseEntryRepo = new();

    public AddExpense()
    {
        this.AddExpenseForm.Date = DateTime.Now;
        this.AddExpenseForm.Add += AddExpenseForm_Add;
        this.AddExpenseForm.Shown += AddExpenseForm_Shown;
    }

    private async void AddExpenseForm_Shown(object? sender, EventArgs e)
    {
        try
        {
            List<ExpenseTypeModel> types = await expenseTypeRepo.Get();

        AddExpenseForm.SetTypes([.. types.Cast<object>()]);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            this.AddExpenseForm.Close();
        }
    }

    private async void AddExpenseForm_Add(object? sender, EventArgs e)
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


        if (type == null)
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
            Type = (ExpenseTypeModel)type,
            Description = description,
            Date= date,
        };

        try
        {
            await this.expenseEntryRepo.AddEntry(expenseEntry);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
