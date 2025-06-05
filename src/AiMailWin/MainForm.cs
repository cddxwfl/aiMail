using System;
using System.Windows.Forms;
using AiMailClient;

// ReSharper disable once CheckNamespace

namespace AiMailWin
{
    public class MainForm : Form
    {
        private readonly SplitContainer _split = new() { Dock = DockStyle.Fill };
        private readonly TreeView _accounts = new() { Dock = DockStyle.Fill };
        private readonly SplitContainer _splitMessages = new() { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal };
        private readonly ListView _messages = new() { Dock = DockStyle.Fill, View = View.List };
        private readonly TextBox _viewer = new() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true };
        private readonly ToolStrip _toolbar = new() { Dock = DockStyle.Top };
        private readonly ToolStripButton _refreshButton = new("Refresh");
        private readonly ToolStripButton _addButton = new("Add Account");
        private readonly ToolStripButton _sendButton = new("Send");

        private readonly MailClient _client = new();
        private readonly MailAccount _defaultAccount = new("user@example.com", "password", "imap.example.com");
        private MailAccount _currentAccount;

        public MainForm()
        {
            Text = "aiMail";
            Width = 800;
            Height = 600;

            Controls.Add(_split);
            Controls.Add(_toolbar);

            _split.Panel1.Controls.Add(_accounts);
            _split.Panel2.Controls.Add(_splitMessages);
            _splitMessages.Panel1.Controls.Add(_messages);
            _splitMessages.Panel2.Controls.Add(_viewer);

            _toolbar.Items.AddRange(new ToolStripItem[] { _addButton, _sendButton, _refreshButton });

            _client.AddAccount(_defaultAccount);
            var node = _accounts.Nodes.Add(_defaultAccount.Email);
            node.Tag = _defaultAccount;
            _currentAccount = _defaultAccount;

            _refreshButton.Click += (s, e) => LoadMessages();
            _addButton.Click += (s, e) => AddAccount();
            _sendButton.Click += (s, e) => ComposeMail();
            _messages.SelectedIndexChanged += (s, e) => ShowMessage();
            _accounts.AfterSelect += (s, e) =>
            {
                if (e.Node?.Tag is MailAccount acct)
                {
                    _currentAccount = acct;
                    LoadMessages();
                }
            };

            LoadMessages();
        }

        private void LoadMessages()
        {
            if (_currentAccount == null)
                return;

            _messages.Items.Clear();
            var filter = new AiFilter();
            var messages = _client.ReceiveMessages(_currentAccount);
            foreach (var msg in filter.Filter(messages, "important"))
            {
                var item = _messages.Items.Add(msg.Subject);
                item.Tag = msg;
            }
        }

        private void AddAccount()
        {
            using var dlg = new AddAccountForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var account = new MailAccount(dlg.Email, dlg.Password, dlg.Server);
                _client.AddAccount(account);
                var node = _accounts.Nodes.Add(account.Email);
                node.Tag = account;
                _currentAccount = account;
                LoadMessages();
            }
        }

        private void ShowMessage()
        {
            if (_messages.SelectedItems.Count == 0)
            {
                _viewer.Clear();
                return;
            }

            if (_messages.SelectedItems[0].Tag is MailMessage msg)
            {
                var analyzer = new DeepseekAnalyzer();
                _viewer.Text = msg.Body + "\n\n" + analyzer.Analyze(msg);
            }
        }

        private void ComposeMail()
        {
            if (_currentAccount == null)
                return;

            using var dlg = new SendMailForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _client.SendMessage(_currentAccount, dlg.ToAddress, dlg.SubjectText, dlg.BodyText);
            }
        }
    }
}
