using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient.Forms;

public partial class AddExpenseForm : Form
{
    public AddExpenseForm()
    {
        InitializeComponent();
    }

    public string Amount {
        get => txtAmount.Text;
        set => txtAmount.Text = value;
    }

    public string Type
    {
        get => cboType.Text;
        set => cboType.Text = value;
    }

    public DateTime Date
    {
        get => dtpDate.Value;
        set => dtpDate.Value = value;
    }

    public string Description
    {
        get => txtDescription.Text;
        set => txtDescription.Text = value;
    }

    public event EventHandler Add = delegate { };

    private void btnAdd_Click(object sender, EventArgs e)
    {
        Add?.Invoke(this, EventArgs.Empty);
    }
}
