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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace projectSia_final
{
    public partial class crud_prodi : Form
    {
        public crud_prodi()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        public static bool isUpdate = false;
        public static string[] selected = new string[4];
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
                form_prodi cForm = new form_prodi();
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
            loaddata();
        }

        private void crud_prodi_Load(object sender, EventArgs e)
        {
            tbview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loaddata();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            add_click();
            loaddata();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private void loaddata()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT * FROM tb_prodi WHERE status_prodi=1";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_prodi"], reader["nama_prodi"], reader["telp_prodi"], reader["email_prodi"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void add_click()
        {
            form_prodi cForm = new form_prodi();
            Helper.showForm(this, cForm);
            loaddata();
        }

        private void search() 
        {
            tbview.Rows.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT * FROM tb_prodi WHERE nama_prodi LIKE '%" + txt_search.Text + "%'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    tbview.Rows.Add(reader["kode_prodi"], reader["nama_prodi"], reader["telp_prodi"], reader["email_prodi"]);
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
                myCmd.CommandText = "UPDATE tb_prodi SET status_prodi=0 WHERE kode_prodi='" + selected[0] + "'";
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
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
