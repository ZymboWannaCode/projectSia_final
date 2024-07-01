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

namespace projectSia_final
{
    public partial class crud_mhs : Form
    {
        public crud_mhs()
        {
            InitializeComponent();
        }

        private void crud_mhs_Load(object sender, EventArgs e)
        {
            tbview.MultiSelect = false;
            load_data();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        public static bool isUpdate = false;
        public static string[] selected = new string[12];
        private void bt_add_Click(object sender, EventArgs e)
        {
            form_mhs cForm = new form_mhs();
            Helper.showForm(this, cForm);
            load_data();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private void tbview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < selected.Length; i++) 
            {
                selected[i] = tbview.SelectedCells[i].Value.ToString();
            }

            DialogResult act = dataAction.Show();

            if (act == DialogResult.Yes)
            {
                isUpdate = true;
                form_mhs cForm = new form_mhs();
                Helper.showForm(this, cForm);
                isUpdate = false;
            }
            else if (act == DialogResult.No)
            {
                DialogResult del = messageBox_cus.Show("Confirm", "Are you sure to delete this data?", MessageBoxIcon.Warning);

                switch (del)
                {
                    case DialogResult.Yes:
                        delete();
                        break;
                }
            }
            load_data();
        }
        private void load_data()
        {
            tbview.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT nim_mahasiswa, kls.nama_kelas, nik_mahasiswa, nama_depan_mahasiswa, " +
                    "nama_belakang_mahasiswa, tptlahir_mahasiswa, tgllahir_mahasiswa, jenis_kelamin_mahasiswa, " +
                    "alamat_mahasiswa, telp_mahasiswa, email_mahasiswa, tahunmasuk_mahasiswa " +
                    "FROM tb_mahasiswa mhs inner join tb_kelas kls " +
                    "on mhs.kelas_mahasiswa = kls.kode_kelas " +
                    "WHERE status_mahasiswa = 1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["nim_mahasiswa"], reader["nama_kelas"], reader["nik_mahasiswa"], reader["nama_depan_mahasiswa"],
                        reader["nama_belakang_mahasiswa"], reader["tptlahir_mahasiswa"], reader["tgllahir_mahasiswa"], reader["jenis_kelamin_mahasiswa"],
                        reader["alamat_mahasiswa"], reader["telp_mahasiswa"], reader["email_mahasiswa"], reader["tahunmasuk_mahasiswa"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void search()
        {
            tbview.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT nim_mahasiswa, kls.nama_kelas, nik_mahasiswa, nama_depan_mahasiswa, " +
                    "nama_belakang_mahasiswa, tptlahir_mahasiswa, tgllahir_mahasiswa, jenis_kelamin_mahasiswa, " +
                    "alamat_mahasiswa, telp_mahasiswa, email_mahasiswa, tahunmasuk_mahasiswa " +
                    "FROM tb_mahasiswa mhs inner join tb_kelas kls " +
                    "on mhs.kelas_mahasiswa = kls.kode_kelas " +
                    "WHERE status_mahasiswa = 1 AND nama_depan_mahasiswa LIKE '%" + txt_search.Text + "%' OR nama_belakang_mahasiswa LIKE '%" + txt_search.Text + "%'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["nim_mahasiswa"], reader["nama_kelas"], reader["nik_mahasiswa"], reader["nama_depan_mahasiswa"],
                        reader["nama_belakang_mahasiswa"], reader["tptlahir_mahasiswa"], reader["tgllahir_mahasiswa"], reader["jenis_kelamin_mahasiswa"],
                        reader["alamat_mahasiswa"], reader["telp_mahasiswa"], reader["email_mahasiswa"], reader["tahunmasuk_mahasiswa"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void delete()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "UPDATE tb_mahasiswa SET status_mahasiswa=0 WHERE nim_mahasiswa='" + selected[0] + "'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                int result = Convert.ToInt32(myCmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    MessageBox.Show("Delete data berhasil!");
                }
                else
                {
                    MessageBox.Show("Delete data gagal!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
