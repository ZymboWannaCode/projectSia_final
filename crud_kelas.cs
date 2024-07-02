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
    public partial class crud_kelas : Form
    {
        public crud_kelas()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        public static bool isUpdate = false;
        private void bt_add_Click(object sender, EventArgs e)
        {
            form_kelas cForm = new form_kelas();
            Helper.showForm(this, cForm);
            load_data();
        }

        private void crud_kelas_Load(object sender, EventArgs e)
        {
            tbview.MultiSelect = false;
            load_data();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            searchdata();
        }
        public static string[] selected = new string[3];
        private void tbview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected[0] = tbview.SelectedCells[0].Value.ToString();
            selected[1] = tbview.SelectedCells[1].Value.ToString();
            selected[2] = tbview.SelectedCells[2].Value.ToString();
            
            DialogResult act = dataAction.Show();

            if (act == DialogResult.Yes)
            {
                isUpdate = true;
                form_kelas cForm = new form_kelas();
                Helper.showForm(this, cForm);
                isUpdate = false;
            }
            else if (act == DialogResult.No)
            {
                DialogResult del = messageBox_cus.Show("Confirm", "Are you sure to delete this data?", MessageBoxIcon.Warning);

                switch (del)
                {
                    case DialogResult.Yes:
                        deletedata();
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
                myCmd.CommandText = "SELECT kode_kelas, nama_prodi, nama_kelas FROM tb_kelas INNER JOIN tb_prodi ON prodi_kelas = kode_prodi WHERE status_kelas!=0";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_kelas"],
                        reader["nama_prodi"],
                        reader["nama_kelas"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                messageBox_cus.Show("Error", ex.ToString(), MessageBoxIcon.Error);
            }
        }

        private void searchdata()
        {
            tbview.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT kode_kelas, nama_prodi, nama_kelas FROM tb_kelas INNER JOIN tb_prodi ON prodi_kelas = kode_prodi WHERE status_kelas!=0 AND nama_kelas LIKE '%" + txt_search.Text +"%'";
                myCmd.CommandType = CommandType.Text;
                

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_kelas"],
                        reader["nama_prodi"],
                        reader["nama_kelas"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                messageBox_cus.Show("Error", ex.ToString(), MessageBoxIcon.Error);
            }
        }

        private void deletedata()
        {
            string kode = tbview.SelectedCells[0].Value.ToString();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "UPDATE tb_kelas SET status_kelas=0 WHERE kode_kelas='" + kode + "'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                int res = Convert.ToInt32(myCmd.ExecuteNonQuery());
                if (res != 0) 
                {
                    messageBox_cus.Show("Success", "Data was successfully deleted!", MessageBoxIcon.Information);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            load_data();
        }
    }
}
