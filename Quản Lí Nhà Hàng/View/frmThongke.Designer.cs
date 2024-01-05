namespace Quản_Lí_Nhà_Hàng.View
{
    partial class frmThongke
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
            this.dtpNgaybatdau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayketthuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTK = new Guna.UI2.WinForms.Guna2Button();
            this.lblThongke = new System.Windows.Forms.Label();
            this.btnSomon = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpNgaybatdau
            // 
            this.dtpNgaybatdau.Checked = true;
            this.dtpNgaybatdau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgaybatdau.Location = new System.Drawing.Point(215, 96);
            this.dtpNgaybatdau.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgaybatdau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaybatdau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaybatdau.Name = "dtpNgaybatdau";
            this.dtpNgaybatdau.Size = new System.Drawing.Size(267, 60);
            this.dtpNgaybatdau.TabIndex = 0;
            this.dtpNgaybatdau.Value = new System.DateTime(2023, 11, 1, 23, 42, 35, 279);
            this.dtpNgaybatdau.ValueChanged += new System.EventHandler(this.dtpNgaybatdau_ValueChanged);
            // 
            // dtpNgayketthuc
            // 
            this.dtpNgayketthuc.Checked = true;
            this.dtpNgayketthuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayketthuc.Location = new System.Drawing.Point(760, 96);
            this.dtpNgayketthuc.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayketthuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayketthuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayketthuc.Name = "dtpNgayketthuc";
            this.dtpNgayketthuc.Size = new System.Drawing.Size(267, 60);
            this.dtpNgayketthuc.TabIndex = 1;
            this.dtpNgayketthuc.Value = new System.DateTime(2023, 11, 1, 23, 42, 37, 506);
            this.dtpNgayketthuc.ValueChanged += new System.EventHandler(this.dtpNgayketthuc_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(595, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(440, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thống kê doanh thu";
            // 
            // btnTK
            // 
            this.btnTK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTK.ForeColor = System.Drawing.Color.White;
            this.btnTK.Location = new System.Drawing.Point(445, 598);
            this.btnTK.Margin = new System.Windows.Forms.Padding(4);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(240, 55);
            this.btnTK.TabIndex = 3;
            this.btnTK.Text = "Tổng danh thu";
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // lblThongke
            // 
            this.lblThongke.AutoSize = true;
            this.lblThongke.BackColor = System.Drawing.Color.Transparent;
            this.lblThongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongke.Location = new System.Drawing.Point(138, 69);
            this.lblThongke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongke.Name = "lblThongke";
            this.lblThongke.Size = new System.Drawing.Size(19, 29);
            this.lblThongke.TabIndex = 2;
            this.lblThongke.Text = ".";
            // 
            // btnSomon
            // 
            this.btnSomon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSomon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSomon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSomon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSomon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSomon.ForeColor = System.Drawing.Color.White;
            this.btnSomon.Location = new System.Drawing.Point(445, 304);
            this.btnSomon.Margin = new System.Windows.Forms.Padding(4);
            this.btnSomon.Name = "btnSomon";
            this.btnSomon.Size = new System.Drawing.Size(240, 55);
            this.btnSomon.TabIndex = 3;
            this.btnSomon.Text = "Top 3 món ăn";
            this.btnSomon.Click += new System.EventHandler(this.btnSomon_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(84, 366);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 85);
            this.dataGridView1.TabIndex = 4;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.lblThongke);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(372, 459);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(398, 132);
            this.guna2GroupBox1.TabIndex = 5;
            this.guna2GroupBox1.Text = "Số Tiền";
            // 
            // frmThongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1472, 683);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSomon);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgayketthuc);
            this.Controls.Add(this.dtpNgaybatdau);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongke";
            this.Text = "frmThongke";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaybatdau;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayketthuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnTK;
        private System.Windows.Forms.Label lblThongke;
        private Guna.UI2.WinForms.Guna2Button btnSomon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
    }
}