using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Quản_Lí_Nhà_Hàng.View
{
    public partial class frmThongke : Form
    {
        public frmThongke()
        {
            InitializeComponent();
        }
        private SqlCommand cmd1; // Khai báo cmd1 là biến toàn cục


        public void GetData()
        {
            // Lấy giá trị ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate = dtpNgaybatdau.Value;
            DateTime endDate = dtpNgayketthuc.Value;

            // Chuyển định dạng ngày để sử dụng trong truy vấn
            string formattedStartDate = startDate.ToString("yyyy/MM/dd");
            string formattedEndDate = endDate.ToString("yyyy/MM/dd");

            string qry1 = $"SELECT sum(received - change)  FROM tblMain WHERE aDate BETWEEN '{formattedStartDate}' AND '{formattedEndDate}'";

            cmd1 = new SqlCommand(qry1, MainClass.con);
            MainClass.con.Open();

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
           
            // Gọi phương thức GetData() để lấy dữ liệu từ cơ sở dữ liệu
            GetData();

            // Kiểm tra nếu cmd1 không null
            if (cmd1 != null)
            {
                // Thực hiện truy vấn và chuyển đổi giá trị thành kiểu decimal
                object result = cmd1.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal totalAmount = Convert.ToDecimal(result);

                    // Định dạng giá trị thành dạng nghìn với dấu chấm
                    string formattedAmount = totalAmount.ToString("#,##0", new CultureInfo("vi-VN"));

                    // Gán giá trị vào Label
                    lblThongke.Text = "Tổng tiền: " + formattedAmount;
                }
                else
                {
                    // Xử lý khi không có dữ liệu
                    lblThongke.Text = "Không có dữ liệu";
                }
            }
            else
            {
                // Xử lý khi không có dữ liệu
                lblThongke.Text = "Không có dữ liệu";
            }

            MainClass.con.Close(); // Đóng kết nối sau khi sử dụng
        }
        private void Ketnoi()
        {
            string qry = "SELECT TOP 3 COUNT(d.proID) AS ProductCount, p.pName FROM tblDetails d INNER JOIN products p ON p.pID = d.proID GROUP BY p.pID, p.pName ORDER BY ProductCount DESC";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            MainClass.con.Open();

            // Thực hiện truy vấn và trả về dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            MainClass.con.Close(); // Đóng kết nối sau khi sử dụng

            // Đổi tên các cột
            dt.Columns["pName"].ColumnName = "Tên sản phẩm";
            dt.Columns["ProductCount"].ColumnName = "Số lượng";

            // Truyền dữ liệu vào DataGridView
            dataGridView1.DataSource = dt;
        }
        private void btnSomon_Click(object sender, EventArgs e)
        {
            Ketnoi();
        }

        private void dtpNgaybatdau_ValueChanged(object sender, EventArgs e)
        {

            DateTime ngay = dtpNgaybatdau.Value.Date;
            DateTime ngayHienTai = DateTime.Now.Date;

            if (ngay.Date > ngayHienTai)
            {
                dtpNgaybatdau.Value = ngayHienTai;
                MessageBox.Show("Ngày bắt đầu thống kê không được lớn hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return;
        }

        private void dtpNgayketthuc_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgayketthuc.Value.Date;
            DateTime ngayHienTai = DateTime.Now.Date;

            if (ngay.Date > ngayHienTai)
            {
                dtpNgayketthuc.Value = ngayHienTai;
                MessageBox.Show("Ngày kết thúc thống kê không được lớn hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return;
        }

        
    }
}
