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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpNgaybatdau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayketthuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTK = new Guna.UI2.WinForms.Guna2Button();
            this.lblThongke = new System.Windows.Forms.Label();
            this.lblTopmon = new System.Windows.Forms.Label();
            this.btnSomon = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpNgaybatdau
            // 
            this.dtpNgaybatdau.Checked = true;
            this.dtpNgaybatdau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgaybatdau.Location = new System.Drawing.Point(211, 61);
            this.dtpNgaybatdau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dtpNgayketthuc.Location = new System.Drawing.Point(756, 61);
            this.dtpNgayketthuc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.label1.Location = new System.Drawing.Point(49, 61);
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
            this.label2.Location = new System.Drawing.Point(591, 61);
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
            this.label3.Location = new System.Drawing.Point(13, 9);
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
            this.btnTK.Location = new System.Drawing.Point(60, 577);
            this.btnTK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(240, 55);
            this.btnTK.TabIndex = 3;
            this.btnTK.Text = "Tổng danh thu";
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // lblThongke
            // 
            this.lblThongke.AutoSize = true;
            this.lblThongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongke.Location = new System.Drawing.Point(308, 603);
            this.lblThongke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongke.Name = "lblThongke";
            this.lblThongke.Size = new System.Drawing.Size(487, 29);
            this.lblThongke.TabIndex = 2;
            this.lblThongke.Text = "Tổng số tiền thu được trong khoảng thời gian";
            // 
            // lblTopmon
            // 
            this.lblTopmon.AutoSize = true;
            this.lblTopmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopmon.Location = new System.Drawing.Point(335, 175);
            this.lblTopmon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTopmon.Name = "lblTopmon";
            this.lblTopmon.Size = new System.Drawing.Size(313, 29);
            this.lblTopmon.TabIndex = 2;
            this.lblTopmon.Text = "Top 3 món ăn bán chạy nhất";
            // 
            // btnSomon
            // 
            this.btnSomon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSomon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSomon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSomon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSomon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSomon.ForeColor = System.Drawing.Color.White;
            this.btnSomon.Location = new System.Drawing.Point(60, 149);
            this.btnSomon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSomon.Name = "btnSomon";
            this.btnSomon.Size = new System.Drawing.Size(240, 55);
            this.btnSomon.TabIndex = 3;
            this.btnSomon.Text = "Thống kê";
            this.btnSomon.Click += new System.EventHandler(this.btnSomon_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thống kê món ăn bán chạy";
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(60, 223);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1155, 274);
            this.guna2DataGridView1.TabIndex = 4;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // frmThongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1472, 683);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.btnSomon);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTopmon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblThongke);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgayketthuc);
            this.Controls.Add(this.dtpNgaybatdau);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmThongke";
            this.Text = "frmThongke";
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
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
        private System.Windows.Forms.Label lblTopmon;
        private Guna.UI2.WinForms.Guna2Button btnSomon;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
    }
}