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

namespace Quản_Lí_Nhà_Hàng.View
{
    public partial class frmTaotkchoNV : Form
    {
        public frmTaotkchoNV()
        {
            InitializeComponent();
        }

        private void AddItems(int id, string Username, string Userpass, string Phanquyenhienthi)
        {
            try
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvTK);
                newRow.Cells[0].Value = id;
                newRow.Cells[1].Value = Username; // Gán giá trị cho cột "Username"
                newRow.Cells[2].Value = Userpass; // Gán giá trị cho cột "Userpass"
                newRow.Cells[3].Value = Phanquyenhienthi;
                dgvTK.Rows.Add(newRow);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void LoadThongtin()
        {
            string qry = "Select * from users";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int id = Convert.ToInt32(item["UserID"]);
                string username = item["Username"].ToString();
                string userpass = item["Upass"].ToString();
                string phanquyen1 = item["Uname"].ToString();
                AddItems(id, username, userpass, phanquyen1);
            }
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {

            // Lấy thông tin từ các điều khiển trên form
            string username = txtTaoTK.Text;
            string userpass = txtMK.Text;
            string phanquyen2 = cmbPhanquyen.Text;

            // Kiểm tra thông tin người dùng đã nhập đầy đủ hay chưa
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userpass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!");
                return;
            }

            try
            {
                // Thực hiện thêm dữ liệu vào cơ sở dữ liệu
                string qry = "INSERT INTO users (Username, Upass, Uname) VALUES (@Username, @Upass, @Uname)";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Upass", userpass);
                cmd.Parameters.AddWithValue("@Uname", phanquyen2);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.con.Close();

                // Thêm dữ liệu vào DataGridView
                //int id = GetNextUserID(); // Lấy ID mới của tài khoản vừa thêm
                AddItems(0, username, userpass, phanquyen2);

                // Xóa nội dung các điều khiển nhập liệu
                txtTaoTK.Text = string.Empty;
                txtMK.Text = string.Empty;

                MessageBox.Show("Thêm tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }


        }

        private void frmTaotkchoNV_Load(object sender, EventArgs e)
        {

            LoadThongtin();
            cmbPhanquyen.StartIndex = 0;
        }
        
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng dữ liệu nào được chọn trong DataGridView hay không
            if (dgvTK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!");
                return;
            }
          //   frmLogin frm = new frmLogin();
           

           
            // Lấy giá trị của cột ID từ dòng được chọn
            int id = Convert.ToInt32(dgvTK.SelectedRows[0].Cells[0].Value);
            // Lấy giá trị của cột vai trò (role) từ dòng được chọn
            string role = dgvTK.SelectedRows[0].Cells["dgvTen"].Value.ToString();

            if (role == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thực hiện xóa dữ liệu từ cơ sở dữ liệu
                string qry = "DELETE FROM users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.Parameters.AddWithValue("@UserID", id);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.con.Close();

                // Xóa dòng được chọn từ DataGridView
                dgvTK.Rows.RemoveAt(dgvTK.SelectedRows[0].Index);

                MessageBox.Show("Xóa tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }
    }
}