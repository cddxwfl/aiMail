using System.Windows.Forms;
using AiMailClient;

namespace AiMailWin
{
    public class SendMailForm : Form
    {
        private readonly TextBox _to = new();
        private readonly TextBox _subject = new();
        private readonly TextBox _body = new() { Multiline = true, Height = 200 };
        private readonly Button _ok = new() { Text = "Send", DialogResult = DialogResult.OK };
        private readonly Button _cancel = new() { Text = "Cancel", DialogResult = DialogResult.Cancel };

        public string ToAddress => _to.Text;
        public string SubjectText => _subject.Text;
        public string BodyText => _body.Text;

        public SendMailForm()
        {
            Text = "Compose";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = _ok;
            CancelButton = _cancel;

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 2 };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));

            layout.Controls.Add(new Label { Text = "To:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, 0);
            layout.Controls.Add(_to, 1, 0);
            layout.Controls.Add(new Label { Text = "Subject:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, 1);
            layout.Controls.Add(_subject, 1, 1);
            layout.Controls.Add(_body, 0, 2);
            layout.SetColumnSpan(_body, 2);

            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            btnPanel.Controls.Add(_ok);
            btnPanel.Controls.Add(_cancel);
            layout.Controls.Add(btnPanel, 1, 3);

            Controls.Add(layout);
            Width = 400;
            Height = 300;
        }
    }
}
