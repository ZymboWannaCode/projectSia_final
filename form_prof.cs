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
    public partial class form_prof : Form
    {
        public form_prof()
        {
            InitializeComponent();
        }
        private static string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        Regex regex = new Regex(pattern);

        private void form_prof_Load(object sender, EventArgs e)
        {

        }

        private void bt_back_Click(object sender, EventArgs e)
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

        private void txt_kode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_kode.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_nik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_nik.Text.Length >= 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_nadep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_telp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_telp.Text.Length >= 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool formIsEmpty()
        {
            String kode, kelas, nik, nadep, nabel, tptlahir, tgllahir, gender, alamat, telp, email, password, spesialis;
            kode = txt_kode.Text;
            kelas = cb_prodi.Text;
            nik = txt_nik.Text;
            nadep = txt_nadep.Text;
            nabel = txt_nabel.Text;
            tptlahir = txt_tpt.Text;
            tgllahir = dp_tgl.Text;
            gender = cb_gender.Text;
            alamat = txt_alamat.Text;
            telp = txt_telp.Text;
            email = txt_email.Text;
            password = txt_pass.Text;
            spesialis = txt_special.Text;
            return emptyCheck(kode, kelas, nik, nadep, nabel, tptlahir, tgllahir, gender, alamat, telp, email, password, spesialis);
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
