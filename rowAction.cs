using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSia_final
{
    public partial class rowAction : Form
    {
        public rowAction()
        {
            InitializeComponent();
        }

        private void bt_del_Click(object sender, EventArgs e)
        {                 
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
