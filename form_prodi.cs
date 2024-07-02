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
    public partial class form_prodi : Form
    {
        public form_prodi()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        private static string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        Regex regex = new Regex(pattern);

        private void form_prodi_Load(object sender, EventArgs e)
        {
            if (crud_prodi.isUpdate)
            {
                bt_insert.Visible = false;

                string[] data = crud_prodi.selected;

                txt_kode.Text = data[0];
                txt_nama.Text = data[1];
                txt_telp.Text = data[2];
                txt_email.Text = data[3];
            }
            else
            {
                txt_kode.Text = generateID("PD", newestId());
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

        private void updatedata()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_upd_prodi";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kode_prodi", txt_kode.Text);
                cmd.Parameters.AddWithValue("@nama_prodi", txt_nama.Text);
                cmd.Parameters.AddWithValue("@telp_prodi", txt_telp.Text);
                cmd.Parameters.AddWithValue("@email_prodi", txt_email.Text);
                cmd.Parameters.AddWithValue("@status_prodi", "1");

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

        private void insertdata()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_add_prodi";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kode_prodi", txt_kode.Text);
                cmd.Parameters.AddWithValue("@nama_prodi", txt_nama.Text);
                cmd.Parameters.AddWithValue("@telp_prodi", txt_telp.Text);
                cmd.Parameters.AddWithValue("@email_prodi", txt_email.Text);
                cmd.Parameters.AddWithValue("@status_prodi", "1");

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
        private void clear()
        {
            txt_kode.Text = "";
            txt_nama.Text = "";
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
        private int newestId()
        {
            int id = 0;
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "SELECT * FROM tb_prodi";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["kode_prodi"].ToString().Substring(2));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during load the data : " + ex, "Error");
                return -1;
            }
            return id + 1;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
        }
    }
}
