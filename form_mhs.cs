using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSia_final
{
    public partial class form_mhs : Form
    {
        public form_mhs()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        private static string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        Regex regex = new Regex(pattern);

        private void form_mhs_Load(object sender, EventArgs e)
        {
            fillkelasCb();

            if (crud_kelas.isUpdate)
            {
                bt_insert.Visible = false;

                string[] data = crud_mhs.selected;

                txt_kode.Text = data[0];
                cb_kelas.Text = data[1];
                txt_nik.Text = data[2];
                txt_nadep.Text = data[3];
                txt_nabel.Text = data[4];
                txt_tpt.Text = data[5];
                dp_tgl.Text= data[6];
                cb_gender.Text = data[7];
                txt_alamat.Text = data[8];
                txt_telp.Text = data[9];
                txt_email.Text = data[10];
                txt_year.Text = data[11];
            }
            else
            {
                bt_update.Visible = false;
            }
            txt_kode.Enabled = false;
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

        private void bt_back_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
        }
        
        private void insertdata()
        {
            if (formIsEmpty()) { return; }
            if (!regex.IsMatch(txt_email.Text))
            {
                MessageBox.Show("Email format is wrong");
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO tb_mahasiswa VALUES ( @nim_mahasiswa, @kelas_mahasiswa, @nik_mahasiswa, @nama_depan_mahasiswa, @nama_belakang_mahasiswa," +
                    " @tptlahir_mahasiswa, @tgllahir_mahasiswa, @jenis_kelamin_mahasiswa, @alamat_mahasiswa, @telp_mahasiswa, @email_mahasiswa, @tahun, 1 )";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nim_mahasiswa", txt_kode.Text);
                cmd.Parameters.AddWithValue("@kelas_mahasiswa", Helper.GetElementByIndex(kelasList, cb_kelas.SelectedIndex));
                cmd.Parameters.AddWithValue("@nik_mahasiswa", txt_nik.Text);
                cmd.Parameters.AddWithValue("@nama_depan_mahasiswa", txt_nadep.Text);
                cmd.Parameters.AddWithValue("@nama_belakang_mahasiswa", txt_nabel.Text);
                cmd.Parameters.AddWithValue("@tptlahir_mahasiswa", txt_tpt.Text);
                cmd.Parameters.AddWithValue("@tgllahir_mahasiswa", dp_tgl.Value.ToString());
                cmd.Parameters.AddWithValue("@jenis_kelamin_mahasiswa", cb_gender.GetItemText(cb_gender.SelectedIndex));
                cmd.Parameters.AddWithValue("@alamat_mahasiswa", txt_alamat.Text);
                cmd.Parameters.AddWithValue("@telp_mahasiswa", txt_telp.Text);
                cmd.Parameters.AddWithValue("@email_mahasiswa", txt_email.Text);
                cmd.Parameters.AddWithValue("@tahun", txt_year.Text);

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Insert data berhasil!");
                }
                else
                {
                    MessageBox.Show("Insert data gagal!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return;
            }
        }

        private void updatedata()
        {
            if (formIsEmpty()) { return; }
            if (!regex.IsMatch(txt_email.Text))
            {
                MessageBox.Show("Email format is wrong");
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE tb_mahasiswa SET kelas_mahasiswa = @kelas_mahasiswa, " +
                    "nik_mahasiswa = @nik_mahasiswa, " +
                    "nama_depan_mahasiswa = @nama_depan_mahasiswa, " +
                    "nama_belakang_mahasiswa = @nama_belakang_mahasiswa, " +
                    "tptlahir_mahasiswa = @tptlahir_mahasiswa, " +
                    "tgllahir_mahasiswa = @tgllahir_mahasiswa, " +
                    "jenis_kelamin_mahasiswa = @jenis_kelamin_mahasiswa, " +
                    "alamat_mahasiswa = @alamat_mahasiswa, " +
                    "telp_mahasiswa = @telp_mahasiswa, " +
                    "email_mahasiswa = @email_mahasiswa, " +
                    "tahunmasuk_mahasiswa = @tahun WHERE nim_mahasiswa = @nim_mahasiswa";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nim_mahasiswa", txt_kode.Text);
                cmd.Parameters.AddWithValue("@kelas_mahasiswa", Helper.GetElementByIndex(kelasList, cb_kelas.SelectedIndex));
                cmd.Parameters.AddWithValue("@nik_mahasiswa", txt_nik.Text);
                cmd.Parameters.AddWithValue("@nama_depan_mahasiswa", txt_nadep.Text);
                cmd.Parameters.AddWithValue("@nama_belakang_mahasiswa", txt_nabel.Text);
                cmd.Parameters.AddWithValue("@tptlahir_mahasiswa", txt_tpt.Text);
                cmd.Parameters.AddWithValue("@tgllahir_mahasiswa", dp_tgl.Value.ToString());
                cmd.Parameters.AddWithValue("@jenis_kelamin_mahasiswa",cb_gender.GetItemText(cb_gender.SelectedIndex));
                cmd.Parameters.AddWithValue("@alamat_mahasiswa", txt_alamat.Text);
                cmd.Parameters.AddWithValue("@telp_mahasiswa", txt_telp.Text);
                cmd.Parameters.AddWithValue("@email_mahasiswa", txt_email.Text);
                cmd.Parameters.AddWithValue("@tahun", txt_year.Text);


                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Update data berhasil!");
                }
                else
                {
                    MessageBox.Show("Update data gagal!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex.Message);
                return;
            }
        }

        private LinkedList<string> kelasList = new LinkedList<string>();
        private void fillkelasCb()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT kode_kelas, nama_kelas FROM tb_kelas WHERE status_kelas=1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                while (reader.Read())
                {
                    cb_kelas.Items.Add(reader["nama_kelas"]);
                    kelasList.AddLast(reader["kode_kelas"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool formIsEmpty()
        {
            if (txt_kode.Text.Equals("") || txt_nik.Text.Equals("") || txt_nadep.Text.Equals("") ||
        txt_nabel.Text.Equals("") || txt_tpt.Text.Equals("") || dp_tgl.Value == null ||
        txt_alamat.Text.Equals("") || txt_telp.Text.Equals("") || txt_email.Text.Equals(""))
            {
                MessageBox.Show("Something's wrong", "All field must be filled!");
                return true;
            }
            return false;
        }

        private void clear()
        {
            txt_kode.Text = "";
            txt_nik.Text = "";
            txt_nadep.Text = "";
            txt_nabel.Text = "";
            txt_tpt.Text = "";
            txt_alamat.Text = "";
            txt_telp.Text = "";
            txt_email.Text = "";
        }
        private string generateID(String tipe, int id)
        {
            if (id < 10)
            {
                return tipe + "00" + id;
            }
            else if (id < 100)
            {
                return tipe + "0" + id;
            }
            else
            {
                return tipe + id;
            }
        }
        private int newestId(string namakelas)
        {
            int id = 0;
            string kodeprodi = "";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT nim_mahasiswa, kode_prodi FROM tb_mahasiswa INNER JOIN tb_kelas on kelas_mahasiswa = kode_kelas " +
                    "INNER JOIN tb_prodi on prodi_kelas = kode_prodi WHERE nama_kelas = '" + namakelas + "'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["nim_mahasiswa"].ToString().Substring(4));
                    kodeprodi = reader["kode_prodi"].ToString().Substring(2);
                }
                reader.Close();
                connection.Close();
                txt_kode.Text = generateID(kodeprodi, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during load the data : " + ex, "Error");
                return -1;
            }
            return id + 1;
        }

        private void cb_kelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            newestId(cb_kelas.SelectedItem.ToString());
        }
    }
}
