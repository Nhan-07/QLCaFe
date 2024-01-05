using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Nhà_Hàng.Model
{
    public partial class frmStaffAdd : Form
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }

        public int id = 0;


        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtGmail.Text) || cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPhone.Text.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtGmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Gmail!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng Gmail
            if (!IsValidEmail(txtGmail.Text))
            {
                MessageBox.Show("Địa chỉ Gmail không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string qry = "";
            if (id == 0) //insert
            {
                qry = "Insert into staff Values(@Name,@phone,@role,@Gmail)";
            }
            else
            {
                qry = "Update staff Set sName = @Name, sPhone = @phone,sRole = @role,sGmail = @Gmail where staffID = @id ";

            }


            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@role", cbRole.Text);
            ht.Add("@Gmail", txtGmail.Text);


            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Lưu Thành Công");
                id = 0;
                txtName.Text = "";
                txtPhone.Text = "";
                txtGmail.Text = "";
                cbRole.SelectedIndex = -1;
                txtName.Focus();
            }
        }
    }
}
