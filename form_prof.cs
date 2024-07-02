using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projectSia_final
{
    public partial class form_prof : Form
    {
        public form_prof()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        private const string dateFormat = "dd-MM-yyyy";

        private void form_prof_Load(object sender, EventArgs e)
        {
            if (crud_prodi.isUpdate)
            {
                bt_insert.Visible = false;

                string[] data = crud_prodi.selected;

                txt_kode.Text = data[0];
                cb_prodi.Text = data[1];
                txt_nik.Text = data[2];
                txt_nadep.Text = data[3];
                txt_nabel.Text = data[4];
                txt_tpt.Text = data[5];
                dp_tgl.Value = DateTime.Parse(data[6]);
                cb_gender.Text = data[7];
                txt_alamat.Text = data[8];
                txt_telp.Text = data[9];
                txt_email.Text = data[10]; 
                txt_special.Text = data[11];
            }
            else
            {
                bt_update.Visible = false;
            }
            txt_kode.Enabled = false;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            DialogResult del = messageBox_cus.Show("Confirm", "Are you sure to update this data?", MessageBoxIcon.Warning);

            switch (del)
            {
                case DialogResult.Yes:
                    updatedata();
                    break;
            }
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            insertdata();
            clear();
        }

        private void updatedata()
        {
            if (!validateAllFields())
            {
                return;
            }
            //// TO BE FIXED
            ///

            /*try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmdProf = new SqlCommand();
                cmdProf.Connection = connection;
                cmdProf.CommandText = "UPDATE tb_profesor SET prodi_profesor = '" + Helper.GetElementByIndex(prodiList, cb_prodi.SelectedIndex) + "', nik_profesor = '" + txt_nik.Text + "', nama_depan_profesor = '" + txt_nadep.Text + "', nama_belakang_profesor = '" + txt_nabel.Text + "'," +
                                                    " tptlahir_profesor = '" + txt_tpt.Text + "', tgllahir_profesor = '" + dp_tgl.Text + "', alamat_profesor = '" + txt_alamat.Text + "', telp_profesor = '" + txt_telp.Text + "', email_profesor = '" + txt_email.Text + "', jafung_profesor = '" + txt_jafung.Text + "', bidangkeahlian_profesor = '" + txt_special.Text + "'," +
                                                    " password_profesor = '" + txt_pass.Text + "' WHERE nidn_profesor = '" + txt_kode.Text + "'";
                cmdProf.CommandType = CommandType.Text;

                connection.Open();
                int result = Convert.ToInt32(cmdProf.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Professor data successfully updated!", "Information");
                }
                else
                {
                    MessageBox.Show("Professor data update failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex.Message);
                return;
            }*/
        }

        private void insertdata()
        {

            if (!validateAllFields())
            {
                return;
            }
            //// TO BE FIXED
            ///

           /* try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmdProf = new SqlCommand();
                cmdProf.Connection = connection;
                cmdProf.CommandText = "INSERT INTO tb_profesor VALUES ( '" + txt_kode.Text + "','" + Helper.GetElementByIndex(prodiList, cb_prodi.SelectedIndex) + "','" + txt_nik.Text + "','" + txt_nadep.Text + "','" + txt_nabel.Text + "'," +
                    "'" + txt_tpt.Text + "','" + dp_tgl.Text + "','" + txt_alamat.Text + "','" + txt_telp.Text + "','" + txt_email.Text + "','" + txt_jafung.Text + "','" + txt_special.Text + "'," +
                    "'" + txt_pass.Text + "', 1 )";
                cmdProf.CommandType = CommandType.Text;

                connection.Open();
                int result = Convert.ToInt32(cmdProf.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Professor data successfully inserted!", "Information");
                }
                else
                {
                    MessageBox.Show("Professor data insert failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return;
            }*/
        }

        private LinkedList<string> prodiList = new LinkedList<string>();
        private void fillprodiCb()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT kode_prodi, nama_prodi FROM tb_prodi WHERE status_prodi=1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                while (reader.Read())
                {
                    cb_prodi.Items.Add(reader["nama_prodi"]);
                    prodiList.AddLast(reader["kode_prodi"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void clear()
        {
            txt_kode.Text = "";

            if (cb_prodi.Items.Count > 0)
            {
                cb_prodi.SelectedIndex = 0; // Ensure there is at least one item before setting the index
            }
            txt_nik.Text = "";
            txt_nadep.Text = "";
            txt_nabel.Text = "";
            txt_tpt.Text = "";
            dp_tgl.Value = DateTime.Now;
            txt_alamat.Text = "";
            txt_telp.Text = "";
            txt_email.Text = "";
            txt_special.Text = "";
        }

        public bool validateNIDN(string nidn)
        {
            return nidn.Length == 10 && nidn.All(char.IsDigit);
        }

        public bool validateNIK(string nik)
        {
            return nik.Length == 16 && nik.All(char.IsDigit);
        }

        public bool validateNama(string nama)
        {
            return nama.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public bool validateTelp(string telp)
        {
            return telp.Length >= 13 && telp.All(char.IsDigit);
        }

        /*  public bool validateEmail(string email)
          {
              return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w.-]+@[\w.-]+\.[a-zA-Z]{2,}$");
          }*/

        public bool validateTglLahir(DateTime? tglLahir)
        {
            return tglLahir.HasValue;
        }

        public bool validateNotEmpty(params string[] fields)
        {
            foreach (var field in fields)
            {
                if (string.IsNullOrEmpty(field))
                {
                    return false;
                }
            }
            return true;
        }

        public bool validateAllFields()
        {
            string nidn = txt_kode.Text;
            string namaProdi = cb_prodi.SelectedValue?.ToString();
            string nik = txt_nik.Text;
            string namaDepan = txt_nadep.Text;
            string namaBelakang = txt_nabel.Text;
            string tptLahir = txt_tpt.Text;
            DateTime? tglLahir = dp_tgl.Value;
            string alamat = txt_alamat.Text;
            string telp = txt_telp.Text;
            string email = txt_email.Text;
            string bidKeahlian = txt_special.Text;

            if (!validateNIDN(nidn))
            {
                MessageBox.Show("NIDN must contains 10 digits and must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!validateNIK(nik))
            {
                MessageBox.Show("NIK must contains 16 digits and must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!validateNama(namaDepan) || !validateNama(namaBelakang))
            {
                MessageBox.Show("First name and last name must contain only letters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!validateTelp(telp))
            {
                MessageBox.Show("Phone number must be a maximum of 13 digits and must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /*if (!validateEmail(email))
            {
                MessageBox.Show("Invalid email format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/

            if (!validateTglLahir(tglLahir))
            {
                MessageBox.Show("Please select a date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!validateNotEmpty(nik, namaDepan, namaBelakang, tptLahir, alamat, telp, email, bidKeahlian))
            {
                MessageBox.Show("All fields must be filled out before inserting data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
