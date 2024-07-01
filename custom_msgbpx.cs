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
    public partial class custom_msgbpx : Form
    {
        public custom_msgbpx(string title, string message, MessageBoxIcon icon)
        {
            InitializeComponent();
            this.Text = title;
            this.message.Text = message;
            SetIcon(icon);
        }


        private void SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    pc_icon.Image = Properties.Resources.info;
                    bt_cancel.Visible = false;
                    bt_yes.Visible = false;
                    break;
                case MessageBoxIcon.Warning:
                    pc_icon.Image = Properties.Resources.warning;
                    ok.Visible = false;
                    break;
                case MessageBoxIcon.Error:
                    pc_icon.Image = Properties.Resources.error;
                    bt_cancel.Visible = false;
                    bt_yes.Visible = false;
                    break;
                default:
                    pc_icon.Image = null;
                    break;
            }
        }


        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bt_yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lb_name_Click(object sender, EventArgs e)
        {

        }

        private void custom_msgbpx_Load(object sender, EventArgs e)
        {
            
        }
    }
}
