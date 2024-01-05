using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lí_Nhà_Hàng.View;
using System.Data.SqlClient;

namespace Quản_Lí_Nhà_Hàng
{
    public partial class frmQmk : Form
    {
        private string verification_code;
        public frmQmk()
        {
            InitializeComponent();
            //gán mã xác nhận vào biến
            verification_code = MaXacNhan();
        }
        private void frmQmk_Load(object sender, EventArgs e)
        {
            //cmbPhanquyen.StartIndex = 0;
        }
        //random Mã xác nhận
        private string MaXacNhan()
        {
            Random random = new Random();
            int code = random.Next(000000, 999999);
            return code.ToString();
        }

        //nút gữi mã xác nhận
        private async void btnGui_Click(object sender, EventArgs e)
        {
            string Gmail = txtGmail.Text;
            string matkhau = txtMatKhau.Text;
            string email = "";
            string MK = "";
            //kiểm tra là nếu có @ thì đó là email và gán vào email
            if (Gmail.Contains("@"))
            {
                Gmail = txtGmail.Text;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ.", "Thông Báo");
                return;
            }

            // Kiểm tra xem đã có Gmail này trong cơ sở dữ liệu hay chưa
            if (CheckExistingEmail(email))
            {
                MessageBox.Show("Địa chỉ email đã được sử dụng. Vui lòng sử dụng địa chỉ email khác.", "Thông Báo");
                return;
            }
            if (CheckExistingUpass(MK))
            {
                MessageBox.Show("MK này đã được sử dụng. Vui lòng sử dụng MK khác.", "Thông Báo");
                return;
            }
            string from = "jhmxftugyu76f@gmail.com";  // email dùng để gửi mã
            string pass = "ltug fyax obkd nygp";  // key email

            //soạn tin nhắn để gửi
            MailMessage message = new MailMessage();
            message.To.Add(Gmail);
            message.From = new MailAddress(from);
            message.Body = verification_code;
            message.Subject = "Mã xác nhận của bạn";

            //sửa dụng SmtpClient smtp để gửi
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                //gửi
                smtp.Send(message);
                MessageBox.Show("Đang gửi mã xác nhận tới email: " + Gmail, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGui.Enabled = false; //khi gửi sẽ khóa nút gửi
                btnGui.BackColor = Color.Gray; // nút chuyển sang màu xám
                int delayInSeconds = 60;  // cho thời gian 60 giây
                btnThoiGian.Text = delayInSeconds.ToString();

                while (delayInSeconds > 0)
                {
                    await Task.Delay(1000);  // đợi 1 giây
                    delayInSeconds--;
                    btnThoiGian.Text = delayInSeconds.ToString();
                }
                //mở khóa nút và cho gửi lại
                btnGui.Enabled = true;
                btnGui.BackColor = Color.Teal;

            }
            catch (Exception ex)
            {
                //nếu lỗi khi gửi mail sẽ báo lỗi
                MessageBox.Show("Lỗi khi gửi đến mail vui lòng xem lại mail hoặc nhập lại mã xác nhận" + ex.Message);
            }
        }

        private bool CheckExistingEmail(string email)
        {

            string qry = "SELECT COUNT(*) FROM users WHERE Gmail = @Email";
            using (SqlConnection con = new SqlConnection(MainClass.con_string))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        private bool CheckExistingUpass(string MK)
        {

            string qry = "SELECT COUNT(*) FROM users WHERE Upass = @Upass";
            using (SqlConnection con = new SqlConnection(MainClass.con_string))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@Upass", MK);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void btnDatLaiMatKhau_Click_1(object sender, EventArgs e)
        {
            string Gmail = txtGmail.Text;
            string matkhau = txtMatKhau.Text;
            string nhaplaimatkhau = txtNhapLaiMatKhau.Text;

            // Kiểm tra xem đã nhập đúng yêu cầu chưa, nếu không sẽ thông báo
            if (string.IsNullOrEmpty(Gmail))
            {
                MessageBox.Show("Vui lòng nhập Gmail!", "Thông Báo");
                return;
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông Báo");
                return;
            }

            if (nhaplaimatkhau != matkhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác", "Thông Báo");
                return;
            }

            // Kiểm tra mã xác nhận
            string userEnteredCode = txtMaXacNhan.Text.Trim();
            if (userEnteredCode != verification_code)
            {
                MessageBox.Show("Mã xác nhận sai, vui lòng kiểm tra lại Email.");
                return;
            }

            // Mã hóa mật khẩu mới
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matkhau);

            string updateQuery = "UPDATE users SET Upass = @Upass WHERE Gmail = @Gmail";
            using (SqlConnection con = new SqlConnection(MainClass.con_string))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Upass", hashedPassword);
                    cmd.Parameters.AddWithValue("@Gmail", Gmail);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thông Báo");
                        // Thực hiện các hành động bổ sung hoặc hiển thị giao diện người dùng dựa trên việc thay đổi mật khẩu thành công
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, không thể thay đổi mật khẩu.", "Thông Báo");
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

