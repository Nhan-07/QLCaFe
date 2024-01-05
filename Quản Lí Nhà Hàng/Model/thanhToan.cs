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
    public partial class thanhToan : Form
    {
        public thanhToan()
        {
            InitializeComponent();
        }

        public double total = 0;
        public bool check = false;
        public int MainID = 0;

        //public void txtThanhToanDaNhan_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtThanhToanDaNhan.Text != "")
        //    {
        //        double amt = total;
        //        double received = 0;
        //        double change = 0;

        //        double.TryParse(txtThanhToanDaNhan.Text, out received);

        //        change = received - amt; // chuyển đổi số âm thành dương
        //        txtThayDoi.Text = change.ToString();

               
        //    }
        //    else
        //        guna2MessageDialog1.Show("Đã nhận");

        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtThanhToanDaNhan.Text))
            {
                double amt = total;
                double received = 0;
                double change = 0;

                if (!double.TryParse(txtThanhToanDaNhan.Text, out received))
                {
                    MessageBox.Show("Số tiền thanh toán không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                change = received - amt;

                if (change < 0)
                {
                    txtThayDoi.Text = "Còn thiếu " + Math.Abs(change).ToString();
                    MessageBox.Show("Số tiền thanh toán không đủ!!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    txtThayDoi.Text = change.ToString();
                    MessageBox.Show("Thanh toán thành công!!!!");
                }

                string qry = @"UPDATE tblMain SET total = @total, received = @received, change = @change, status = N'Đã trả' WHERE MainID = @id";

                Hashtable ht = new Hashtable();

                if (change >= 0)
                {
                    ht.Add("@id", MainID);
                    ht.Add("@total", double.Parse(txtTongTienHoaDon.Text));
                    ht.Add("@received", received);
                    ht.Add("@change", change);

                    if (MainClass.SQl(qry, ht) > 0)
                    {
                        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        guna2MessageDialog1.Show("Đã thanh toán thành công");
                        this.Close();
                    }
                }
                else
                {
                    guna2MessageDialog1.Show("Đã nhận");
                }
            }
        }

        private void thanhToan_Load(object sender, EventArgs e)
        {
            txtTongTienHoaDon.Text = total.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
