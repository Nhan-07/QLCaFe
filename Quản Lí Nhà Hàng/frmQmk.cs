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
            //cbbLoaiTaiKhoan.SelectedIndex = 0;
        }
        //random Mã xác nhận
        private string MaXacNhan()
        {
            Random random = new Random();
            int code = random.Next(000000, 999999);
            return code.ToString();
        }

        private void btnLayLaiMatKhau_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            string nhaplaimatkhau = txtNhapLaiMatKhau.Text;
            //hàm kiểm tra xem nhập đúng yêu cầu không nếu không sẽ thông báo
            if (string.IsNullOrEmpty(tentk))
            {
                // Tên tài khoảng bằng rỗng thì nhập lại
                MessageBox.Show("Vui lòng nhập tài khoản !", "Thông Báo");
                return;
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                // Mật khẩu bằng rỗng thì nhập lại
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông Báo");
                return;
            }

            if (nhaplaimatkhau != matkhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác", "Thông Báo");
                return;
            }
            //hàm kiểm tra mã nếu không đúng sẽ bắt nhập mã lại
            string userEnteredCode = txtMaXacNhan.Text.Trim();
            if (userEnteredCode != verification_code)
            {
                MessageBox.Show("Mã xác nhận sai vui lòng kiểm tra lại Mail.");
                return;
            }
            ////kiểm tra Tai khoan có tồn tại không
            //if (loaitk == "Sinh Viên")
            //{
            //    var account = context.TaiKhoanSVs.FirstOrDefault(a => (tentk.Contains("@") && a.Email == tentk) || (a.MaSV == tentk));
            //    if (account != null)
            //    {
            //        MessageBox.Show("Lấy lại mật khẩu thành công!", "Thông Báo");
            //        account.MatKhau = matkhau;
            //        context.SaveChanges();
            //        this.Close();
            //        return;
            //    }
            //}
            //if (loaitk == "Giảng Viên")
            //{
            //    var account = context.TaiKhoanGVs.FirstOrDefault(a => (tentk.Contains("@") && a.Email == tentk) || (a.MaGV == tentk));
            //    if (account != null)
            //    {
            //        MessageBox.Show("Lấy lại mật khẩu thành công!", "Thông Báo");
            //        account.MatKhau = matkhau;
            //        context.SaveChanges();
            //        this.Close();
            //        return;
            //    }
            //}

        }
        //nút gữi mã xác nhận
        private async void btnGui_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            string email = "";
            //kiểm tra là nếu có @ thì đó là email và gán vào email
            if (tentk.Contains("@"))
            {
                email = txtTaiKhoan.Text;
            }
            string from = "";  // email dùng để gửi mã
            string pass = "";  // key email

            //soạn tin nhắn để gửi
            MailMessage message = new MailMessage();
            message.To.Add(email);
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
                MessageBox.Show("Đang gửi mã xác nhận tới email: " + email, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
