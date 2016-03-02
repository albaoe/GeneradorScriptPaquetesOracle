using System;
using System.Windows.Forms;

namespace GeneradorScriptPaquetesOracle
{
    public partial class RemoveConnectionForm : Form
    {
        public RemoveConnectionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int index = Properties.ConnectionStrings.Default.Alias.IndexOf(listBox1.SelectedItem.ToString());
            Properties.ConnectionStrings.Default.ConnectionString.RemoveAt(index);
            Properties.ConnectionStrings.Default.Owners.RemoveAt(index);
            Properties.ConnectionStrings.Default.Alias.RemoveAt(index);            
            Properties.ConnectionStrings.Default.Save();
            fillList();
        }

        public void fillList()
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            if (Properties.ConnectionStrings.Default.Alias != null)
            {
                foreach (string alias in Properties.ConnectionStrings.Default.Alias)
                {
                    listBox1.Items.Add(alias);
                }
            }
            listBox1.EndUpdate();
            listBox1.Refresh();
        }
    }
}
