﻿using System;
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
    public partial class crud_prof : Form
    {
        public crud_prof()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;";
        private const string dateFormat = "dd-MM-yyyy";
        public static bool isUpdate = false;
        public static string[] selected = new string[12];
        private void crud_prof_Load(object sender, EventArgs e)
        {
            tbview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbview.MultiSelect = false;
            load_data();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            add_click();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            searchdata();
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
                form_prof cForm = new form_prof();
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
                myCmd.CommandText = "SELECT nidn_profesor, nama_prodi, nik_profesor, nama_depan_profesor, nama_belakang_profesor, password_profesor, alamat_profesor," +
                    " tptlahir_profesor, tgllahir_profesor, telp_profesor, email_profesor, jenis_kelamin_profesor, bidangkeahlian_profesor FROM tb_profesor" +
                    " INNER JOIN tb_prodi ON prodi_profesor = kode_prodi WHERE status_profesor != 0";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                tbview.Rows.Clear();
                while (reader.Read())
                {
                    DateTime tglLahir;
                    if (reader["tgllahir_profesor"] != DBNull.Value)
                    {
                        tglLahir = Convert.ToDateTime(reader["tgllahir_profesor"]);
                    }
                    else
                    {
                        tglLahir = DateTime.Now;
                    }

                    tbview.Rows.Add(reader["nidn_profesor"],
                        reader["nama_prodi"],
                        reader["nik_profesor"],
                        reader["nama_depan_profesor"],
                        reader["nama_belakang_profesor"],
                        reader["tptlahir_profesor"],
                        tglLahir.ToString(dateFormat),
                        reader["jenis_kelamin_profesor"],
                        reader["alamat_profesor"],
                        reader["telp_profesor"],
                        reader["email_profesor"],
                        reader["bidangkeahlian_profesor"],
                        reader["password_profesor"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deletedata()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCmd = new SqlCommand();
                myCmd.Connection = connection;
                myCmd.CommandText = "UPDATE tb_profesor SET status_profesor = 0 WHERE nidn_profesor = '" + selected[0] + "'";
                myCmd.CommandType = CommandType.Text;

                connection.Open();
                int result = Convert.ToInt32(myCmd.ExecuteNonQuery());
                connection.Close();
                if (result != 0)
                {
                    MessageBox.Show("Professor data successfully deleted!", "Information");
                }
                else
                {
                    MessageBox.Show("Professor data update failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                myCmd.CommandText = "SELECT nidn_profesor, nama_prodi, nik_profesor, nama_depan_profesor, nama_belakang_profesor, password_profesor, alamat_profesor," +
                    " tptlahir_profesor, tgllahir_profesor, telp_profesor, email_profesor, jenis_kelamin_profesor, bidangkeahlian_profesor FROM tb_profesor" +
                    " INNER JOIN tb_prodi ON prodi_profesor = kode_prodi  WHERE status_profesor != 0 AND " +
                    "(nama_depan_profesor LIKE '%" + txt_search.Text + "%' OR nama_belakang_profesor LIKE '%" + txt_search.Text + "%')";

                myCmd.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = myCmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime tglLahir;
                    if (reader["tgllahir_profesor"] != DBNull.Value)
                    {
                        tglLahir = Convert.ToDateTime(reader["tgllahir_profesor"]);
                    }
                    else
                    {
                        tglLahir = DateTime.Now; // Initialize with current date
                    }

                    tbview.Rows.Add(reader["nidn_profesor"],
                          reader["nama_prodi"],
                          reader["nik_profesor"],
                          reader["nama_depan_profesor"],
                          reader["nama_belakang_profesor"],
                          reader["tptlahir_profesor"],
                          tglLahir.ToString(dateFormat),
                          reader["jenis_kelamin_profesor"],
                          reader["alamat_profesor"],
                          reader["telp_profesor"],
                          reader["email_profesor"],
                          reader["bidangkeahlian_profesor"],
                          reader["password_profesor"]);
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
            form_prof cForm = new form_prof();
            Helper.showForm(this, cForm);
            load_data();
        }
    }
}
