using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projectSia_final
{
    public partial class form_prodi : Form
    {
        public form_prodi()
        {
            InitializeComponent();
        }
        private static string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        Regex regex = new Regex(pattern);

        private void form_prodi_Load(object sender, EventArgs e)
        {

        }

        private void bt_clear_Click(object sender, EventArgs e)
        {

        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            if (!regex.IsMatch(txt_email.Text))
            {
                return;
            }
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            if (!regex.IsMatch(txt_email.Text))
            {
                return;
            }
        }

        private void txt_telp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_telp.Text.Length >= 13 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool formIsEmpty()
        {
            String kode, nama, telp, email;
            kode = txt_kode.Text;
            nama = txt_nama.Text;
            telp = txt_telp.Text;
            email = txt_email.Text;
            return emptyCheck(kode, nama, telp, email);
        }

        private bool emptyCheck(params string[] text)
        {
            foreach (string s in text)
            {
                if (string.IsNullOrEmpty(s))
                {
                    // messagebox pesan error disini
                    return true;
                }
            }
            return false;
        }
    }
}
