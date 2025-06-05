using System;
using System.Windows.Forms;
using AiMailClient;

namespace AiMailWin
{
    public class AddAccountForm : Form
    {
        private readonly TextBox _email = new();
        private readonly TextBox _password = new();
        private readonly TextBox _server = new();
        private readonly Button _ok = new() { Text = "OK", DialogResult = DialogResult.OK };
        private readonly Button _cancel = new() { Text = "Cancel", DialogResult = DialogResult.Cancel };

        public string Email => _email.Text;
        public string Password => _password.Text;
        public string Server => _server.Text;

        public AddAccountForm()
        {
            Text = "Add Account";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = _ok;
            CancelButton = _cancel;

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 2 };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            layout.Controls.Add(new Label { Text = "Email:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, 0);
            layout.Controls.Add(_email, 1, 0);
            layout.Controls.Add(new Label { Text = "Password:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, 1);
            _password.UseSystemPasswordChar = true;
            layout.Controls.Add(_password, 1, 1);
            layout.Controls.Add(new Label { Text = "Server:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, 2);
            layout.Controls.Add(_server, 1, 2);

            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            btnPanel.Controls.Add(_ok);
            btnPanel.Controls.Add(_cancel);
            layout.Controls.Add(btnPanel, 1, 3);

            Controls.Add(layout);
            Width = 300;
            Height = 180;
        }
    }
}
