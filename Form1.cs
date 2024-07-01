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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string user;
        public static string password;
        public static string prodi;
        public static string name;

        private string[] quote = new string[]
        {
            "\"With courage as our guide and wisdom as our light,\n " +
            "we journey together toward greatness.\"",
            "\"Through unwavering loyalty and boundless kindness,\n " +
            "we build a legacy of compassion and strength.\"",
            "\"Imagination fuels our dreams, innovation drives our deeds;\n " +
            "together, we shape the future.\"",
            "\"In the quest for knowledge and the pursuit of truth,\n " +
            "we forge paths to wisdom and greatness.\""
        };
        int currentIdx = 0;
        private bool isPasswordVisible = false;

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void login_Load(object sender, EventArgs e)
        {
            //transition.AnimateWindow(this.Handle, 300, transition.VER_POSITIVE);
            this.FormBorderStyle = FormBorderStyle.None;
            myTimer.Start();
            this.txt_pass.UseSystemPasswordChar = true;
        }
        private int login_count = 0;

        private void bt_search_Click(object sender, EventArgs e)
        {
            user = txt_username.Text;
            password = txt_pass.Text;
            if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("All fields must be filled!", "Something's wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.StartsWith("AD"))
            {
                //search admin
                try
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;"))
                    {
                        conn.Open();
                        string query = "SELECT kode_admin, prodi_admin, nama_belakang_admin FROM tb_admin WHERE kode_admin = @user AND password_admin = @pass";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@user", user);
                            cmd.Parameters.AddWithValue("@pass", password);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    user = reader.GetString(0);
                                    prodi = reader.GetString(1);
                                    name = reader.GetString(2);

                                    this.Hide();
                                    //new page_dashboard_admin().Show();
                                }
                                else
                                {
                                    MessageBox.Show("Username or password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    login_count++;
                                    if ((5 - login_count) < 1)
                                    {
                                        MessageBox.Show("You have reached maximum attempt of login! This app will be closed, thank you!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Application.Exit();
                                    }
                                    MessageBox.Show("You have " + (5 - login_count) + " chances left!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                reader.Close();
                            }
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading Education Details data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                //search prof
                try
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=ZYMBO\\SQLEXPRESS;Initial Catalog=dbhogwartsuniv;User ID=sa;Password=zymbo;"))
                    {
                        conn.Open();
                        string query = "SELECT 1 FROM tb_profesor WHERE nidn_profesor = @user AND password_profesor = @pass";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@user", user);
                            cmd.Parameters.AddWithValue("@pass", password);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    MessageBox.Show("Login as professor", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // changePage(event, "profesor_mainform");
                                    // Navigate to the professor main form
                                }
                                else
                                {
                                    MessageBox.Show("Username or password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    login_count++;
                                    if ((5 - login_count) < 1)
                                    {
                                        MessageBox.Show("You have reached maximum attempt of login! This app will be closed, thank you!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Application.Exit();
                                    }
                                    MessageBox.Show("You have " + (5 - login_count) + " chances left!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading Education Details data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void clear()
        {
            txt_username.Text = "";
            txt_pass.Text = "";
        }
        private Timer timer;
        private int targetX;
        private int slideSpeed;
        private void myTimer_Tick(object sender, EventArgs e)
        {
            lbText.Text = quote[currentIdx];
            currentIdx = (currentIdx + 1) % quote.Length;
        }

        private void bt_show_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                bt_show.BackgroundImage = Properties.Resources.eyeWhiteClosed;
                isPasswordVisible = false;
                this.txt_pass.UseSystemPasswordChar = true;
            }
            else
            {
                bt_show.BackgroundImage = Properties.Resources.eyeWhite;
                isPasswordVisible = true;
                this.txt_pass.UseSystemPasswordChar = false;
            }
        }
    }
}
