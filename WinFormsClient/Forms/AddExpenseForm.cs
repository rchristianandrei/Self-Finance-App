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

    public object? Type
    {
        get => cboType.SelectedItem;
        set => cboType.SelectedItem = value;
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

    public void SetTypes(List<object> types)
    {
        cboType.Items.Clear();
        foreach(object type in types)
        {
            cboType.Items.Add(type);
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        Add?.Invoke(this, EventArgs.Empty);
    }
}
