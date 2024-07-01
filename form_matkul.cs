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
    public partial class form_matkul : Form
    {
        public form_matkul()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";

        private void form_matkul_Load(object sender, EventArgs e)
        {
            if (crud_matkul.isUpdate)
            {
                bt_insert.Visible = false;

                string[] data = crud_matkul.selected;

                txt_kode.Text = data[0];
                txt_nama.Text = data[1];
                txt_sks.Text = data[2];
            }
            else
            {
                txt_kode.Text = generateID("MK", newestID());
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
            updatedata();
            clear();
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
            if (string.IsNullOrWhiteSpace(txt_kode.Text) ||
                string.IsNullOrWhiteSpace(txt_nama.Text) ||
                string.IsNullOrWhiteSpace(txt_sks.Text))
            {
                MessageBox.Show("All fields must be filled out before inserting data!", "Warning", MessageBoxButtons.OK);
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_add_matakuliah";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kode_matakuliah", txt_kode.Text);
                cmd.Parameters.AddWithValue("@nama_matakuliah", txt_nama.Text);
                cmd.Parameters.AddWithValue("@sks_matakuliah", txt_sks.Text);
                cmd.Parameters.AddWithValue("@status_matakuliah", "1");

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Data insertion successful!");
                }
                else
                {
                    MessageBox.Show("Data insertion failed!");
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
            string kode, nama, sks;

            kode = crud_matkul.selected[0];
            nama = txt_nama.Text;
            sks = txt_sks.Text;

            if (string.IsNullOrWhiteSpace(txt_kode.Text) ||
                string.IsNullOrWhiteSpace(txt_nama.Text) ||
                string.IsNullOrWhiteSpace(txt_sks.Text))
            {
                MessageBox.Show("All fields must be filled out before inserting data!", "Warning", MessageBoxButtons.OK);
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_upd_matakuliah";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kode_matakuliah", kode);
                cmd.Parameters.AddWithValue("@nama_matakuliah", nama);
                cmd.Parameters.AddWithValue("@sks_matakuliah", sks);
                cmd.Parameters.AddWithValue("@status_matakuliah", "1");

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    MessageBox.Show("Data UPDATE successful!");
                }
                else
                {
                    MessageBox.Show("Data insertion failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return;
            }
        }

        private String generateID(String tipe, int id)
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

        private int newestID()
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM tb_matakuliah", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string kodeMatakuliah = reader["kode_matakuliah"].ToString();
                                int currentId = int.Parse(kodeMatakuliah.Substring(2));
                                if (currentId > id)
                                {
                                    id = currentId;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            return id + 1;
        }

        private void clear()
        {
            txt_kode.Text = txt_kode.Text = generateID("MK", newestID());
            txt_nama.Text = "";
            txt_sks.Text = "";
        }
    }
}
