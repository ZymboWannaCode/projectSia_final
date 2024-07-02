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
    public partial class crud_admin : Form
    {
        public crud_admin()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        private void bt_add_Click(object sender, EventArgs e)
        {
            form_admin adminForm = new form_admin();
            Helper.showForm(this, adminForm);
            load_data();
        }
        private void bt_search_Click(object sender, EventArgs e)
        {
            search();
        }
        public static bool isUpdate = false;
        public static string[] selected = new string[7];
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
                form_admin adminForm = new form_admin();
                Helper.showForm(this, adminForm);
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
        private void crud_admin_Load(object sender, EventArgs e)
        {
            tbview.MultiSelect = false;
            load_data();
        }
        private void load_data()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT kode_admin, nama_prodi, nama_depan_admin, nama_belakang_admin, gender_admin, telp_admin, email_admin " +
                    "FROM tb_admin " +
                    "INNER JOIN tb_prodi ON prodi_admin = kode_prodi " +
                    "WHERE status_admin=1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_admin"], reader["nama_prodi"], reader["nama_depan_admin"], reader["nama_belakang_admin"], reader["gender_admin"], reader["telp_admin"], reader["email_admin"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                messageBox_cus.Show("Error", "Error : " + ex, MessageBoxIcon.Error);
                return;
            }
        }
        private void search()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT kode_admin, nama_prodi, nama_depan_admin, nama_belakang_admin, gender_admin, telp_admin, email_admin " +
                    "FROM tb_admin " +
                    "INNER JOIN tb_prodi ON prodi_admin = kode_prodi " +
                    "FROM tb_admin " +
                    "JOIN tb_prodi ON prodi_admin = kode_prodi " +
                    "WHERE (nama_depan_admin LIKE '%" + txt_search.Text + "%' OR nama_belakang_admin LIKE '%" + txt_search.Text + "%') AND status_admin = 1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_admin"], reader["nama_prodi"], reader["nama_depan_admin"], reader["nama_belakang_admin"], reader["telp_admin"], reader["email_admin"], reader["password_admin"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                messageBox_cus.Show("Error", "Error : " + ex, MessageBoxIcon.Error);
                return;
            }
        }
        private void delete()
        {
            string kode;

            kode = tbview.SelectedCells[0].Value.ToString();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE tb_admin SET status_admin=0 WHERE kode_admin='" + kode + "'";
                cmd.CommandType = CommandType.Text;

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();

                if (result != 0)
                {
                    messageBox_cus.Show("Success", "Successfuly delete the data", MessageBoxIcon.Information);
                }
                else
                {
                    messageBox_cus.Show("Error", "Delete data failed!", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                messageBox_cus.Show("Error", "Error : " + ex, MessageBoxIcon.Error);
                return;
            }
        }
        
    }
}
