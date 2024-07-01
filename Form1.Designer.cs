namespace projectSia_final
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_log = new Guna.UI2.WinForms.Guna2Panel();
            this.bt_search = new Guna.UI2.WinForms.Guna2Button();
            this.bt_show = new System.Windows.Forms.Button();
            this.txt_pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.lb_nama = new System.Windows.Forms.Label();
            this.txt_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.lb_kode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.panel_log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_log
            // 
            this.panel_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(29)))), ((int)(((byte)(124)))));
            this.panel_log.BorderColor = System.Drawing.Color.White;
            this.panel_log.BorderRadius = 20;
            this.panel_log.Controls.Add(this.bt_search);
            this.panel_log.Controls.Add(this.bt_show);
            this.panel_log.Controls.Add(this.txt_pass);
            this.panel_log.Controls.Add(this.lb_nama);
            this.panel_log.Controls.Add(this.txt_username);
            this.panel_log.Controls.Add(this.lb_kode);
            this.panel_log.Controls.Add(this.label6);
            this.panel_log.Controls.Add(this.label5);
            this.panel_log.Controls.Add(this.label4);
            this.panel_log.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.panel_log.Location = new System.Drawing.Point(812, 102);
            this.panel_log.Name = "panel_log";
            this.panel_log.Size = new System.Drawing.Size(338, 501);
            this.panel_log.TabIndex = 18;
            // 
            // bt_search
            // 
            this.bt_search.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.bt_search.BorderRadius = 10;
            this.bt_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_search.FillColor = System.Drawing.Color.White;
            this.bt_search.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_search.ForeColor = System.Drawing.Color.Black;
            this.bt_search.Location = new System.Drawing.Point(87, 404);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(164, 28);
            this.bt_search.TabIndex = 26;
            this.bt_search.Text = "Login";
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // bt_show
            // 
            this.bt_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.bt_show.BackgroundImage = global::projectSia_final.Properties.Resources.eyeWhiteClosed;
            this.bt_show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_show.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bt_show.FlatAppearance.BorderSize = 0;
            this.bt_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_show.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_show.ForeColor = System.Drawing.Color.White;
            this.bt_show.Location = new System.Drawing.Point(282, 342);
            this.bt_show.Name = "bt_show";
            this.bt_show.Size = new System.Drawing.Size(15, 15);
            this.bt_show.TabIndex = 17;
            this.bt_show.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_show.UseVisualStyleBackColor = false;
            this.bt_show.Click += new System.EventHandler(this.bt_show_Click);
            // 
            // txt_pass
            // 
            this.txt_pass.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.txt_pass.BorderColor = System.Drawing.Color.White;
            this.txt_pass.BorderRadius = 10;
            this.txt_pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_pass.DefaultText = "";
            this.txt_pass.DisabledState.BorderColor = System.Drawing.Color.White;
            this.txt_pass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.txt_pass.DisabledState.ForeColor = System.Drawing.Color.White;
            this.txt_pass.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_pass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.txt_pass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_pass.FocusedState.ForeColor = System.Drawing.Color.White;
            this.txt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.ForeColor = System.Drawing.Color.White;
            this.txt_pass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_pass.Location = new System.Drawing.Point(145, 337);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_pass.MaxLength = 10;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '\0';
            this.txt_pass.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_pass.PlaceholderText = "";
            this.txt_pass.SelectedText = "";
            this.txt_pass.Size = new System.Drawing.Size(161, 25);
            this.txt_pass.TabIndex = 23;
            // 
            // lb_nama
            // 
            this.lb_nama.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lb_nama.AutoSize = true;
            this.lb_nama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.lb_nama.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nama.ForeColor = System.Drawing.Color.White;
            this.lb_nama.Location = new System.Drawing.Point(34, 337);
            this.lb_nama.Name = "lb_nama";
            this.lb_nama.Size = new System.Drawing.Size(79, 23);
            this.lb_nama.TabIndex = 24;
            this.lb_nama.Text = "Password";
            // 
            // txt_username
            // 
            this.txt_username.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_username.AutoRoundedCorners = true;
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.txt_username.BorderColor = System.Drawing.Color.White;
            this.txt_username.BorderRadius = 11;
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_username.DefaultText = "";
            this.txt_username.DisabledState.BorderColor = System.Drawing.Color.White;
            this.txt_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.txt_username.DisabledState.ForeColor = System.Drawing.Color.White;
            this.txt_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_username.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.txt_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.FocusedState.ForeColor = System.Drawing.Color.White;
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_username.ForeColor = System.Drawing.Color.White;
            this.txt_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Location = new System.Drawing.Point(145, 289);
            this.txt_username.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_username.MaxLength = 10;
            this.txt_username.Name = "txt_username";
            this.txt_username.PasswordChar = '\0';
            this.txt_username.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txt_username.PlaceholderText = "";
            this.txt_username.SelectedText = "";
            this.txt_username.Size = new System.Drawing.Size(161, 25);
            this.txt_username.TabIndex = 22;
            // 
            // lb_kode
            // 
            this.lb_kode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lb_kode.AutoSize = true;
            this.lb_kode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.lb_kode.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_kode.ForeColor = System.Drawing.Color.White;
            this.lb_kode.Location = new System.Drawing.Point(34, 289);
            this.lb_kode.Name = "lb_kode";
            this.lb_kode.Size = new System.Drawing.Size(83, 23);
            this.lb_kode.TabIndex = 25;
            this.lb_kode.Text = "Username";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(33, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "and password to access the app!";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(33, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Write down your username";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(79)))), ((int)(((byte)(222)))));
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Account Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(131, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 75);
            this.label1.TabIndex = 12;
            this.label1.Text = "University";
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.ForeColor = System.Drawing.Color.White;
            this.lbText.Location = new System.Drawing.Point(152, 484);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(294, 40);
            this.lbText.TabIndex = 13;
            this.lbText.Text = "\"In the heart of unity, we find our strength;\r\nin the diversity of minds, we disc" +
    "over our power.\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(150, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Academic System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(131, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(403, 75);
            this.label2.TabIndex = 15;
            this.label2.Text = "of Hogwarts";
            // 
            // bt_exit
            // 
            this.bt_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_exit.BackgroundImage = global::projectSia_final.Properties.Resources.logout;
            this.bt_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bt_exit.FlatAppearance.BorderSize = 0;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_exit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exit.ForeColor = System.Drawing.Color.White;
            this.bt_exit.Location = new System.Drawing.Point(157, 609);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(42, 43);
            this.bt_exit.TabIndex = 17;
            this.bt_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::projectSia_final.Properties.Resources.hat_02;
            this.pictureBox1.Location = new System.Drawing.Point(415, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // myTimer
            // 
            this.myTimer.Interval = 3000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(29)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_log);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.login_Load);
            this.panel_log.ResumeLayout(false);
            this.panel_log.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_log;
        private Guna.UI2.WinForms.Guna2Button bt_search;
        private Guna.UI2.WinForms.Guna2TextBox txt_pass;
        private System.Windows.Forms.Label lb_nama;
        private Guna.UI2.WinForms.Guna2TextBox txt_username;
        private System.Windows.Forms.Label lb_kode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.Button bt_show;
    }
}

