using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace projectSia_final
{
    public partial class form_kelas : Form
    {
        public form_kelas()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";

        private void form_kelas_Load(object sender, EventArgs e)
        {
            fillCb();

            if (crud_kelas.isUpdate)
            {
                bt_insert.Visible = false;

                string[] data = crud_kelas.selected;

                txt_kode.Text = data[0];
                cb_prodi.Text = data[1];
                txt_nama.Text = data[2];
                txt_ruang.Text = data[3];
                txt_lokasi.Text = data[4];
            }
            else
            {
                txt_kode.Text = generateID("KL", newestID());
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
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            insertdata();
        }
        private void updatedata()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_upd_kelas";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kode_kelas", txt_kode.Text);
                cmd.Parameters.AddWithValue("@prodi_kelas", Helper.GetElementByIndex(prodiID, cb_prodi.SelectedIndex));
                cmd.Parameters.AddWithValue("@nama_kelas", txt_nama.Text);
                cmd.Parameters.AddWithValue("@ruang_kelas", txt_ruang.Text);
                cmd.Parameters.AddWithValue("@lokasi_ruang_kelas", txt_lokasi.Text);
                cmd.Parameters.AddWithValue("@status_kelas", "1");

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Class data successfully updated!", "Information");
                }
                else
                {
                    MessageBox.Show("Class data update failed!");
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
            if (string.IsNullOrWhiteSpace(txt_kode.Text) ||
                string.IsNullOrWhiteSpace(cb_prodi.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(txt_nama.Text) ||
                string.IsNullOrWhiteSpace(txt_ruang.Text) ||
                string.IsNullOrWhiteSpace(txt_lokasi.Text))
            {
                MessageBox.Show("All fields must be filled out before inserting data!", "Warning", MessageBoxButtons.OK);
                return;
            }

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_add_kelas";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kode_kelas", txt_kode.Text);
                cmd.Parameters.AddWithValue("@prodi_kelas", Helper.GetElementByIndex(prodiID, cb_prodi.SelectedIndex));
                cmd.Parameters.AddWithValue("@nama_kelas", txt_nama.Text);
                cmd.Parameters.AddWithValue("@ruang_kelas", txt_ruang.Text);
                cmd.Parameters.AddWithValue("@lokasi_ruang_kelas", txt_lokasi.Text);
                cmd.Parameters.AddWithValue("@status_kelas", "1");

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    MessageBox.Show("Class data successfully inserted!", "Information");
                }
                else
                {
                    MessageBox.Show("Class data insert failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return;
            }
            clear();
        }

        private LinkedList<string> prodiID = new LinkedList<string>();
        private void fillCb()
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
                    prodiID.AddLast(reader["kode_prodi"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
        }
        private void clear()
        {
            txt_kode.Text = generateID("KL", newestID());
            if (cb_prodi.Items.Count > 0)
            {
                cb_prodi.SelectedIndex = 0; // Ensure there is at least one item before setting the index
            }
            txt_nama.Text = "";
            txt_ruang.Text = "";
            txt_lokasi.Text = "";
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
                    using (SqlCommand command = new SqlCommand("SELECT * FROM tb_kelas", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string kodeKelas = reader["kode_kelas"].ToString();
                                int currentId = int.Parse(kodeKelas.Substring(2));
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
    }
}
