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
    public partial class form_admin : Form
    {
        public form_admin()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        
        private void form_admin_Load(object sender, EventArgs e)
        {
            fillCb();

            if (crud_admin.isUpdate)
            {
                bt_insert.Visible = false;

                string[] data = crud_admin.selected;

                txt_kode.Text = data[0];
                cb_prodi.Text = data[1];
                txt_nadep.Text = data[2];
                txt_nabel.Text = data[3];
                cb_gender.Text = data[4];
                txt_telp.Text = data[5];
                txt_email.Text = data[6];
            } else
            { 
                txt_kode.Text = generateID("AD", newestId());
                bt_update.Visible = false;
            }
            txt_kode.Enabled = false;
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
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
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
                messageBox_cus.Show("Confirm", "Error : " + ex, MessageBoxIcon.Error);
            }
        }
        private void insertdata()
        {
            string kode, prodi, nadep, nabel, telp, email, pass, gender;

            kode = txt_kode.Text;
            prodi = Helper.GetElementByIndex(prodiID, cb_prodi.SelectedIndex);
            nadep = txt_nadep.Text;
            nabel = txt_nabel.Text;
            gender = cb_gender.SelectedItem.ToString();
            telp = txt_telp.Text;
            email = txt_email.Text;
            pass = Helper.generatePassword();


            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "INSERT INTO tb_admin VALUES ( @kode, @prodi, @nadep, @nabel, @telp, @email, @pass, @gender,  1)";
                myCmd.CommandType = CommandType.Text;

                myCmd.Parameters.AddWithValue("@kode", kode);
                myCmd.Parameters.AddWithValue("@prodi", prodi);
                myCmd.Parameters.AddWithValue("@nadep", nadep);
                myCmd.Parameters.AddWithValue("@nabel", nabel);
                myCmd.Parameters.AddWithValue("@gender", gender);
                myCmd.Parameters.AddWithValue("@telp", telp);
                myCmd.Parameters.AddWithValue("@email", email);
                myCmd.Parameters.AddWithValue("@pass", pass);

                connection.Open();
                int result = Convert.ToInt32(myCmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    messageBox_cus.Show("Success", "Successfuly insert the data", MessageBoxIcon.Information);
                }
                else
                {
                    messageBox_cus.Show("Error", "Error during insert the data", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        private void updatedata()
        {
            string kode, prodi, nadep, nabel, telp, email, pass, gender;

            kode = txt_kode.Text;
            prodi = Helper.GetElementByIndex(prodiID, cb_prodi.SelectedIndex);
            nadep = txt_nadep.Text;
            nabel = txt_nabel.Text;
            gender = cb_gender.SelectedItem.ToString();
            telp = txt_telp.Text;
            email = txt_email.Text;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE tb_admin " +
                    "SET prodi_admin=@prodi, " +
                    "nama_depan_admin=@nadep, " +
                    "nama_belakang_admin=@nabel, " +
                    "gender_admin=@gender, " +
                    "telp_admin=@telp, " +
                    "email_admin=@email " +
                    "WHERE kode_admin=@kode";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@kode", kode);
                cmd.Parameters.AddWithValue("@prodi", prodi);
                cmd.Parameters.AddWithValue("@nadep", nadep);
                cmd.Parameters.AddWithValue("@nabel", nabel);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@telp", telp);
                cmd.Parameters.AddWithValue("@email", email);

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    clear();
                    messageBox_cus.Show("Success", "Successfuly update the data", MessageBoxIcon.Information);
                }
                else
                {
                    messageBox_cus.Show("Error", "Error during update the data", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex.Message);
                return;
            }
        }
        private void clear()
        {
            txt_kode.Text =  generateID("AD", newestId());
            txt_nadep.Text = "";
            txt_nabel.Text = "";
            txt_telp.Text = "";
            txt_email.Text = "";
            cb_gender.SelectedIndex = -1;
            cb_prodi.SelectedIndex = -1;
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
                myCmd.CommandText = "SELECT * FROM tb_admin";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["kode_admin"].ToString().Substring(2));
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

        private void txt_nadep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_telp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled= true;
            }
            
        }
    }
}
