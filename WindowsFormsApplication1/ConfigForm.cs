using System;
using System.Windows.Forms;

namespace GeneradorScriptPaquetesOracle
{
    public partial class ConfigForm : Form
    {
        AddConnectionForm add = new AddConnectionForm();
        RemoveConnectionForm remove = new RemoveConnectionForm();
        private MainForm main = null;

        public ConfigForm(Form callingForm)
        {
            main = callingForm as MainForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (add.IsDisposed)
            {
                add = new AddConnectionForm();
            }
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (remove.IsDisposed)
            {
                remove = new RemoveConnectionForm();
            }
            remove.Show();
            remove.fillList();
        }

        private void ConfigForm_FormClosing(object sender, EventArgs e)
        {
            main.fillEnvironments();
        }
    }
}
