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

namespace projectSia_final
{
    public partial class from_profcourse : Form
    {
        public from_profcourse()
        {
            InitializeComponent();
        }
        private static string pattern = @"(\d{4}/\d{4})";

        Regex regex = new Regex(pattern);
        private void from_profcourse_Load(object sender, EventArgs e)
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
            if (!regex.IsMatch(txt_year.Text))
            {
                return;
            }
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            if (!regex.IsMatch(txt_year.Text))
            {
                return;
            }
        }
        private bool formIsEmpty()
        {
            String kode, prof, matkul, sem, thn;
            kode = txt_kode.Text;
            prof = cb_prof.Text;
            matkul = cb_course.Text;
            sem = cb_season.Text;
            thn = txt_year.Text;
            return emptyCheck(kode, prof, matkul, thn);
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
