namespace WinFormsClient.Forms
{
    partial class AddExpenseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtAmount = new TextBox();
            lblAmount = new Label();
            btnAdd = new Button();
            cboType = new ComboBox();
            lblType = new Label();
            dtpDate = new DateTimePicker();
            lblDate = new Label();
            txtDescription = new RichTextBox();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(140, 39);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(155, 23);
            txtAmount.TabIndex = 0;
            txtAmount.Text = "0.00";
            txtAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(64, 43);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(57, 15);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "Amount: ";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(144, 234);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 36);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "Travel", "Food" });
            cboType.Location = new Point(140, 68);
            cboType.Name = "cboType";
            cboType.Size = new Size(155, 23);
            cboType.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(64, 72);
            lblType.Name = "lblType";
            lblType.Size = new Size(35, 15);
            lblType.TabIndex = 4;
            lblType.Text = "Type:";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(140, 97);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(155, 23);
            dtpDate.TabIndex = 2;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(64, 101);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 6;
            lblDate.Text = "Date:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(140, 126);
            txtDescription.MaxLength = 100;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(155, 77);
            txtDescription.TabIndex = 3;
            txtDescription.Text = "";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(64, 126);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 15);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Description:";
            // 
            // AddExpenseForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 282);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblDate);
            Controls.Add(dtpDate);
            Controls.Add(lblType);
            Controls.Add(cboType);
            Controls.Add(btnAdd);
            Controls.Add(lblAmount);
            Controls.Add(txtAmount);
            Name = "AddExpenseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Expense";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAmount;
        private Label lblAmount;
        private Button btnAdd;
        private ComboBox cboType;
        private Label lblType;
        private DateTimePicker dtpDate;
        private Label lblDate;
        private RichTextBox txtDescription;
        private Label lblDescription;
    }
}