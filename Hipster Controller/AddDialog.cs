using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ionautics
{
    public partial class AddDialog : Form
    {
        public string TabNameText { get; set; }

        public AddDialog()
        {
            InitializeComponent();
        }

        private void AddDialog_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TabName_TextChanged(object sender, EventArgs e)
        {
            TabNameText = TabName.Text;
        }
    }
}
