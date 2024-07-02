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
    public partial class crud_matkul : Form
    {
        public crud_matkul()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        public static bool isUpdate = false;
        public static string[] selected = new string[3];
        private void crud_matkul_Load(object sender, EventArgs e)
        {
            tbview.MultiSelect = false;
            load_data();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            form_matkul cForm = new form_matkul();
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
                form_matkul cForm = new form_matkul();
                Helper.showForm(this, cForm);
                load_data();
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
        private void delete() 
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "UPDATE tb_matakuliah SET status_matakuliah=0 WHERE kode_matakuliah='" + selected[0] + "'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                int result = Convert.ToInt32(myCmd.ExecuteNonQuery());
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
                myCmd.CommandText = "SELECT * FROM tb_matakuliah WHERE nama_matakuliah LIKE '%" + txt_search.Text + "%'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_matakuliah"], reader["nama_matakuliah"], reader["sks_matakuliah"]);
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
                myCmd.CommandText = "SELECT * FROM tb_matakuliah WHERE status_matakuliah!=0";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_matakuliah"],
                        reader["nama_matakuliah"],
                        reader["sks_matakuliah"]);
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
