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
    public partial class form_mhs : Form
    {
        public form_mhs()
        {
            InitializeComponent();
        }

        private static string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        Regex regex = new Regex(pattern);
        private void form_mhs_Load(object sender, EventArgs e)
        {
            
        }
        private void cb_prodi_SelectedIndexChanged(object sender, EventArgs e)
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

        private void bt_back_Click(object sender, EventArgs e)
        {

        }

        private void txt_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_year.Text.Length >= 4 && !char.IsControl(e.KeyChar))
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

            if (txt_telp.Text.Length >= 13 && !char.IsControl(e.KeyChar))
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
        private bool formIsEmpty()
        {
            String kode, kelas, nik, nadep, nabel, tptlahir, tgllahir, gender, alamat, telp, email, thnmasuk;
            kode = txt_kode.Text;
            kelas = cb_kelas.Text;
            nik = txt_nik.Text;
            nadep = txt_nadep.Text;
            nabel = txt_nabel.Text;
            tptlahir = txt_tpt.Text;
            tgllahir = dp_tgl.Text;
            gender = cb_gender.Text;
            alamat = txt_alamat.Text;
            telp = txt_telp.Text;
            email = txt_email.Text;
            thnmasuk = txt_year.Text;
            return emptyCheck(kode, kelas, nik, nadep, nabel, tptlahir, tgllahir, gender, alamat, telp, email, thnmasuk);
        }

        private bool emptyCheck(params string[] text)
        {
            foreach (string s in text) {
                if (string.IsNullOrEmpty(s))
                {
                    // messagebox pesan error disini
                    return true;
                }
            }
            return false;
        }

        private void txt_nadep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
