using Quản_Lí_Nhà_Hàng.Model;
using Quản_Lí_Nhà_Hàng.View;
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
using System.Security.Cryptography;
using BCrypt.Net;

namespace Quản_Lí_Nhà_Hàng
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtPass.KeyPress += txtPass_KeyPress; // Gán sự kiện KeyPress của txtPass cho phương thức txtPass_KeyPress
        }
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Người dùng nhấn phím Enter
                btnLogin_Click(sender, e); // Gọi sự kiện btnLogin_Click để xử lý đăng nhập
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsValidUser(string username, string password)
        {
            string qry = "SELECT Upass FROM Users WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(qry, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                MainClass.con.Open();
                string hashedPassword = (string)cmd.ExecuteScalar();
                MainClass.con.Close();

                if (hashedPassword != null)
                {
                    // Kiểm tra tính hợp lệ của mật khẩu đã mã hóa
                    if (VerifyPassword(password, hashedPassword))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Kiểm tra mật khẩu đã được mã hóa bằng BCrypt.Net
            bool passwordVerified = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return passwordVerified;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;


            if (!IsValidUser(username, password))
            {
                MessageBox.Show("Sai username hoặc password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Đăng nhập thành công
            string qry = "SELECT * FROM Users WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(qry, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string cv = dt.Rows[0]["Uname"].ToString();
                    // ...

                    if (cv.Equals("Nhân viên order"))
                    {
                        this.Hide();
                        frmPOS pOS = new frmPOS();
                        pOS.Show();
                    }
                    else
                    {
                        frmMain frm = new frmMain();
                        frm.Show();
                    }
                }
            }

        }

        private void lblQmk_Click(object sender, EventArgs e)
        {
            frmQmk quenMatKhau = new frmQmk ();
            quenMatKhau.ShowDialog();
        }
    }
}
