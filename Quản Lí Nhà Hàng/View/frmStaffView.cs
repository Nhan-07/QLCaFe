using Quản_Lí_Nhà_Hàng.Model;
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

namespace Quản_Lí_Nhà_Hàng.View
{
    public partial class frmStaffView : Form
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * from staff where sName like '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);

            MainClass.LoadData(qry, guna2DataGridView1, lb);

            ThongKeSoLuongNhanVien(); // Cập nhật số lượng nhân viên sau khi load dữ liệu
        }

        private void frmStaffView_Load(object sender, EventArgs e)
        {
            GetData();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            MainClass.BlurBackground(new frmStaffAdd());
            GetData();

            ThongKeSoLuongNhanVien();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void ThongKeSoLuongNhanVien()
        {
            // Lấy số lượng nhân viên từ DataGridView
            int soLuongNhanVien = guna2DataGridView1.Rows.Count;

            // Hiển thị kết quả thống kê
           // MessageBox.Show("Số lượng nhân viên đang có trong quán là: " + soLuongNhanVien);
            lblTong.Text = soLuongNhanVien.ToString() + " Người";  
        }

        

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {

                frmStaffAdd frm = new frmStaffAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);

                frm.ShowDialog();
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                // need to confirm before  delete
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Bạn  có chắc muốn xóa không ?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                    string qry = "Delete from  staff where  staffID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Xóa Thành Công");
                    GetData();
                }

            }

        }
    }
}
