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
using System.Xml.Serialization;

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class chonBan : Form
    {
        public chonBan()
        {
            InitializeComponent();
        }
        public string TableName;

        //public void KtratruockhiChonban()
        //{
        //    string qry = "SELECT TableName, status FROM tblMain";
        //    SqlCommand cmd = new SqlCommand(qry, MainClass.con);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        // string tableName = row["TableName"].ToString();
        //        string status = row["status"].ToString();

        //        Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
        //        // b.Text = tableName;
        //        b.Width = 510;
        //        b.Height = 50;
        //        b.FillColor = Color.Orange;
        //        b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

        //        if (status == "Đã trả")
        //        {
        //            b.Enabled = true; // Cho phép người dùng chọn bàn
        //        }
        //        else
        //        {
        //            b.Enabled = false; // Vô hiệu hóa nút bàn nếu chưa thanh toán
        //            b.FillColor = Color.Gray;
        //        }

        //        b.Click += new EventHandler(b_Click);
        //        flowLayoutPanel1.Controls.Add(b);
        //    }
        //}

        private void chonBan_Load(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM tables";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                string tableName = row["tname"].ToString();
                string qryy = "SELECT status FROM tblMain WHERE TableName = @TableName";
                SqlCommand cmdd = new SqlCommand(qryy, MainClass.con);
                cmdd.Parameters.AddWithValue("@TableName", tableName);
                DataTable dtt = new DataTable();
                SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                daa.Fill(dtt);

                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = tableName;
                b.Width = 510;
                b.Height = 50;
                b.FillColor = Color.Orange;
                b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

                //if (dtt.Rows.Count > 0)
                //{
                foreach (DataRow sta in dtt.Rows)
                {
                    string status = sta ["status"].ToString();
                    if (status == "Chưa thanh toán")
                    {
                        b.Enabled = false; // Vô hiệu hóa nút bàn nếu chưa thanh toán
                        b.FillColor = Color.Gray;
                      
                    }
                    else
                    {
                        b.Enabled = true; // Cho phép người dùng chọn bàn
                    }
                }
               
                //}

                b.Click += new EventHandler(b_Click);
                flowLayoutPanel1.Controls.Add(b);
            }

            // KtratruockhiChonban();
        }

        // Hiển thị sản phẩm bằng cách nhấp vào nút danh mục
        private void b_Click(object sender, EventArgs e)
        {
            TableName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();
        }
    }
}
