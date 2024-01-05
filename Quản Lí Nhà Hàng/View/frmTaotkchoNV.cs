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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Cryptography;
using BCrypt.Net;

namespace Quản_Lí_Nhà_Hàng.View
{
    public partial class frmTaotkchoNV : Form
    { 
        //private string Gmail;

        public frmTaotkchoNV()
        {
            InitializeComponent();
        }

        private void AddItems(int id, string Username, string Userpass, string Phanquyenhienthi, string Gmail)
        {
            try
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvTK);
                newRow.Cells[0].Value = id;
                newRow.Cells[1].Value = Username; // Gán giá trị cho cột "Username"
                newRow.Cells[2].Value = Userpass; // Gán giá trị cho cột "Userpass"
                newRow.Cells[3].Value = Phanquyenhienthi;
                newRow.Cells[4].Value = Gmail; // Gán giá trị cho cột "Gmail"
                dgvTK.Rows.Add(newRow);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        public void LoadThongtin()
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
                string Gmail = item["Gmail"].ToString();
                AddItems(id, username, userpass, phanquyen1, Gmail);
            }
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {

            // Lấy thông tin từ các điều khiển trên form
            string username = txtTaoTK.Text;
            string userpass = txtMK.Text;
            string phanquyen2 = cmbPhanquyen.Text;
            string Gmail = txtGmail.Text;

            // Kiểm tra thông tin người dùng đã nhập đầy đủ hay chưa
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userpass) || string.IsNullOrEmpty(Gmail))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!");
                return;
            }

            // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu hay chưa
            string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE Gmail = @Gmail";
            SqlCommand checkEmailCmd = new SqlCommand(checkEmailQuery, MainClass.con);
            checkEmailCmd.Parameters.AddWithValue("@Gmail", Gmail);
            MainClass.con.Open();
            int emailCount = (int)checkEmailCmd.ExecuteScalar();
            MainClass.con.Close();

            if (emailCount > 0)
            {
                MessageBox.Show("Email đã tồn tại trong cơ sở dữ liệu!");
                return;
            }

            try
            {
                // Mã hóa mật khẩu
                string hashedPassword = HashPassword(userpass);

                // Thực hiện thêm dữ liệu vào cơ sở dữ liệu
                string qry = "INSERT INTO users (Username, Upass, Uname, Gmail) VALUES (@Username, @Upass, @Uname, @Gmail)";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Upass", hashedPassword);
                cmd.Parameters.AddWithValue("@Uname", phanquyen2);
                cmd.Parameters.AddWithValue("@Gmail", Gmail);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.con.Close();

                // Thêm dữ liệu vào DataGridView
                //int id = GetNextUserID(); // Lấy ID mới của tài khoản vừa thêm
                AddItems(0, username, userpass, phanquyen2, Gmail);

                // Xóa nội dung các điều khiển nhập liệu
                txtTaoTK.Text = string.Empty;
                txtMK.Text = string.Empty;
                txtGmail.Text = string.Empty;

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

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấp vào một dòng hợp lệ hay không
            if (e.RowIndex >= 0 && e.RowIndex < dgvTK.Rows.Count)
            {
                // Lấy giá trị từ các ô trong dòng được chọn
                DataGridViewRow row = dgvTK.Rows[e.RowIndex];
                string username = row.Cells["dgvTen"].Value.ToString();
                string userpass = row.Cells["dgvMk"].Value.ToString();
                string phanquyen = row.Cells["dgvUname"].Value.ToString();
                string gmail = row.Cells["dgvGmail"].Value.ToString();

                // Gán giá trị sang các TextBox
                txtTaoTK.Text = username;
                txtMK.Text = userpass;
                cmbPhanquyen.Text = phanquyen;
                txtGmail.Text = gmail;
            }
        }
    }
}

