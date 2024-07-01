namespace projectSia_final
{
    partial class rowAction
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
            this.lb_name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_del = new Guna.UI2.WinForms.Guna2Button();
            this.bt_update = new Guna.UI2.WinForms.Guna2Button();
            this.lb_kode = new System.Windows.Forms.Label();
            this.back = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.ForeColor = System.Drawing.Color.White;
            this.lb_name.Location = new System.Drawing.Point(49, 31);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(230, 45);
            this.lb_name.TabIndex = 18;
            this.lb_name.Text = "Data Action";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(53, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 3);
            this.panel1.TabIndex = 70;
            // 
            // bt_del
            // 
            this.bt_del.AutoRoundedCorners = true;
            this.bt_del.BorderRadius = 16;
            this.bt_del.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_del.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_del.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_del.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_del.FillColor = System.Drawing.Color.White;
            this.bt_del.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_del.ForeColor = System.Drawing.Color.Black;
            this.bt_del.Image = global::projectSia_final.Properties.Resources.del;
            this.bt_del.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt_del.ImageOffset = new System.Drawing.Point(24, 0);
            this.bt_del.ImageSize = new System.Drawing.Size(28, 28);
            this.bt_del.Location = new System.Drawing.Point(57, 202);
            this.bt_del.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(155, 35);
            this.bt_del.TabIndex = 71;
            this.bt_del.Text = "Delete";
            this.bt_del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bt_del.TextOffset = new System.Drawing.Point(-5, 0);
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // bt_update
            // 
            this.bt_update.AutoRoundedCorners = true;
            this.bt_update.BorderRadius = 16;
            this.bt_update.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_update.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_update.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_update.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_update.FillColor = System.Drawing.Color.White;
            this.bt_update.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_update.ForeColor = System.Drawing.Color.Black;
            this.bt_update.Image = global::projectSia_final.Properties.Resources.edit;
            this.bt_update.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt_update.ImageOffset = new System.Drawing.Point(18, 0);
            this.bt_update.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_update.Location = new System.Drawing.Point(259, 202);
            this.bt_update.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.bt_update.Name = "bt_update";
            this.bt_update.Size = new System.Drawing.Size(155, 35);
            this.bt_update.TabIndex = 72;
            this.bt_update.Text = "Update";
            this.bt_update.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bt_update.TextOffset = new System.Drawing.Point(-5, 0);
            this.bt_update.Click += new System.EventHandler(this.bt_update_Click);
            // 
            // lb_kode
            // 
            this.lb_kode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_kode.AutoSize = true;
            this.lb_kode.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_kode.ForeColor = System.Drawing.Color.White;
            this.lb_kode.Location = new System.Drawing.Point(53, 143);
            this.lb_kode.Name = "lb_kode";
            this.lb_kode.Size = new System.Drawing.Size(317, 22);
            this.lb_kode.TabIndex = 73;
            this.lb_kode.Text = "Select action for the selected data ...";
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.back.BorderRadius = 20;
            this.back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.back.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.back.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Image = global::projectSia_final.Properties.Resources.icons8_back_to_96;
            this.back.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.back.ImageSize = new System.Drawing.Size(30, 30);
            this.back.Location = new System.Drawing.Point(478, 31);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(105, 34);
            this.back.TabIndex = 74;
            this.back.Text = "Back";
            this.back.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // rowAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(636, 276);
            this.Controls.Add(this.back);
            this.Controls.Add(this.lb_kode);
            this.Controls.Add(this.bt_update);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "rowAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "rowAction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button bt_del;
        private Guna.UI2.WinForms.Guna2Button bt_update;
        private System.Windows.Forms.Label lb_kode;
        private Guna.UI2.WinForms.Guna2Button back;
    }
}