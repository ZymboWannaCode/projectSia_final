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
    public partial class crud_profcourse : Form
    {
        public crud_profcourse()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";

        private void crud_profcourse_Load(object sender, EventArgs e)
        {
            tbview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbview.MultiSelect = false;
            load_data();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {

        }

        private void bt_search_Click(object sender, EventArgs e)
        {

        }

        private void tbview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchdata()
        {
            tbview.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "select kode_pengajar_matkul, " +
                    "CONCAT(nama_depan_profesor, ' ', nama_belakang_profesor) as nama_profesor, " +
                    "nama_matakuliah, nama_ruang, tanggal_mulai, tanggal_berakhir " +
                    "from tb_pengajarmatkul join tb_profesor on profesor_pengajar_matkul = nidn_profesor " +
                    "join tb_matakuliah on matakuliah_pengajar_matkul = kode_matakuliah " +
                    "join tb_ruang on ruang_pengajar_matkul = kode_ruang where status = 1 AND nama_belakang_profesor LIKE '%" + txt_search.Text + "%'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_pengajar_matkul"], 
                        reader["nama_profesor"], 
                        reader["nama_matakuliah"],
                        reader["nama_ruang"], 
                        reader["tanggal_mulai"], 
                        reader["tanggal_berakhir"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void load_data()
        {
            tbview.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "select kode_pengajar_matkul, " +
                    "CONCAT(nama_depan_profesor, ' ', nama_belakang_profesor) as nama_profesor, " +
                    "nama_matakuliah, nama_ruang, tanggal_mulai, tanggal_berakhir " +
                    "from tb_pengajarmatkul join tb_profesor on profesor_pengajar_matkul = nidn_profesor " +
                    "join tb_matakuliah on matakuliah_pengajar_matkul = kode_matakuliah " +
                    "join tb_ruang on ruang_pengajar_matkul = kode_ruang where status = 1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_pengajar_matkul"], reader["nama_profesor"], reader["nama_matakuliah"],
                        reader["nama_ruang"], reader["tanggal_mulai"], reader["tanggal_berakhir"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
