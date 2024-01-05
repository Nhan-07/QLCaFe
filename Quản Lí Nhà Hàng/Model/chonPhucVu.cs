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

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class chonPhucVu : Form
    {
        public chonPhucVu()
        {
            InitializeComponent();
        }
        public string WaiterName;
        private void chonPhucVu_Load(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM staff WHERE sRole = @sRole";
            string cv = "Phục vụ"; // Chức vụ cần tìm kiếm
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            cmd.Parameters.AddWithValue("@sRole", cv);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = row["sName"].ToString();
                b.Width = 150;
                b.Height = 50;
                b.FillColor = Color.Orange;
                b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

                
                b.Click += b_Click; // Gán sự kiện Click cho nút b

                flowLayoutPanel1.Controls.Add(b);
            }
        }

        public void b_Click(object sender, EventArgs e)
        {
            string selectedStaffName = ((Guna.UI2.WinForms.Guna2Button)sender).Text;
            WaiterName= selectedStaffName;
            MessageBox.Show("Chọn phục vụ thành công","Thông Báo",MessageBoxButtons.OK);
            this.Close();   
        }
    }
}   

