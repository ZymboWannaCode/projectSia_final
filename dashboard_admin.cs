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
    public partial class dashboard_admin : Form
    {
        public dashboard_admin()
        {
            InitializeComponent();
        }

        private void bt_admin_Click(object sender, EventArgs e)
        {
            loadForm(new crud_admin());
        }
        private void loadForm(Form form)
        {
            content.Controls.Clear();
            form.TopLevel = false;
            content.Controls.Add(form);
            form.Height = 970;
            form.Width = 1425;
            form.BringToFront();
            form.Show();
        }

        private void bt_kelas_Click(object sender, EventArgs e)
        {
            loadForm(new crud_kelas());
        }

        private void bt_matkul_Click(object sender, EventArgs e)
        {
            loadForm(new crud_matkul());
        }

        private void bt_mhs_Click(object sender, EventArgs e)
        {
            loadForm(new crud_mhs());
        }

        private void bt_prodi_Click(object sender, EventArgs e)
        {
            loadForm(new crud_prodi());
        }
    }
}
