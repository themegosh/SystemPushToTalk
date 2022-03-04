using System;
using System.Windows.Forms;
using SystemPushToTalk.Services;

namespace SystemPushToTalk.Forms
{
    public partial class FormSetKeyBinding : Form
    {
        public EventArgs NewKeyBinding { get; set; }

        public FormSetKeyBinding(EventArgs oldEventArgs)
        {
            InitializeComponent();

            NewKeyBinding = oldEventArgs;

            HookManager.MouseClick += HandleMouseDown;
            HookManager.KeyDown += HandleKeyDown;
        }

        private void FormSetKeyBinding_FormClosing(object sender, FormClosingEventArgs e)
        {
            HookManager.MouseClick -= HandleMouseDown;
            HookManager.KeyDown -= HandleKeyDown;
        }

        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            NewKeyBinding = e;
            DialogResult = DialogResult.OK;
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            NewKeyBinding = e;
            DialogResult = DialogResult.OK;
        }
    }
}